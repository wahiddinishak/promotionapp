using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PromoApp.Models
{
    public class Store
    {
        [Key]
        public int id { get; set; }
        public string storeId { get; set; }
        public string storeName { get; set; }
    }
}
