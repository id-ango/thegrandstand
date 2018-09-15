using System;
using System.Collections.Generic;
using System.Data;
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
    public class LaporanController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: Laporan
        public ActionResult RekKoran()
        {
            var banks = db.CbBanks.ToList();
            
            return View(banks);
        }
        
    
        public ActionResult Cetak(int id)
        {
            ViewBag.Judul = db.CbBanks.Find(id).BankName;
            //before Tanggal1

    /*        var bf1 = (from b in db.CbTranss
                       join y in db.AptPayments
                        on b.PaymentID equals y.PaymentID
                       where y.BankID == id && b.Tanggal < DateTime.Now
                      select b.Payment).Sum();

            var sp1 = (from b in db.ArTransDs
                       join y in db.ArTransHs
                         on b.ArHGd equals y.ArHGd
                       where y.BankID == id && b.Tanggal < DateTime.Now
                       select b.Bayar).Sum();

    */


            var bf = (from b in db.CbTranss join y in db.AptPayments
                      on b.PaymentID equals y.PaymentID
                      where y.BankID == id select b).ToList();

            var sp = (from b in db.ArTransDs join y in db.ArTransHs
                        on b.ArHGd equals y.ArHGd
                      where y.BankID == id select new { b.Tanggal,b.Keterangan,b.SPesananID,b.Bayar, y.Bukti }).ToList();

            List<CbTrans> Transaksi = new List<CbTrans>();

            foreach (var t in bf)
            {
                Transaksi.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.NoRef,
                    Tanggal = t.Tanggal,
                    Keterangan = t.Keterangan,
                    TransNoID = t.TransNoID,
                    Piutang = t.Payment
                   
                    
                });
                
            }
            foreach (var t in sp)
            {
                Transaksi.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.Bukti,
                    Tanggal = t.Tanggal,
                    Keterangan = t.Keterangan,
                    TransNoID = db.AptSPesanans.Where(x =>x.SPesananID == t.SPesananID).Select(x =>x.KodeTrans).FirstOrDefault(),
                    Piutang = t.Bayar
                });

            }
            //antara tanggal
                   
            return View(Transaksi.OrderBy(x => x.Tanggal));
        }
    }
}