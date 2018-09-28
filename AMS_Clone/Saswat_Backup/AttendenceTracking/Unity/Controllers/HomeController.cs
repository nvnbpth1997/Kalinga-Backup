using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AttendenceTracking.ApiControllers;
using System.Net.Http.Headers;
using System.Net.Http;
using Tracking.Bussiness;
using Tracking.Entities;
using System.IO;
using ITracking.Bussiness;


namespace AttendenceTracking.Controllers
{
    public class HomeController : Controller
    {
      /*  private readonly TrackingBussiness itrack = new TrackingBussiness();
       
        // private readonly ITrackingBusiness itrack;

        public ActionResult Index()
        {
 
            StringContent stringcontent = new StringContent("C:/Users/M1046631/Documents/Swipe details_dummy1");
            System.Net.Http.HttpClient client = new HttpClient();
             client.BaseAddress = new Uri("http://localhost:64482/");
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
             HttpResponseMessage response = client.PostAsync("api/ExcelToDB/ExcelBinding",stringcontent).Result;
          //  var list = new ExcelToDBController.ExcelBinding( itrack);
            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".xlsx" && file.ContentLength > 0)
                {
                    System.Net.Http.HttpClient client = new HttpClient();
                    string _FileName = Path.GetFileName(file.FileName);
                    var _RenamedFileName  = DateTime.Now.ToString("yyyy-MM-dd");
                   // string _path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/UploadXml"), _FileName);
                    string re_path = System.Web.HttpContext.Current.Server.MapPath("~/UploadXml");
                    string re_path_ext = ".xlsx";
                    if (System.IO.File.Exists(re_path + "//" + _RenamedFileName + re_path_ext))
                    {
                        
                        System.IO.File.Delete(re_path + "//" + _RenamedFileName + re_path_ext);
                        itrack.DeleteWorngEntry(_RenamedFileName);
                        file.SaveAs(re_path + "//" + _RenamedFileName + re_path_ext);
                        itrack.ExcelBinding(re_path + "//" + _RenamedFileName + re_path_ext);
                        
                    }
                    else
                    {
                        file.SaveAs(re_path + "//" + _RenamedFileName + re_path_ext);
                        itrack.ExcelBinding(re_path + "//" + _RenamedFileName + re_path_ext);
                        
                       // itrack.ExcelBinding(re_path + "//" + _RenamedFileName + re_path_ext);
                    }
                     
                    /* StringContent stringcontent = new StringContent(_path);
                    
                    client.BaseAddress = new Uri("http://localhost:64482/");
                    client.DefaultRequestHeaders.Accept.Add(
                                           new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.PostAsJsonAsync("api/ExcelToDB/ExcelBinding", stringcontent);
                    response.Wait();
                    HttpResponseMessage message = response.Result;*/
 
               /* }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return View();
        }
        [Route("Defaulters")]
        public ActionResult Defaulters()
        {
            System.Net.Http.HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64482/");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/ExcelToDB/EmailDefaulters").Result;
            return View();
        }

            }*/
           
        

        
        
    }
}
