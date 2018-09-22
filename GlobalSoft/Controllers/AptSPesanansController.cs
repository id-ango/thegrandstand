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
    public class AptSPesanansController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: AptSPesanans
        public ActionResult Index()
        {
            return View(db.AptSPesanans.ToList());
        }

        // GET: AptSPesanans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            if (aptSPesanan == null)
            {
                return HttpNotFound();
            }
            return View(aptSPesanan);
        }

        // GET: AptSPesanans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AptSPesanans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SPesananID,SPesanan,Tanggal,Duedate,KodeTrans,LPB,Keterangan,KetBayar,Jumlah,Bayar,Sisa,SldSisa,Diskon")] AptSPesanan aptSPesanan)
        {
            if (ModelState.IsValid)
            {
                db.AptSPesanans.Add(aptSPesanan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptSPesanan);
        }

        // GET: AptSPesanans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            if (aptSPesanan == null)
            {
                return HttpNotFound();
            }
            return View(aptSPesanan);
        }

        // POST: AptSPesanans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SPesananID,SPesanan,Tanggal,Duedate,KodeTrans,LPB,Keterangan,KetBayar,Jumlah,Bayar,Sisa,SldSisa,Diskon")] AptSPesanan aptSPesanan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptSPesanan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptSPesanan);
        }

        // GET: AptSPesanans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            if (aptSPesanan == null)
            {
                return HttpNotFound();
            }
            return View(aptSPesanan);
        }

        // POST: AptSPesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            db.AptSPesanans.Remove(aptSPesanan);
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
