using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmeticStore.Models
{
    public class Cosmetic
    {
        [Key]
        public int cid { get; set; }
        public string ID { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public int money { get; set; }
    }
}