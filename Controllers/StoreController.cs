using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using PromoApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PromoApp.Controllers
{
    public class StoreController : Controller
    {
        private readonly AppDbContext db;
        private readonly IHttpContextAccessor httpConn;
        private readonly IWebHostEnvironment hostingEnv;

        public StoreController(AppDbContext context, IHttpContextAccessor httpCon, IWebHostEnvironment env)
        {
            db = context;
            httpConn = httpCon;
            hostingEnv = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadStore()
        {
            var model = db.Stores.Select(a => a);
            ViewBag.Store = model.ToList();
            return PartialView("_LoadStore");
        }

        public IActionResult Upload()
        {
            return PartialView("_Upload");
        }

        public async Task<IActionResult> proses_upload(StoreParam data)
        {
            try
            {
                using (var stream = new MemoryStream())
                {

                    await data.file.CopyToAsync(stream);

                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (var pkg = new OfficeOpenXml.ExcelPackage(stream))
                    {
                        ExcelWorksheet ws = pkg.Workbook.Worksheets[0];
                        var rowCount = ws.Dimension.Rows;
                        for (int row = 2; row < rowCount; row++)
                        {
                            string storeId = ws.Cells[row, 1].Value.ToString().Trim();
                            string storeName = ws.Cells[row, 2].Value.ToString().Trim();

                            var check = db.Stores.Where(a => a.storeId == storeId && a.storeName == storeName);
                            db.Stores.RemoveRange(check.Select(a => a));
                            await db.SaveChangesAsync();

                            Store dt = new Store();
                            dt.storeId = storeId;
                            dt.storeName = storeName;
                            
                            db.Stores.Add(dt);
                            await db.SaveChangesAsync();
                        }
                    }
                    stream.Close();
                }
                return Content("OK");
            }
            catch (Exception ex)
            {
                return Content(ex.Message.ToString());
            }
        }
    }
}
