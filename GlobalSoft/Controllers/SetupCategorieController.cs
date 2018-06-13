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
    public class SetupCategorieController : Controller
    {
        private ApartmentDBContext db = new ApartmentDBContext();

        // GET: SetupCategorie
        public ActionResult Index()
        {
            var aptCategories = db.AptCategories.Include(a => a.AptType);
            return View(aptCategories.ToList());
        }

        // GET: SetupCategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            if (aptCategorie == null)
            {
                return HttpNotFound();
            }
            return View(aptCategorie);
        }

        // GET: SetupCategorie/Create
        public ActionResult Create()
        {
            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe");
            return View();
        }

        // POST: SetupCategorie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategorieID,Categorie,Luas,TipeID")] AptCategorie aptCategorie)
        {
            if (ModelState.IsValid)
            {
                db.AptCategories.Add(aptCategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe", aptCategorie.TipeID);
            return View(aptCategorie);
        }

        // GET: SetupCategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            if (aptCategorie == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe", aptCategorie.TipeID);
            return View(aptCategorie);
        }

        // POST: SetupCategorie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategorieID,Categorie,Luas,TipeID")] AptCategorie aptCategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptCategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe", aptCategorie.TipeID);
            return View(aptCategorie);
        }

        // GET: SetupCategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            if (aptCategorie == null)
            {
                return HttpNotFound();
            }
            return View(aptCategorie);
        }

        // POST: SetupCategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            db.AptCategories.Remove(aptCategorie);
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
