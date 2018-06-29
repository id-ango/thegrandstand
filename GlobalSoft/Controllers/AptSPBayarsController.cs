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
    public class AptSPBayarsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: AptSPBayars
        public ActionResult Index()
        {
            return View(db.AptSPBayars.ToList());
        }

        // GET: AptSPBayars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPBayar aptSPBayar = db.AptSPBayars.Find(id);
            if (aptSPBayar == null)
            {
                return HttpNotFound();
            }
            return View(aptSPBayar);
        }

        // GET: AptSPBayars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AptSPBayars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SPBayarID,BuktiByr,Tanggal,Duedate,SPesananID,LPB,Keterangan,KetBayar,Jumlah,Bayar,Sisa,SldSisa,Diskon,CaraBayarID")] AptSPBayar aptSPBayar)
        {
            if (ModelState.IsValid)
            {
                db.AptSPBayars.Add(aptSPBayar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptSPBayar);
        }

        // GET: AptSPBayars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPBayar aptSPBayar = db.AptSPBayars.Find(id);
            if (aptSPBayar == null)
            {
                return HttpNotFound();
            }
            return View(aptSPBayar);
        }

        // POST: AptSPBayars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SPBayarID,BuktiByr,Tanggal,Duedate,SPesananID,LPB,Keterangan,KetBayar,Jumlah,Bayar,Sisa,SldSisa,Diskon,CaraBayarID")] AptSPBayar aptSPBayar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptSPBayar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptSPBayar);
        }

        // GET: AptSPBayars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPBayar aptSPBayar = db.AptSPBayars.Find(id);
            if (aptSPBayar == null)
            {
                return HttpNotFound();
            }
            return View(aptSPBayar);
        }

        // POST: AptSPBayars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptSPBayar aptSPBayar = db.AptSPBayars.Find(id);
            db.AptSPBayars.Remove(aptSPBayar);
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
