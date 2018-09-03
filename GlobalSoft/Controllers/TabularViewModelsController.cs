using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;

namespace GlobalSoft.Controllers
{
    public class TabularViewModelsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: TabularViewModels
        public ActionResult Index()
        {
            TabularViewModel TabelView = new TabularViewModel();
            TabelView.Gedungs = db.AptGedungs.ToList();
            TabelView.Units = db.AptUnits.ToList();
            TabelView.Kategoris = db.AptCategories.ToList();

            return View(TabelView);
        }

        // GET: TabularViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabularViewModel tabularViewModel = db.TabularViewModels.Find(id);
            if (tabularViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tabularViewModel);
        }

        // GET: TabularViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TabularViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TabID")] TabularViewModel tabularViewModel)
        {
            if (ModelState.IsValid)
            {
                db.TabularViewModels.Add(tabularViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabularViewModel);
        }

        // GET: TabularViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabularViewModel tabularViewModel = db.TabularViewModels.Find(id);
            if (tabularViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tabularViewModel);
        }

        // POST: TabularViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TabID")] TabularViewModel tabularViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabularViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabularViewModel);
        }

        // GET: TabularViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabularViewModel tabularViewModel = db.TabularViewModels.Find(id);
            if (tabularViewModel == null)
            {
                return HttpNotFound();
            }
            return View(tabularViewModel);
        }

        // POST: TabularViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabularViewModel tabularViewModel = db.TabularViewModels.Find(id);
            db.TabularViewModels.Remove(tabularViewModel);
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
