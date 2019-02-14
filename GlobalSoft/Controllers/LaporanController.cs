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

        public ActionResult LapCBTransaksi()
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
                                   select (b.Terima - b.Bayar)).DefaultIfEmpty(0).Sum();

                decimal tempbank = 0;

                tempbank = saldobf + saldosp + saldocb;

                bank.Add(new CbBank { BankID = bb.BankID, BankName = bb.BankName, BankAccount = bb.BankAccount, Saldo = tempbank });

            }

            //  var banks = bank;

            return View(bank);
        }
        [HttpPost]
        public ActionResult CetakCBTransaksi(DateTime Tanggal1, DateTime Tanggal2, int KodeBank)
        {
            int id = KodeBank;
            ViewBag.Judul = db.CbBanks.Find(id).BankName;

            List<CbTrans> TransDetail = new List<CbTrans>();
            List<CbTrans> Transaksi = new List<CbTrans>();
            //before Tanggal1


            // Piutang = (bf1 + sp1 + cb1) > 0 ? (bf1 + sp1 + cb1) : 0,
            //    Diskon = (bf1 + sp1 + cb1) > 0 ? 0 : (bf1 + sp1 + cb1),




            var bf = (from b in db.CbTranss
                      join y in db.AptPayments on b.PaymentID equals y.PaymentID
                      where y.BankID == id && (Tanggal1 <= b.Tanggal && b.Tanggal <= Tanggal2)
                      select b).ToList();

            var sp = (from b in db.ArTransDs
                      join y in db.ArTransHs on b.ArHGd equals y.ArHGd
                      where y.BankID == id && (Tanggal1 <= y.Tanggal && y.Tanggal <= Tanggal2)
                      select new { y.Tanggal, b.Keterangan, b.SPesananID, b.Bayar, y.Bukti }).ToList();

            var cb = (from b in db.CbTransDs
                      join y in db.CbTransHs
                        on b.GuidCb equals y.GuidCb
                      where y.BankID == id && (Tanggal1 <= y.Tanggal && y.Tanggal <= Tanggal2)
                      select new { y.Tanggal, b.TransNoID, b.Keterangan, b.Terima, b.Bayar, y.Docno }).ToList();



            foreach (var t in bf)
            {
                TransDetail.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.NoRef,
                    Tanggal = t.Tanggal,
                    Keterangan = db.AptTrsNoes.Where(x => x.TransNoID == t.TransNoID).Select(x => x.TransNo).FirstOrDefault(),
                    TransNoID = t.TransNoID,
                    Piutang = t.Payment,
                    Jumlah = t.Payment

                });

            }
            foreach (var t in sp)
            {
                TransDetail.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.Bukti,
                    Tanggal = t.Tanggal,
                    Keterangan = db.AptTrsNoes.Where(r => r.TransNoID == db.AptTranss.Where(y => y.TransID == (db.AptSPesanans.Where(x => x.SPesananID == t.SPesananID).Select(x => x.KodeTrans).FirstOrDefault())).Select(y => y.TransNoID).FirstOrDefault()).Select(r => r.TransNo).FirstOrDefault(),
                    TransNoID = db.AptTranss.Where(y => y.TransID == (db.AptSPesanans.Where(x => x.SPesananID == t.SPesananID).Select(x => x.KodeTrans).FirstOrDefault())).Select(y =>y.TransNoID).FirstOrDefault(),
                    Piutang = t.Bayar,
                    Jumlah = t.Bayar
                });

            }
            //antara tanggal

            foreach (var t in cb)
            {
                TransDetail.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.Docno,
                    Tanggal = t.Tanggal,
                    Keterangan = db.AptTrsNoes.Where(x => x.TransNoID == t.TransNoID).Select(x => x.TransNo).FirstOrDefault(),
                    TransNoID = t.TransNoID,
                    Piutang = t.Terima,
                    Diskon = t.Bayar,
                    Jumlah = t.Terima - t.Bayar
                });

            }

            Transaksi = TransDetail.ToList();

            ViewBag.Tgl1 = Tanggal1;
            ViewBag.Tgl2 = Tanggal2;
            ViewBag.Kode = KodeBank;

            return View(Transaksi.ToList());
        }

        public ActionResult LapBukuBesar()
        {
            List<SelectListItem> akunGl = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Kode Akun---",
                    Value = "0"
                }
            };
            var dbakun = db.GlAccounts.OrderBy(x => x.GlAkun).ToList();

            foreach (var i in dbakun)
            {
                akunGl.Add(new SelectListItem() { Text = i.GlAkun + " - " + i.GlAkunName, Value = i.GlAkunID.ToString() });
            }

            ViewBag.GlAkunID1 = akunGl;
            ViewBag.GlAkunID2 = akunGl;

            return View();
        }

        [HttpPost]
        public ActionResult CetakBukuBesar(DateTime Tanggal1, DateTime Tanggal2, int GlAkunID1, int GlAkunID2)
        {
         //   var glAwal = db.GlAccounts.Find(GlAkunID1).GlAkun;
         //   var glakhir = db.GlAccounts.Find(GlAkunID2).GlAkun;

            List<GlAccount> TransGl = db.GlAccounts.OrderBy(x => x.GlAkun).ToList();
            List<TrsnoVM> BukuBesar = new List<TrsnoVM>();
        
            foreach (var i in TransGl)
            {
                
               
             //   if (i.GlAkunID >= GlAkunID1 && i.GlAkunID <= GlAkunID2)
            //    {
                    // Saldo awal
                    BukuBesar.Add(new TrsnoVM { GlAkunID = i.GlAkunID, GlAkun = i.GlAkun, GlAkunName = i.GlAkunName,Sisa = SaldoAwalBK(i.GlAkunID, Tanggal1),Piutang= DebetBK(i.GlAkunID, Tanggal1,Tanggal2), Pembayaran= KreditBK(i.GlAkunID, Tanggal1,Tanggal2) });

             //   }
            }
            

            ViewBag.Tgl1 = Tanggal1;
            ViewBag.Tgl2 = Tanggal2;
            return View(BukuBesar.ToList());
        }

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
                                   select (b.Terima - b.Bayar)).DefaultIfEmpty(0).Sum();

                decimal tempbank = 0;

                tempbank = saldobf + saldosp + saldocb;

                bank.Add(new CbBank { BankID = bb.BankID, BankName = bb.BankName, BankAccount = bb.BankAccount, Saldo = tempbank });

            }

            //  var banks = bank;

            return View(bank);
        }

        [HttpPost]
        public ActionResult Cetak(DateTime Tanggal1, DateTime Tanggal2, int KodeBank)
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
                       select b.Terima - b.Bayar).DefaultIfEmpty(0).Sum();


            Transaksi.Add(new CbTrans
            {
                BankID = id,
                NoRef = "",
                Tanggal = Tanggal1,
                Keterangan = "Saldo Awal",
                TransNoID = 0,
                Jumlah = (bf1 + sp1 + cb1)
            });
            // Piutang = (bf1 + sp1 + cb1) > 0 ? (bf1 + sp1 + cb1) : 0,
            //    Diskon = (bf1 + sp1 + cb1) > 0 ? 0 : (bf1 + sp1 + cb1),




            var bf = (from b in db.CbTranss
                      join y in db.AptPayments on b.PaymentID equals y.PaymentID
                      where y.BankID == id && ( Tanggal1 <= b.Tanggal && b.Tanggal <= Tanggal2)
                      select b).ToList();

            var sp = (from b in db.ArTransDs
                      join y in db.ArTransHs on b.ArHGd equals y.ArHGd
                      where y.BankID == id && (Tanggal1 <= y.Tanggal && y.Tanggal <= Tanggal2)
                      select new { y.Tanggal, b.Keterangan, b.SPesananID, b.Bayar, y.Bukti }).ToList();

            var cb = (from b in db.CbTransDs
                      join y in db.CbTransHs
                        on b.GuidCb equals y.GuidCb
                      where y.BankID == id && (Tanggal1 <= y.Tanggal && y.Tanggal <= Tanggal2)
                      select new { y.Tanggal, b.TransNoID, b.Keterangan, b.Terima, b.Bayar, y.Docno }).ToList();

        

            foreach (var t in bf)
            {
                Transaksi.Add(new CbTrans
                {
                    BankID = id,
                    NoRef = t.NoRef,
                    Tanggal = t.Tanggal,
                    Keterangan = t.Keterangan,
                    TransNoID = t.TransNoID,
                    Piutang = t.Payment,
                    Jumlah = t.Payment

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
                    TransNoID = db.AptSPesanans.Where(x => x.SPesananID == t.SPesananID).Select(x => x.KodeTrans).FirstOrDefault(),
                    Piutang = t.Bayar,
                    Jumlah = t.Bayar
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
                    Diskon = t.Bayar,
                    Jumlah = t.Terima - t.Bayar
                });

            }
            ViewBag.Tgl1 = Tanggal1;
            ViewBag.Tgl2 = Tanggal2;
            ViewBag.Kode = KodeBank;

            return View(Transaksi.OrderBy(x => x.Tanggal));
        }

        


        public decimal SaldoAwalBK(int glAkun, DateTime Tgl1)
        {


            List<TrsnoVM> glBK = new List<TrsnoVM>();


            // posisi kredit booking fee 
            decimal saldobf1 = (from b in db.CbTranss
                                join y in db.ArCustomers on b.PersonID equals y.CustomerID
                                join t in db.ArAkunSets on y.AkunSetID equals t.AkunsetID
                                where b.Tanggal < Tgl1 && t.GlAkunID2 == glAkun
                                select b.Payment).DefaultIfEmpty(0).Sum();

            //posisi debet booking fee
            decimal saldobf2 = (from b in db.CbTranss
                                join y in db.AptPayments on b.PaymentID equals y.PaymentID
                                join t in db.CbBanks on y.BankID equals t.BankID
                                where b.Tanggal < Tgl1 && t.GlAkunID == glAkun
                                select b.Payment).DefaultIfEmpty(0).Sum();

            // posisi kredit pembayaran Angsuran
            //   decimal saldosp1 = (from b in db.ArTransDs
            //                        join y in db.ArTransHs
            //                          on b.ArHGd equals y.ArHGd                                                               
            //                     where y.Tanggal < Tgl1
            //                       select b.Bayar,b.CustomerID);

            var listsp = (from b in db.ArTransDs
                          join y in db.ArTransHs
                          on b.ArHGd equals y.ArHGd
                          where y.Tanggal < Tgl1
                          select new { b.Bayar, b.CustomerID }).ToList();

            // posisi kredit
            decimal saldosp1 = (from b in db.ArTransDs
                                join y in db.ArTransHs on b.ArHGd equals y.ArHGd
                                join t in db.ArCustomers on y.CustomerID equals t.CustomerID
                                join u in db.ArAkunSets on t.AkunSetID equals u.AkunsetID
                                where y.Tanggal < Tgl1 && u.GlAkunID3 == glAkun
                                select b.Bayar).DefaultIfEmpty(0).Sum();


            //posisi debet pembayaran Angsuran
            decimal saldosp2 = (from b in db.ArTransDs
                                join y in db.ArTransHs on b.ArHGd equals y.ArHGd
                                join t in db.CbBanks on y.BankID equals t.BankID
                                where y.Tanggal < Tgl1 && t.GlAccount.GlAkunID == glAkun
                                select b.Bayar).DefaultIfEmpty(0).Sum();


            // posisi kredit 
            decimal saldocb1 = 0;    //kredit
            decimal saldocb2 = 0;    //debet
            decimal saldotot = 0;

            // transaksi
            saldotot = (from b in db.CbTransDs
                        join y in db.CbTransHs on b.GuidCb equals y.GuidCb
                        join r in db.CbBanks on y.BankID equals r.BankID
                        where y.Tanggal < Tgl1 && r.GlAkunID == glAkun

                        select (b.Terima - b.Bayar)).DefaultIfEmpty(0).Sum();

            if (saldotot > 0)
            {
                saldocb1 += saldotot;
            }
            else
            {
                saldocb2 += saldotot;
            }

            saldotot = (from b in db.CbTransDs
                        join y in db.CbTransHs on b.GuidCb equals y.GuidCb
                        join r in db.AptTrsNoes on b.TransNoID equals r.TransNoID
                        where y.Tanggal < Tgl1 && r.GlAkunID == glAkun

                        select (b.Terima - b.Bayar)).DefaultIfEmpty(0).Sum();

            if (saldotot > 0)
            {
                saldocb2 += saldotot;
            }
            else
            {
                saldocb1 += saldotot;
            }

            return (saldobf2 - saldobf1 + saldosp2 - saldosp1 + saldocb2 - saldocb1);
        }


        public decimal DebetBK(int glAkun, DateTime Tgl1, DateTime Tgl2)
        {


            List<TrsnoVM> glBK = new List<TrsnoVM>();


            
            //posisi debet booking fee
            decimal saldobf2 = (from b in db.CbTranss
                                join y in db.AptPayments on b.PaymentID equals y.PaymentID
                                join t in db.CbBanks on y.BankID equals t.BankID
                                where Tgl1 <= b.Tanggal && b.Tanggal <= Tgl2 && t.GlAkunID == glAkun
                                select b.Payment).DefaultIfEmpty(0).Sum();

           


           
            //posisi debet pembayaran Angsuran
            decimal saldosp2 = (from b in db.ArTransDs
                                join y in db.ArTransHs on b.ArHGd equals y.ArHGd
                                join t in db.CbBanks on y.BankID equals t.BankID
                                where Tgl1 <= y.Tanggal && y.Tanggal <= Tgl2 && t.GlAccount.GlAkunID == glAkun
                                select b.Bayar).DefaultIfEmpty(0).Sum();


            // posisi kredit 
            decimal saldocb1 = 0;    //kredit
            decimal saldocb2 = 0;    //debet
            decimal saldotot = 0;

            // transaksi
            saldotot = (from b in db.CbTransDs
                        join y in db.CbTransHs on b.GuidCb equals y.GuidCb
                        join r in db.CbBanks on y.BankID equals r.BankID
                        where Tgl1 <= y.Tanggal && y.Tanggal <= Tgl2 && r.GlAkunID == glAkun

                        select ( b.Terima)).DefaultIfEmpty(0).Sum();

            if (saldotot > 0)
            {
                saldocb2 += saldotot;
            }
            else
            {
                saldocb2 += saldotot;
            }

            saldotot = (from b in db.CbTransDs
                        join y in db.CbTransHs on b.GuidCb equals y.GuidCb
                        join r in db.AptTrsNoes on b.TransNoID equals r.TransNoID
                        where Tgl1 <= y.Tanggal && y.Tanggal <= Tgl2 && r.GlAkunID == glAkun

                        select (b.Bayar)).DefaultIfEmpty(0).Sum();

            if (saldotot > 0)
            {
                saldocb2 += saldotot;
            }
            else
            {
                saldocb1 += saldotot;
            }

            return (saldobf2 + saldosp2  + saldocb2);
        }


        public decimal KreditBK(int glAkun, DateTime Tgl1, DateTime Tgl2)
        {


            List<TrsnoVM> glBK = new List<TrsnoVM>();


            // posisi kredit booking fee 
            decimal saldobf1 = (from b in db.CbTranss
                                join y in db.ArCustomers on b.PersonID equals y.CustomerID
                                join t in db.ArAkunSets on y.AkunSetID equals t.AkunsetID
                                where Tgl1 <= b.Tanggal && b.Tanggal <= Tgl2 && t.GlAkunID2 == glAkun
                                select b.Payment).DefaultIfEmpty(0).Sum();

           
            

          

            // posisi kredit
            decimal saldosp1 = (from b in db.ArTransDs
                                join y in db.ArTransHs on b.ArHGd equals y.ArHGd
                                join t in db.ArCustomers on y.CustomerID equals t.CustomerID
                                join u in db.ArAkunSets on t.AkunSetID equals u.AkunsetID
                                where Tgl1 <= y.Tanggal && y.Tanggal <= Tgl2 && u.GlAkunID3 == glAkun
                                select b.Bayar).DefaultIfEmpty(0).Sum();


           
            // posisi kredit 
            decimal saldocb1 = 0;    //kredit
            decimal saldocb2 = 0;    //debet
            decimal saldotot = 0;

            // transaksi
            saldotot = (from b in db.CbTransDs
                        join y in db.CbTransHs on b.GuidCb equals y.GuidCb
                        join r in db.CbBanks on y.BankID equals r.BankID
                        where Tgl1 <= y.Tanggal && y.Tanggal <= Tgl2 && r.GlAkunID == glAkun

                        select (b.Bayar )).DefaultIfEmpty(0).Sum();

            if (saldotot > 0)
            {
                saldocb1 += saldotot;
            }
            else
            {
                saldocb2 += saldotot;
            }

            saldotot = (from b in db.CbTransDs
                        join y in db.CbTransHs on b.GuidCb equals y.GuidCb
                        join r in db.AptTrsNoes on b.TransNoID equals r.TransNoID
                        where Tgl1 <= y.Tanggal && y.Tanggal <= Tgl2 && r.GlAkunID == glAkun

                        select ( b.Terima)).DefaultIfEmpty(0).Sum();

            if (saldotot > 0)
            {
                saldocb1 += saldotot;
            }
            else
            {
                saldocb1 += saldotot;
            }

            return ( saldobf1 + saldosp1 + saldocb1);
        }
    }
}