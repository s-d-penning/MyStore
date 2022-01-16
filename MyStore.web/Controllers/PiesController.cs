using MyStore.web.DataAccess;
using MyStore.web.Models;
using MyStore.web.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MyStore.web.Controllers
{
    public class PiesController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Pies
        public ActionResult Index(string category, string search, string sortBy, int? page)
        {
            PieIndexViewModel viewModel = new PieIndexViewModel();

            var pies = db.Pies.Include(p => p.Category);

            if (!String.IsNullOrEmpty(search))
            {
                pies = pies.Where(p => p.Name.Contains(search) ||
                                       p.Description.Contains(search) ||
                                       p.Category.Name.Contains(search));
                viewModel.Search = search;
            }

            viewModel.CatsWithCount = from matchingPies in pies
                where
                    matchingPies.PieCategoryID != null
                group matchingPies by
                    matchingPies.Category.Name into
                    catGroup
                select new CategoryWithCount()
                {
                    CategoryName = catGroup.Key,
                    PieCatCount = catGroup.Count()
                };

            if (!String.IsNullOrEmpty(category))
            {
                pies = pies.Where(p => p.Category.Name == category);
                viewModel.Category = category;
            }

            //sort the results
            switch (sortBy)
            {
                case "price_lowest":
                {
                    pies = pies.OrderBy(p => p.Price);
                    break;
                }
                case "price_highest":
                {
                    pies = pies.OrderByDescending(p => p.Price);
                    break;
                }
                default:
                {
                    pies = pies.OrderBy(p => p.Name);
                    break;
                }
            }

            const int PageItems = 3;
            int currentPage = (page ?? 1);
            viewModel.Pies = pies.ToPagedList(currentPage, PageItems);
            viewModel.SortBy = sortBy;

            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Price low to high", "price_lowest" },
                {"Price high to low", "price_highest" }
            };

            return View(viewModel);
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
