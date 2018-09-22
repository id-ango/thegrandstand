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
    public class SetupMarketingController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupMarketing
        public ActionResult Index()
        {
            var aptMarketings = db.AptMarketings.Include(a => a.AptAgen);
            return View(aptMarketings.ToList());
        }

        // GET: SetupMarketing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            if (aptMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aptMarketing);
        }

        // GET: SetupMarketing/Create
        public ActionResult Create()
        {
            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName");
            return View();
        }

        // POST: SetupMarketing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketingID,MarketingName,Phone,AgenID")] AptMarketing aptMarketing)
        {
            if (ModelState.IsValid)
            {
                db.AptMarketings.Add(aptMarketing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName", aptMarketing.AgenID);
            return View(aptMarketing);
        }

        // GET: SetupMarketing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            if (aptMarketing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName", aptMarketing.AgenID);
            return View(aptMarketing);
        }

        // POST: SetupMarketing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketingID,MarketingName,Phone,AgenID")] AptMarketing aptMarketing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptMarketing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName", aptMarketing.AgenID);
            return View(aptMarketing);
        }

        // GET: SetupMarketing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            if (aptMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aptMarketing);
        }

        // POST: SetupMarketing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            db.AptMarketings.Remove(aptMarketing);
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
