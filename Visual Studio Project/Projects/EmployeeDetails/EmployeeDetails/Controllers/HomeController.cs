using EmployeeDetails.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDetails.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            IEnumerable<Department> ObjEmployee = null;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:54327/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = httpClient.GetAsync("api/EmployeeAPI/GetAllDetails").Result;

            if(responseMessage.IsSuccessStatusCode)
            {
                var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
                ObjEmployee = JsonConvert.DeserializeObject<List<Department>>(EmpResponse);
            }

            return View(ObjEmployee);
        }

        //public ActionResult Put()
        //{
        //    IEnumerable<EmpDetails> ObjEmployee = null;

        //    HttpClient httpClient = new HttpClient();
        //    httpClient.BaseAddress = new Uri("http://localhost:53347/");
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage responseMessage = httpClient.PutAsync();

        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var EmpResponse = responseMessage.Content.ReadAsStringAsync().Result;
        //        ObjEmployee = JsonConvert.DeserializeObject<List<EmpDetails>>(EmpResponse);
        //    }

        //    return View();
        //}


    }
}
