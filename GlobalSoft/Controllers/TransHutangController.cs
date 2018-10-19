using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;
using Newtonsoft.Json.Linq;

namespace GlobalSoft.Controllers
{
    [Authorize(Roles ="Admin,Manager,Employee")]
    public class TransHutangController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();
        // GET: TransBank

        public ActionResult Index()
        {

            ViewBag.BankID = new SelectList(db.ApSuppliers, "SupplierID", "SupplierName");
            ViewBag.TransNoID = new SelectList(db.ApDistribSets, "DistribID", "AkunSet");
            List<ApHutangH> OrderAndDetailList = db.ApHutangHs.ToList();
            return View(OrderAndDetailList);
        }

        [Authorize(Roles = "Admin,Manager,Employee")]
        public ActionResult SaveOrder(string bukti, String keterangan,int SupplierID, string tanggal, string Duedate, ApHutangD[] order)
        {
            string result = "Error! Invoice Is Not Complete!";
            if (bukti != null && keterangan != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                CbTransH model = new CbTransH();
                model.GuidCb = cutomerId;
                model.Docno = bukti;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                model.BankID = SupplierID;
                decimal nJumlah = 0;

                foreach (var t in order)
                {
                    nJumlah = nJumlah + (t.Terima - t.Bayar);
                }

                model.Saldo = nJumlah;
                db.CbTransHs.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    CbTransD O = new CbTransD();
                    O.GuidDb = orderId;
                    O.Keterangan = item.Keterangan;
                    O.Tanggal = model.Tanggal;
                    O.TransNoID = item.TransNoID;
                    O.Terima = item.Terima;
                    O.Bayar = item.Bayar;
                    O.Jumlah = item.Terima-item.Bayar;
                    O.GuidCb = cutomerId;
                    db.CbTransDs.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetKode(string kodeno)
        {
           // string result = "Error! Order Is Not Complete!";

            // var maxvalue = db.AptTranss.Max(x =>  x.NoRef.Substring(0, 10));

            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno + thnbln;
            var maxvalue = "";
            var maxlist = db.CbTransHs.Where(x => x.Docno.Substring(0,7).Equals(xbukti)).ToList();
            if (maxlist!= null)
            {
                maxvalue = maxlist.Max(x => x.Docno);

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
            string cNoref = cAngNo;

         //   result = "Success! Order Is Complete!";
            return Json(cAngNo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTransH arTransH = db.CbTransHs.Find(id);

            if (arTransH == null)
            {
                return HttpNotFound();
            }
            // List<ArTransH> OrderAndDetailList = arTransH;
            ViewBag.Bank = db.CbBanks.Find(arTransH.BankID).BankName;
            ViewBag.TransNo = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            return View(arTransH);
        }

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTransH arTransH = db.CbTransHs.Find(id);
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
            CbTransH arTransH = db.CbTransHs.Find(id);
            db.CbTransHs.Remove(arTransH);
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


