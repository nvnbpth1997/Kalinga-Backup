using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AMSWebApi.Models
{
    public class Image
    {
        [Key]
        public int ID { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
    }
}