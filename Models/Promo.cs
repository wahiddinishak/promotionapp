using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromoApp.Models
{
    public class Promo
    {
        [Key]
        public int id { get; set; }        
        public string promoId { get; set; }        
        public string promoDesc { get; set; }           
        public string promoType { get; set; }         
        public string valueType { get; set; }
        public double value { get; set; }
        public DateTime promoStart { get; set; }
        public DateTime promoEnd { get; set; }       
        public string item { get; set; }        
        public string store { get; set; }
    }
}
