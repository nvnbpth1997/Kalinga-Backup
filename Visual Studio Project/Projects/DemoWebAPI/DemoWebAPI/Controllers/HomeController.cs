using DemoWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace DemoWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

                IEnumerable<Product> ObjCustomer = null;
                HttpClient client = new HttpClient();
                //Consumption of service
                client.BaseAddress = new Uri("http://localhost:53347/");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Products/GetAllProducts").Result;
                if (response.IsSuccessStatusCode)
                {
                    var EmpResponse = response.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    ObjCustomer = JsonConvert.DeserializeObject<List<Product>>(EmpResponse);
                }

                return View(ObjCustomer);
            }
    }
    }
