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
    public class TransBankController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();
        // GET: TransBank
        public ActionResult Index()
        {

            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            ViewBag.TransNoID = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            List<CbTransH> OrderAndDetailList = db.CbTransHs.ToList();
            return View(OrderAndDetailList);
        }

        public ActionResult SaveOrder(string docno, String keterangan,int bank, CbTransD[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (docno != null && keterangan != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                CbTransH model = new CbTransH();
                model.GuidCb = cutomerId;
                model.Docno = docno;
                model.Keterangan = keterangan;
                model.Tanggal = DateTime.Now;
                model.BankID = bank;
                db.CbTransHs.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    CbTransD O = new CbTransD();
                    O.GuidDb = orderId;
                    O.Keterangan = item.Keterangan;
                    O.Tanggal = DateTime.Now;
                    O.TransNoID = 1;
                    O.Terima = item.Terima;
                    O.Bayar = item.Bayar;
                    O.Jumlah = item.Jumlah;
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
            string result = "Error! Order Is Not Complete!";

            // var maxvalue = db.AptTranss.Max(x =>  x.NoRef.Substring(0, 10));

            string thnbln = DateTime.Now.ToString("yyMM");
            var maxvalue = (from e in db.CbTransHs where e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "000";
            if (maxvalue == null)
            {
                nourut = "000";
            }
            else
            {
                nourut = maxvalue.Docno.Substring(7, 3);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeno + thnbln + (Int32.Parse(nourut) + 1).ToString("000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            string cNoref = cAngNo;

            result = "Success! Order Is Complete!";
            return Json(cAngNo, JsonRequestBehavior.AllowGet);
        }
    }
}


