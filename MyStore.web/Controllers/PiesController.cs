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
    public class PiesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Pies
        public ActionResult Index(string category, string search)
        {
            var pies = db.Pies.Include(p => p.Category);

            if (!String.IsNullOrEmpty(category))
            {
                pies = pies.Where(p => p.Category.Name == category);
            }

            if (!String.IsNullOrEmpty(search))
            {
                pies = pies.Where(p => p.Name.Contains(search) ||
                                               p.Description.Contains(search) ||
                                               p.Category.Name.Contains(search));
            }

            return View(pies.ToList());
        }

        // GET: Pies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pie pie = db.Pies.Find(id);
            if (pie == null)
            {
                return HttpNotFound();
            }
            return View(pie);
        }

        // GET: Pies/Create
        public ActionResult Create()
        {
            ViewBag.PieCategoryID = new SelectList(db.PieCategories, "ID", "Name");
            return View();
        }

        // POST: Pies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Price,PieCategoryID")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                db.Pies.Add(pie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PieCategoryID = new SelectList(db.PieCategories, "ID", "Name", pie.PieCategoryID);
            return View(pie);
        }

        // GET: Pies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pie pie = db.Pies.Find(id);
            if (pie == null)
            {
                return HttpNotFound();
            }
            ViewBag.PieCategoryID = new SelectList(db.PieCategories, "ID", "Name", pie.PieCategoryID);
            return View(pie);
        }

        // POST: Pies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price,PieCategoryID")] Pie pie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PieCategoryID = new SelectList(db.PieCategories, "ID", "Name", pie.PieCategoryID);
            return View(pie);
        }

        // GET: Pies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pie pie = db.Pies.Find(id);
            if (pie == null)
            {
                return HttpNotFound();
            }
            return View(pie);
        }

        // POST: Pies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pie pie = db.Pies.Find(id);
            db.Pies.Remove(pie);
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
