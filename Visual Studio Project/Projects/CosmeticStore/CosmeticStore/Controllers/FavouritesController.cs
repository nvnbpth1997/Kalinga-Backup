using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CosmeticStore.DataAccessLayer;
using CosmeticStore.Models;

namespace CosmeticStore.Controllers
{
    public class FavouritesController : Controller
    {
        private CosmeticDbContext db = new CosmeticDbContext();

        // GET: Favourites
        public ActionResult Index()
        {
            var favourites = db.Favourites.Include(f => f.Cosmetic).Include(f => f.User);
            return View(favourites.ToList());
        }

        // GET: Favourites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourite favourite = db.Favourites.Find(id);
            if (favourite == null)
            {
                return HttpNotFound();
            }
            return View(favourite);
        }

        // GET: Favourites/Create
        public ActionResult Create()
        {
            ViewBag.name = new SelectList(db.Cosmetics, "name", "name");
            //ViewBag.uid = new SelectList(db.Users, "uid", "username");
            return View();
        }

        // POST: Favourites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fid,uid,cid")] Favourite favourite)
        {
            if (ModelState.IsValid)
            {
                db.Favourites.Add(favourite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.name = new SelectList(db.Cosmetics, "name", "name", favourite.Cosmetic.name);
            //ViewBag.uid = new SelectList(db.Users, "uid", "username", favourite.uid);
            return View(favourite);
        }

        // GET: Favourites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourite favourite = db.Favourites.Find(id);
            if (favourite == null)
            {
                return HttpNotFound();
            }
            ViewBag.cid = new SelectList(db.Cosmetics, "cid", "ID", favourite.cid);
            ViewBag.uid = new SelectList(db.Users, "uid", "username", favourite.uid);
            return View(favourite);
        }

        // POST: Favourites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fid,uid,cid")] Favourite favourite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favourite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cid = new SelectList(db.Cosmetics, "cid", "ID", favourite.cid);
            ViewBag.uid = new SelectList(db.Users, "uid", "username", favourite.uid);
            return View(favourite);
        }

        // GET: Favourites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourite favourite = db.Favourites.Find(id);
            if (favourite == null)
            {
                return HttpNotFound();
            }
            return View(favourite);
        }

        // POST: Favourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favourite favourite = db.Favourites.Find(id);
            db.Favourites.Remove(favourite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
