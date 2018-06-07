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
    public class SetupCustomerController : Controller
    {
        private GlobalDbContext db = new GlobalDbContext();

        // GET: SetupCustomer
        public ActionResult Index()
        {
            return View(db.ArCustomers.ToList());
        }

        // GET: SetupCustomer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArCustomer arCustomer = db.ArCustomers.Find(id);
            if (arCustomer == null)
            {
                return HttpNotFound();
            }
            return View(arCustomer);
        }

        // GET: SetupCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupCustomer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,ShortName,Alamat,Ktp,Phone,AlamatSekarang,KodePos,Email,Npwp,AccounSet")] ArCustomer arCustomer)
        {
            if (ModelState.IsValid)
            {
                db.ArCustomers.Add(arCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arCustomer);
        }

        // GET: SetupCustomer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArCustomer arCustomer = db.ArCustomers.Find(id);
            if (arCustomer == null)
            {
                return HttpNotFound();
            }
            return View(arCustomer);
        }

        // POST: SetupCustomer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,ShortName,Alamat,Ktp,Phone,AlamatSekarang,KodePos,Email,Npwp,AccounSet")] ArCustomer arCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arCustomer);
        }

        // GET: SetupCustomer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArCustomer arCustomer = db.ArCustomers.Find(id);
            if (arCustomer == null)
            {
                return HttpNotFound();
            }
            return View(arCustomer);
        }

        // POST: SetupCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArCustomer arCustomer = db.ArCustomers.Find(id);
            db.ArCustomers.Remove(arCustomer);
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
