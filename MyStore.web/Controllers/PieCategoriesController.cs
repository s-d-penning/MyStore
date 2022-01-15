using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStore.web.DataAccess;
using MyStore.web.Models;

namespace MyStore.web.Controllers
{
    public class PieCategoriesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: PieCategories
        public ActionResult Index()
        {
            return View(db.PieCategories.OrderBy(c => c.Name).ToList());
        }

        // GET: PieCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieCategory pieCategory = db.PieCategories.Find(id);
            if (pieCategory == null)
            {
                return HttpNotFound();
            }
            return View(pieCategory);
        }

        // GET: PieCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PieCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] PieCategory pieCategory)
        {
            if (ModelState.IsValid)
            {
                db.PieCategories.Add(pieCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pieCategory);
        }

        // GET: PieCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieCategory pieCategory = db.PieCategories.Find(id);
            if (pieCategory == null)
            {
                return HttpNotFound();
            }
            return View(pieCategory);
        }

        // POST: PieCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] PieCategory pieCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pieCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pieCategory);
        }

        // GET: PieCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PieCategory pieCategory = db.PieCategories.Find(id);
            if (pieCategory == null)
            {
                return HttpNotFound();
            }
            return View(pieCategory);
        }

        // POST: PieCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PieCategory pieCategory = db.PieCategories.Find(id);

            foreach (var p in pieCategory.Pies)
            {
                p.PieCategoryID = null;
            }

            db.PieCategories.Remove(pieCategory);
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
