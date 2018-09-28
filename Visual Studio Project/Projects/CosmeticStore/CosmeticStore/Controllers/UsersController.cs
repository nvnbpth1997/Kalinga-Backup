using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CosmeticStore.BusinessLayer;
using CosmeticStore.DataAccessLayer;
using CosmeticStore.Models;

namespace CosmeticStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager userManager = new UserManager();

        // GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = userManager.FindUser(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uid,username,password")] User user)
        {

            userManager.AddUser(user);
            return RedirectToAction("Details", user);
        }

        // GET: Users/Edit/5
        ////public ActionResult Edit(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        ////    }
        ////    User user = userManager.FindUser(id);
        ////    if (user == null)
        ////    {
        ////        return HttpNotFound();
        ////    }
        ////    return View(user);
        ////}

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "uid,username,password")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userManager.EditUser(EntityState.Modified, user);
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        public ActionResult Details(User user)
        {
            user = userManager.FindUser(user);
            return RedirectToAction("Index", "Favourites", user);
        }
        // GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = userManager.FindUser(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = userManager.FindUser(id);
        //    userManager.RemoveUser(user);
        //    return RedirectToAction("Index");
        //}


        //Ask Rittik what to do with this
        // Using Idiposable
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
