using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromoApp.Models
{
    public class PromoParam
    {
        public int id { get; set; }
        [Display(Name = "Promo Id")]
        [Required(ErrorMessage = "Required")]
        public string promoId { get; set; }
        [Display(Name = "Promo Description")]
        [Required(ErrorMessage = "Required")]
        public string promoDesc { get; set; }
        [Display(Name = "Promo Type")]
        public string promoType { get; set; }
        [Display(Name = "Value Type")]
        public string valueType { get; set; }
        public double value { get; set; }
        public DateTime promoStart { get; set; }
        public DateTime promoEnd { get; set; }
        [Display(Name = "Item")]
        public IFormFile item { get; set; }
        [Display(Name = "Store")]
        public string store { get; set; }
    }
}
