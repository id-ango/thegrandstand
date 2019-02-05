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
    public class TransBankController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();
        // GET: TransBank

        public ActionResult Index()
        {

            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            ViewBag.TransNoID = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            List<CbTransH> OrderAndDetailList = db.CbTransHs.OrderByDescending(x =>x.Tanggal).ToList();
            return View(OrderAndDetailList);
        }

        [Authorize(Roles = "Admin,Manager,Employee")]
        public ActionResult SaveOrder(string docno, String keterangan,int bank, string tanggal, CbTransD[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (docno != null && keterangan != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                CbTransH model = new CbTransH();
                model.GuidCb = cutomerId;
                model.Docno = docno;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                model.BankID = bank;
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

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTransH arTransH = db.CbTransHs.SingleOrDefault(x => x.TranshID == id);

            if (arTransH == null)
            {
                return HttpNotFound();
            }
            var trans = (from e in db.CbTransDs where e.TranshID == arTransH.TranshID select e).ToList();

            OdTransH TransH = new OdTransH();
            List<OdTransD> TransD = new List<OdTransD>();

            TransH.TranshID = arTransH.TranshID;
            TransH.Docno = arTransH.Docno;
            TransH.Tanggal = arTransH.Tanggal;
            TransH.Keterangan = arTransH.Keterangan;
            TransH.Saldo = arTransH.Saldo;
            foreach( var e in trans)
            {
                TransD.Add(new OdTransD
                {
                    TranshID = e.TranshID,
                    TransdID = e.TransdID,
                    TransNoID = e.TransNoID,
                    TransNo = db.AptTrsNoes.SingleOrDefault(x => x.TransNoID == e.TransNoID).TransNo,
                Keterangan = e.Keterangan,
                    Terima = e.Terima,
                    Bayar = e.Bayar
                });
                                
            }
            TransH.OdTransDs = TransD;

            // List<ArTransH> OrderAndDetailList = arTransH;
            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName", arTransH.BankID);
            //     ViewBag.TransDP = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
                 ViewBag.TransDP = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");

            return View(TransH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Admin,Manager,Employee")]
        public ActionResult EditData(int transhid, string docno, String keterangan, int bank, string tanggal, CbTransD[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (docno != null && keterangan != null && order != null)
            {
                CbTransH arTransH = db.CbTransHs.Find(transhid);
                db.CbTransHs.Remove(arTransH);
                var arTransD = (from e in db.CbTransDs where e.TranshID == transhid select e ).ToList();
                foreach( var y in arTransD)
                {
                    db.CbTransDs.Remove(y);
                }
                db.SaveChanges();

                var cutomerId = Guid.NewGuid();
                CbTransH model = new CbTransH();
                model.GuidCb = cutomerId;
                model.Docno = docno;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                model.BankID = bank;
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
                    O.Jumlah = item.Terima - item.Bayar;
                    O.GuidCb = cutomerId;
                    db.CbTransDs.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuktiKasBank(string noref, int cetak)
        {
            List<OdTransD> TransD = new List<OdTransD>();

            var Transaksi = (from e in db.CbTransHs                            
                             where e.Docno == noref
                             select new OdTransH
                             {
                                 TranshID = e.TranshID,
                                 Docno = e.Docno,
                                 Tanggal = e.Tanggal,
                                 BankID = e.BankID,
                                 BankName = (from r in db.CbBanks where r.BankID == e.BankID select r.BankName).FirstOrDefault(),
                                 KodeBank = (from r in db.CbBanks where r.BankID == e.BankID select r.BankAccount).FirstOrDefault(),                                                             
                                 Keterangan = e.Keterangan,
                                Saldo = e.Saldo,
                             }).FirstOrDefault();


            var Detail = (from e in db.CbTransDs where e.TranshID == Transaksi.TranshID select e).ToList();

            foreach (var item in Detail)
            {
                TransD.Add(new OdTransD
                {

                    TransNoID = item.TransNoID,
                    TransNo = (from r in db.AptTrsNoes where r.TransNoID == item.TransNoID select r.TransNo).FirstOrDefault(),
                    Keterangan = item.Keterangan,
                    Tanggal = item.Tanggal,                  
                    Jumlah = item.Jumlah,
                    Bayar = item.Bayar,
                    Terima = item.Terima
                   
                });

            }
            Transaksi.OdTransDs = TransD;
           // ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)Transaksi.Jumlah);
            if (cetak == 1)
                return Json("Success", JsonRequestBehavior.AllowGet);


            return View(Transaksi);
        }

    }
}


