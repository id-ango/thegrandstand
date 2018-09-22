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
    public class SetupPaymentController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupPayment
        public ActionResult Index()
        {
            var AptBayar = db.AptPayments.Include(a => a.CbBank);
            return View(AptBayar.ToList());
        }

        // GET: SetupPayment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptPayment aptPayment = db.AptPayments.Find(id);
            if (aptPayment == null)
            {
                return HttpNotFound();
            }
            return View(aptPayment);
        }

        // GET: SetupPayment/Create
        public ActionResult Create()
        {
            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            return View();
        }

        // POST: SetupPayment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,PaymentName,BankID")] AptPayment aptPayment)
        {
            if (ModelState.IsValid)
            {
                db.AptPayments.Add(aptPayment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName",aptPayment.BankID);
            return View(aptPayment);
        }

        // GET: SetupPayment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptPayment aptPayment = db.AptPayments.Find(id);
            if (aptPayment == null)
            {
                return HttpNotFound();
            }

            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName",aptPayment.BankID);
            return View(aptPayment);
        }

        // POST: SetupPayment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,PaymentName,BankID")] AptPayment aptPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptPayment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName",aptPayment.BankID);
            return View(aptPayment);
        }

        // GET: SetupPayment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptPayment aptPayment = db.AptPayments.Find(id);
            if (aptPayment == null)
            {
                return HttpNotFound();
            }
            return View(aptPayment);
        }

        // POST: SetupPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptPayment aptPayment = db.AptPayments.Find(id);
            db.AptPayments.Remove(aptPayment);
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
