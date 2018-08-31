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
    public class TransAngsuranController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: TransAngsuran
        public ActionResult Index()
        {
            return View(db.ArTransHs.ToList());
        }

        // GET: TransAngsuran/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransH arTransH = db.ArTransHs.Find(id);
            if (arTransH == null)
            {
                return HttpNotFound();
            }
            return View(arTransH);
        }

        // GET: TransAngsuran/Create
        public ActionResult Create()
        {
            var kodeno = "BM-";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno + thnbln;
            var maxvalue = "";
            var maxlist = db.ArTransHs.Where(x => x.Bukti.Substring(0, 7).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.Bukti);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "000";
            if (maxvalue == null)
            {
                nourut = "000";
            }
            else
            {
                nourut = maxvalue.Substring(7, 3);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeno + thnbln + (Int32.Parse(nourut) + 1).ToString("000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            ViewBag.NoRef = cAngNo;
            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            return View();
        }

        // POST: TransAngsuran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArHID,ArHGd,Bukti,Tanggal,BankID,CustomerID,MarketingID,UnitID,Keterangan,JthTempo,Jumlah,Piutang,Unapplied,Diskon")] ArTransH arTransH)
        {
            if (ModelState.IsValid)
            {
                db.ArTransHs.Add(arTransH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arTransH);
        }

        // GET: TransAngsuran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransH arTransH = db.ArTransHs.Find(id);
            if (arTransH == null)
            {
                return HttpNotFound();
            }
            return View(arTransH);
        }

        // POST: TransAngsuran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArHID,ArHGd,Bukti,Tanggal,BankID,CustomerID,MarketingID,UnitID,Keterangan,JthTempo,Jumlah,Piutang,Unapplied,Diskon")] ArTransH arTransH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arTransH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arTransH);
        }

        // GET: TransAngsuran/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransH arTransH = db.ArTransHs.Find(id);
            if (arTransH == null)
            {
                return HttpNotFound();
            }
            return View(arTransH);
        }

        // POST: TransAngsuran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArTransH arTransH = db.ArTransHs.Find(id);
            db.ArTransHs.Remove(arTransH);
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
