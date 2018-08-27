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

        public ActionResult SaveOrder(string docno, String keterangan, CbTransD[] order)
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


    }
}


