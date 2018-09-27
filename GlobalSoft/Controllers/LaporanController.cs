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
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class LaporanController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: Laporan
        public ActionResult RekKoran()
        {

            List<CbBank> bank = new List<CbBank>();
            

            foreach (var bb in db.CbBanks)
            {
                decimal saldobf = (from b in db.CbTranss
                          join y in db.AptPayments
                             on b.PaymentID equals y.PaymentID
                          where y.BankID == bb.BankID
                          select b.Payment).DefaultIfEmpty(0).Sum();

                decimal saldosp = (from b in db.ArTransDs
                          join y in db.ArTransHs
                             on b.ArHGd equals y.ArHGd
                          where y.BankID == bb.BankID
                          select b.Bayar).DefaultIfEmpty(0).Sum();

                decimal saldocb = (from b in db.CbTransDs
                          join y in db.CbTransHs
                            on b.GuidCb equals y.GuidCb
                          where y.BankID == bb.BankID
                          select (b.Terima- b.Bayar)).DefaultIfEmpty(0).Sum();

               decimal tempbank = 0;

                tempbank = saldobf + saldosp + saldocb;

                bank.Add(new CbBank { BankID = bb.BankID, BankName = bb.BankName, BankAccount = bb.BankAccount, Saldo = tempbank });

            }

          //  var banks = bank;
            
            return View(bank);
        }
        
        [HttpGet]
        public ActionResult Cetak(DateTime Tanggal1,DateTime Tanggal2,int KodeBank)
        {
            int id = KodeBank;
            ViewBag.Judul = db.CbBanks.Find(id).BankName;

            List<CbTrans> Transaksi = new List<CbTrans>();
            //before Tanggal1

            var bf1 = (from b in db.CbTranss
                       join y in db.AptPayments
                        on b.PaymentID equals y.PaymentID
                       where y.BankID == id && b.Tanggal < Tanggal1
                      select b.Payment).DefaultIfEmpty(0).Sum();

            var sp1 = (from b in db.ArTransDs
                       join y in db.ArTransHs
                         on b.ArHGd equals y.ArHGd
                       where y.BankID == id && b.Tanggal < Tanggal1
                       select b.Bayar).DefaultIfEmpty(0).Sum();

            var cb1 = (from b in db.CbTransDs
                      join y in db.CbTransHs
                        on b.GuidCb equals y.GuidCb
                      where y.BankID == id && b.Tanggal < Tanggal1 
                      select   b.Terima - b.Bayar).DefaultIfEmpty(0).Sum();


            Transaksi.Add(new CbTrans
            {
                BankID = id,
                NoRef = "------",
                Tanggal = Tanggal1,
                Keterangan = "Saldo Awal",
                TransNoID = 0,
                Piutang = (bf1 + sp1 + cb1) > 0 ? (bf1 + sp1 + cb1) : 0,
                Diskon  = (bf1 + sp1 + cb1) > 0 ? 0 : (bf1 + sp1 + cb1)
            });

            
            


            var bf = (from b in db.CbTranss join y in db.AptPayments
                      on b.PaymentID equals y.PaymentID
                      where y.BankID == id && (b.Tanggal >= Tanggal1 && b.Tanggal<= Tanggal2) select b).ToList();

            var sp = (from b in db.ArTransDs join y in db.ArTransHs
                        on b.ArHGd equals y.ArHGd
                      where y.BankID == id && (b.Tanggal >= Tanggal1 && b.Tanggal <= Tanggal2)
                      select new { b.Tanggal,b.Keterangan,b.SPesananID,b.Bayar, y.Bukti }).ToList();

            var cb = (from b in db.CbTransDs
                      join y in db.CbTransHs
                        on b.GuidCb equals y.GuidCb
                      where y.BankID == id && (b.Tanggal >= Tanggal1 && b.Tanggal <= Tanggal2)
                      select new { y.Tanggal,b.TransNoID, b.Keterangan, b.Terima, b.Bayar, y.Docno }).ToList();

           

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

            foreach (var t in cb)
            {
                Transaksi.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.Docno,
                    Tanggal = t.Tanggal,
                    Keterangan = t.Keterangan,
                    TransNoID = t.TransNoID,
                    Piutang = t.Terima,
                    Diskon = t.Bayar
                });

            }
            ViewBag.Tgl1 = Tanggal1;
            ViewBag.Tgl2 = Tanggal2;
            ViewBag.Kode = KodeBank;

            return View(Transaksi.OrderBy(x => x.Tanggal));
        }
    }
}