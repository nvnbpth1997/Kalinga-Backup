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
    public class CosmeticsController : Controller
    {
        private readonly CosmeticManager cosmeticManager= new CosmeticManager();
        // GET: Cosmetics
        public ActionResult Index()
        {
            return View(cosmeticManager.ListCosmetic().ToList());
        }

        // GET: Cosmetics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cosmetic cosmetic = cosmeticManager.FindCosmetic(id);
            if (cosmetic == null)
            {
                return HttpNotFound();
            }
            return View(cosmetic);
        }

        // GET: Cosmetics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cosmetics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cid,ID,name,company,category,quantity,money")] Cosmetic cosmetic)
        {
            if (ModelState.IsValid)
            {
                cosmeticManager.AddCosmetic(cosmetic);
                return RedirectToAction("Index");
            }

            return View(cosmetic);
        }

        // GET: Cosmetics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cosmetic cosmetic = cosmeticManager.FindCosmetic(id);
            if (cosmetic == null)
            {
                return HttpNotFound();
            }
            return View(cosmetic);
        }

        // POST: Cosmetics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cid,ID,name,company,category,quantity,money")] Cosmetic cosmetic)
        {
            if (ModelState.IsValid)
            {
                cosmeticManager.EditUser(EntityState.Modified, cosmetic);
                return RedirectToAction("Index");
            }
            return View(cosmetic);
        }

        // GET: Cosmetics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cosmetic cosmetic = cosmeticManager.FindCosmetic(id);
            if (cosmetic == null)
            {
                return HttpNotFound();
            }
            return View(cosmetic);
        }

        // POST: Cosmetics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cosmetic cosmetic = cosmeticManager.FindCosmetic(id);
            cosmeticManager.RemoveUser(cosmetic);
            return RedirectToAction("Index");
        }

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
