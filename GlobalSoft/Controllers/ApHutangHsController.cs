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
    public class ApHutangHsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: ApHutangHs
        public ActionResult Index()
        {
            var Transaksi = (from e in db.ApHutangHs
                             join y in db.ApSuppliers on e.SupplierID equals y.SupplierID
                             select new ArHView
                             {
                                 ArHID = e.ApHID,
                                 Bukti = e.Bukti,
                                 Tanggal = e.Tanggal,                               
                                 CustomerID = e.SupplierID,
                                 CustomerName = y.SupplierName,
                                 Keterangan = e.Keterangan,
                                 Jumlah = e.Jumlah
                             });

           

            return View(Transaksi);
        }

        // GET: ApHutangHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApHutangH apHutangH = db.ApHutangHs.Find(id);
            if (apHutangH == null)
            {
                return HttpNotFound();
            }
            return View(apHutangH);
        }

        // GET: ApHutangHs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApHutangHs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApHID,ApHGd,KodeNo,Bukti,Tanggal,BankID,SupplierID,Keterangan,JthTempo,PPn,PPnpersen,Brutto,Netto,Jumlah,Hutang,Unapplied,Diskon")] ApHutangH apHutangH)
        {
            if (ModelState.IsValid)
            {
                db.ApHutangHs.Add(apHutangH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apHutangH);
        }

        // GET: ApHutangHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApHutangH apHutangH = db.ApHutangHs.Find(id);
            if (apHutangH == null)
            {
                return HttpNotFound();
            }
            return View(apHutangH);
        }

        // POST: ApHutangHs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApHID,ApHGd,KodeNo,Bukti,Tanggal,BankID,SupplierID,Keterangan,JthTempo,PPn,PPnpersen,Brutto,Netto,Jumlah,Hutang,Unapplied,Diskon")] ApHutangH apHutangH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apHutangH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apHutangH);
        }

        // GET: ApHutangHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApHutangH apHutangH = db.ApHutangHs.Find(id);
            if (apHutangH == null)
            {
                return HttpNotFound();
            }
            return View(apHutangH);
        }

        // POST: ApHutangHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApHutangH apHutangH = db.ApHutangHs.Find(id);
            db.ApHutangHs.Remove(apHutangH);
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
