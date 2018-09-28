using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CampusMindTrackAllocation.Models;

namespace CampusMindTrackAllocation.Controllers
{
    public class MindsController : Controller
    {
        private NaveenEntities db = new NaveenEntities();

        // GET: Minds
        public ActionResult Index()
        {
            var minds = db.Minds.Include(m => m.Track);
            return View(minds.ToList());
        }

        // GET: Minds/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mind mind = db.Minds.Find(id);
            if (mind == null)
            {
                return HttpNotFound();
            }
            return View(mind);
        }

        // GET: Minds/Create
        public ActionResult Create()
        {
            ViewBag.TrackId = new SelectList(db.Tracks, "Track Name", "TrackName");
            return View();
        }

        // POST: Minds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MID,Name,Gender,Contact,TrackId")] Mind mind)
        {
            if (ModelState.IsValid)
            {
                db.Minds.Add(mind);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrackId = new SelectList(db.Tracks, "TrackId", "TrackName", mind.TrackId);
            return View(mind);
        }

        // GET: Minds/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mind mind = db.Minds.Find(id);
            if (mind == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrackId = new SelectList(db.Tracks, "TrackId", "TrackName", mind.TrackId);
            return View(mind);
        }

        // POST: Minds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MID,Name,Gender,Contact,TrackId")] Mind mind)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mind).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrackId = new SelectList(db.Tracks, "TrackId", "TrackName", mind.TrackId);
            return View(mind);
        }

        // GET: Minds/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mind mind = db.Minds.Find(id);
            if (mind == null)
            {
                return HttpNotFound();
            }
            return View(mind);
        }

        // POST: Minds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mind mind = db.Minds.Find(id);
            db.Minds.Remove(mind);
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
