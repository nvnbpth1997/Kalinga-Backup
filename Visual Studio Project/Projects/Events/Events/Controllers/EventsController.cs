using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Events.Models;

namespace Events.Controllers
{
    public class EventsController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyEvents()
        {
            SqlConnection con = null;
            try
            {
                string connstr = "Data Source=G1C2ML15646;Initial Catalog=Naveen;Integrated Security=True";
                con = new SqlConnection(connstr);
                con.Open();
                List<setEvents> events = new List<setEvents>();
                
                if (con != null)
                {
                    string querystring = "Select * from eventhandler";

                    try
                    {
                        SqlCommand cmd = new SqlCommand(querystring, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            setEvents e = new setEvents();
                            e.title = reader[0].ToString();
                            e.date = reader[1].ToString();
                            e.time = reader[2].ToString();
                            e.description = reader[3].ToString();
                            e.location = reader[4].ToString(); 
                            e.isPublic =  reader[5].ToString();

                            events.Add(e); 
                        }
                        //ViewData["events"] = events;
                        //ViewBag.events = events;
                        TempData["events"] = events;
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Exception occurred");
                    }
                }
            }
            catch (SqlException)
            {

            }

            finally
            {
                con.Close();
            }
            return View();
        }
       
        
        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Event/Create
        public ActionResult CreateEvent()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult CreateEvent(setEvents events)
        {

            //TODO: Add insert logic here
            if (ModelState.IsValid)
            {
                SqlConnection con = null;
                try
                {
                    string connstr = "Data Source=G1C2ML15646;Initial Catalog=Naveen;Integrated Security=True";
                    con = new SqlConnection(connstr);
                    con.Open();
                }
                catch (SqlException)
                {
                    Console.WriteLine("Couldn't establish connection with server!");
                }
                int status = 0;
                try
                {
                    if (con != null)
                    {
                  
                        {
                            String sql = "insert into eventhandler values(@title,@date,@time, @description, @location, @ispublic)";
                            SqlCommand cmd = new SqlCommand(sql, con);

                            cmd.Parameters.AddWithValue("@title", events.title);
                            cmd.Parameters.AddWithValue("@date", events.date);
                            cmd.Parameters.AddWithValue("@time", events.time);
                            cmd.Parameters.AddWithValue("@description", events.description);
                            cmd.Parameters.AddWithValue("@location", events.location);
                            cmd.Parameters.AddWithValue("@ispublic", events.isPublic);
                            try
                            {
                                status = (cmd.ExecuteNonQuery());
                            }
                            catch (SqlException)
                            {
                                Console.WriteLine("Can't have duplicate student ID's");
                            }
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
                return RedirectToAction("MyEvents");
            }
            return View();
        }
                          
                
            
      

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Event/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
