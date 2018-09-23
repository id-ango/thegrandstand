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
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class TransLedgerController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();
        // GET: TransBank

        public ActionResult Index()
        {

            ViewBag.GlAkunID = db.GlAccounts.Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString()
            });

            List<GlTransH> OrderAndDetailList = db.GlTransHs.ToList();
            return View(OrderAndDetailList);
        }

        [Authorize(Roles = "Admin,Manager,Employee")]
        public ActionResult SaveOrder(string docno, String keterangan,  string tanggal, GlTransD[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (docno != null && keterangan != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                GlTransH model = new GlTransH();
                model.GlHGd = cutomerId;
                model.Docno = docno;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                decimal nJumlah = 0;
                decimal nDebet = 0;
                decimal nKredit = 0;

                foreach (var t in order)
                {
                    nJumlah = nJumlah + (t.Debet - t.Kredit);
                    nDebet = nDebet + t.Debet;
                    nKredit = nKredit + t.Kredit;
                }
                
                model.Saldo = nJumlah;
                if (nJumlah == 0)
                {
                    db.GlTransHs.Add(model);

                    foreach (var item in order)
                    {
                        var orderId = Guid.NewGuid();
                        GlTransD O = new GlTransD();
                        O.GlDGd = orderId;
                        O.Keterangan = item.Keterangan;
                        O.Tanggal = model.Tanggal;
                        O.GlAkunID = item.GlAkunID;
                        O.Debet = item.Debet;
                        O.Kredit = item.Kredit;
                        O.Jumlah = item.Debet - item.Kredit;
                        O.GlHGd = cutomerId;
                        db.GlTransDs.Add(O);
                    }
                    db.SaveChanges();
                    result = "Success! Order Is Complete!";
                } else
                {
                    result = "Tidak balance";
                }
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
            var maxlist = db.GlTransHs.Where(x => x.Docno.Substring(0, 7).Equals(xbukti)).ToList();
            if (maxlist != null)
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
            GlTransH arTransH = db.GlTransHs.Find(id);

            if (arTransH == null)
            {
                return HttpNotFound();
            }
            // List<ArTransH> OrderAndDetailList = arTransH;
            

            return View(arTransH);
        }

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlTransH arTransH = db.GlTransHs.Find(id);
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
            GlTransH arTransH = db.GlTransHs.Find(id);
            db.GlTransHs.Remove(arTransH);
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


