using DemoWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;

namespace DemoWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        public static List<Product> Products;
        public ProductsController()
        {
            Products = new List<Product>() {
                new Product{ ID = 1,
                                ProductName = "Mobile",
                                Customers = new List<Customer>{
                                                new Customer{ Customer_ID = 1, CustomerName = "John"},
                                                new Customer{ Customer_ID = 2, CustomerName = "Martin"}
                                                            }
                },
                new Product{ ID = 2,
                                ProductName = "Ipad",
                                Customers = new List<Customer>{
                                                new Customer{ Customer_ID = 3, CustomerName = "Mathew"},
                                                new Customer{ Customer_ID = 4, CustomerName = "albert"}
                                                            }
                }
            };
        }

        [System.Web.Mvc.HttpGet]
        public List<Product> GetAllProducts()
        {
            return Products;
        }
    }
}