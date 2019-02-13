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
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class SetupUnitController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupUnit
        public ActionResult Index(int? pageNumber)
        {

            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            return View(aptUnits.ToList());
        }

        // GET: SetupUnit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptUnit aptUnit = db.AptUnits.Find(id);
            if (aptUnit == null)
            {
                return HttpNotFound();
            }
            return View(aptUnit);
        }

        // GET: SetupUnit/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie");
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status");
            return View();
        }

        // POST: SetupUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitID,UnitNo,Lantai,CategorieID,StatusID,Inhouse,PriceKPR,StatOld")] AptUnit aptUnit)
        {
            
            if (ModelState.IsValid)
            {
               
                aptUnit.StatOld = aptUnit.StatusID;

                db.AptUnits.Add(aptUnit);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie", aptUnit.CategorieID);
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status", aptUnit.StatusID);
            return View(aptUnit);
        }

        // GET: SetupUnit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptUnit aptUnit = db.AptUnits.Find(id);
            if (aptUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie", aptUnit.CategorieID);
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status", aptUnit.StatusID);
            return View(aptUnit);
        }

        // POST: SetupUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitID,UnitNo,Lantai,CategorieID,StatusID,Inhouse,PriceKPR,StatOld")] AptUnit aptUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie", aptUnit.CategorieID);
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status", aptUnit.StatusID);
            return View(aptUnit);
        }

        // GET: SetupUnit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptUnit aptUnit = db.AptUnits.Find(id);
            if (aptUnit == null)
            {
                return HttpNotFound();
            }
            return View(aptUnit);
        }

        // POST: SetupUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptUnit aptUnit = db.AptUnits.Find(id);
            db.AptUnits.Remove(aptUnit);
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
