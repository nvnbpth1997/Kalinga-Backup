using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Models
{
    public class Customer
    {
            [Required(ErrorMessage = "id is required")]
            public int Customer_ID { get; set; }
            public string CustomerName { get; set; }
    }
}