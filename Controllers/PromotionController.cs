using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PromoApp.Controllers
{
    public class PromotionController : Controller
    {
        private readonly AppDbContext db;
        private readonly IHttpContextAccessor httpConn;
        private readonly IWebHostEnvironment hostingEnv;

        public PromotionController(AppDbContext context, IHttpContextAccessor httpCon, IWebHostEnvironment env)
        {
            db = context;
            httpConn = httpCon;
            hostingEnv = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NewPromo()
        {
            int counter = db.Promos.Count() + 10000;
            string id = string.Concat("P", DateTime.Now.ToString("yyyyMMdd"),
                                        Convert.ToString(counter).Substring(1, 4));

            PromoParam model = new PromoParam();
            model.promoId = id;
            model.promoStart = DateTime.Now;
            model.promoEnd = DateTime.Now;
            return PartialView("_NewPromo", model);
        }

        public IActionResult LoadStore()
        {
            var model = db.Stores.Select(a => a);
            ViewBag.Store = model.ToList();
            return PartialView("_LoadStore");
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Submit(PromoParam data)
        {
            Promo model = new Promo();
            model.promoId = data.promoId;
            model.promoDesc = data.promoDesc;
            model.promoType = data.promoType;
            model.valueType = data.valueType;
            model.value = data.value;
            if (data.item != null)
            {
                var fileName = string.Concat(model.promoId, ".txt");
                var filePath = Path.Combine(hostingEnv.WebRootPath, "file/", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await data.item.CopyToAsync(fileSteam);
                }
                model.item = fileName;
            }
            model.promoStart = data.promoStart;
            model.promoEnd = data.promoEnd;
            model.store = data.store.Replace(",,",",");

            db.Promos.Add(model);
            await db.SaveChangesAsync();
            return Content("OK");
        }
    }
}
