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
    [Authorize(Roles ="Admin,Manager,Employee")]
    public class AptGedungsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: AptGedungs
        public ActionResult Index()
        {
            
            return View(db.AptGedungs.ToList());
        }

        // GET: AptGedungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptGedung aptGedung = db.AptGedungs.Find(id);
            if (aptGedung == null)
            {
                return HttpNotFound();
            }
            return View(aptGedung);
        }

        // GET: AptGedungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AptGedungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GedungID,Gedung,Lantai1,Lantai2")] AptGedung aptGedung)
        {
            if (ModelState.IsValid)
            {
                db.AptGedungs.Add(aptGedung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptGedung);
        }

        // GET: AptGedungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptGedung aptGedung = db.AptGedungs.Find(id);
            if (aptGedung == null)
            {
                return HttpNotFound();
            }
            return View(aptGedung);
        }

        // POST: AptGedungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GedungID,Gedung,Lantai1,Lantai2")] AptGedung aptGedung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptGedung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptGedung);
        }

        // GET: AptGedungs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptGedung aptGedung = db.AptGedungs.Find(id);
            if (aptGedung == null)
            {
                return HttpNotFound();
            }
            return View(aptGedung);
        }

        // POST: AptGedungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptGedung aptGedung = db.AptGedungs.Find(id);
            db.AptGedungs.Remove(aptGedung);
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
