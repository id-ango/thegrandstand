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
    public class SetupStatusController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupStatus
        public ActionResult Index()
        {
            List<AptStatus> TipeGl = new List<AptStatus>
            {
                new AptStatus { Status = "Available" },
                new AptStatus { Status = "Hold" },
                new AptStatus { Status = "Sold" }
            };

            var cekNull = (from e in db.AptStatuses select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptStatuses.Add(values);
                    db.SaveChanges();
                }


            }
            return View(db.AptStatuses.ToList());
        }

        // GET: SetupStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptStatus aptStatus = db.AptStatuses.Find(id);
            if (aptStatus == null)
            {
                return HttpNotFound();
            }
            return View(aptStatus);
        }

        // GET: SetupStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,Status")] AptStatus aptStatus)
        {
            if (ModelState.IsValid)
            {
                db.AptStatuses.Add(aptStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptStatus);
        }

        // GET: SetupStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptStatus aptStatus = db.AptStatuses.Find(id);
            if (aptStatus == null)
            {
                return HttpNotFound();
            }
            return View(aptStatus);
        }

        // POST: SetupStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,Status")] AptStatus aptStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptStatus);
        }

        // GET: SetupStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptStatus aptStatus = db.AptStatuses.Find(id);
            if (aptStatus == null)
            {
                return HttpNotFound();
            }
            return View(aptStatus);
        }

        // POST: SetupStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptStatus aptStatus = db.AptStatuses.Find(id);
            db.AptStatuses.Remove(aptStatus);
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
