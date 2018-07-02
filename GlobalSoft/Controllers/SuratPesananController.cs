﻿using System;
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
    public class SuratPesananController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SuratPesanan
        public ActionResult Index()
        {
            
            var aptTranss2 = db.CbTranss.Include(a => a.AptMarketing).Include(a => a.AptUnit).Include(a => a.AptBayar);
            var aptTranss = from e in aptTranss2
                            where e.AptTrsNo.TransNo.Trim() == "SuratPesanan"
                            select e;


            return View(aptTranss.ToList());
        }

        // GET: SuratPesanan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTrans aptTrans = db.CbTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            return View(aptTrans);
        }

        // GET: SuratPesanan/Create
        public ActionResult Create()
        {
            var maxvalue = db.CbTranss.Max(x => x.NoRef.Substring(0, 7));
            
            string thnbln = DateTime.Now.ToString("yyMM");
            string cNoref = "SP-" + thnbln+maxvalue;
            ViewBag.NoRef = cNoref;

            var unitList = from e in db.AptUnits
                           where e.StatusID == 2
                           select e;
            
            

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName");
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar");
            ViewBag.UnitID = new SelectList(unitList, "UnitID", "UnitNo");
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: SuratPesanan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,Keterangan,Piutang,BayarID,Cicilan")] CbTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                var validUnit = (from e in db.AptUnits
                                 where e.UnitID == aptTrans.UnitID && e.StatusID == 2   //status hold
                                 select e).FirstOrDefault();

                if (validUnit != null)     // jika tidak ketemu dengan unit yang hold
                {

                    
                    aptTrans.TransNoID = 2;        //surat Pesanan Transaksi
                    aptTrans.TglSelesai =  FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal,aptTrans.Cicilan) ;
                    var CekID = db.AptPayments.FirstOrDefault(x => x.PaymentName.Trim() == "Tunai");
                    //                aptTrans.PaymentID 
                    aptTrans.PaymentID = CekID.PaymentID;

                    //update to sold
                    (from u in db.AptUnits
                     where u.UnitID == aptTrans.UnitID
                     select u).ToList().ForEach(x => x.StatusID = 3);

                    db.CbTranss.Add(aptTrans);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "This unit is Not Yet Reservasi!");
                }
            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.PersonID);
            return View(aptTrans);
        }

        // GET: SuratPesanan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTrans aptTrans = db.CbTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.PersonID);
            return View(aptTrans);
        }

        // POST: SuratPesanan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,BayarID,Keterangan,Piutang,Cicilan")] AptTrans aptTrans)
        {
            aptTrans.TransNoID = 2;        //surat Pesanan Transaksi
            aptTrans.TglSelesai = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, aptTrans.Cicilan);
            var CekID = db.AptPayments.FirstOrDefault(x => x.PaymentName.Trim() == "Tunai");
            //                aptTrans.PaymentID 
            aptTrans.PaymentID = CekID.PaymentID;

            if (ModelState.IsValid)
            {
                db.Entry(aptTrans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // GET: SuratPesanan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTrans aptTrans = db.CbTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            return View(aptTrans);
        }

        // POST: SuratPesanan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CbTrans aptTrans = db.CbTranss.Find(id);

            int nRec = (from e in db.CbTranss
                        where e.UnitID == aptTrans.UnitID
                        select e).Count();

            if (nRec == 1)
            {
                (from e in db.AptUnits
                 where e.UnitID == aptTrans.UnitID
                 select e).ToList().ForEach(x => x.StatusID = 2);
            }


            db.CbTranss.Remove(aptTrans);
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

        public ActionResult SPesanan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTrans aptTrans = db.CbTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            var Uangmuka = (from e in db.CbTranss
                            where e.UnitID == aptTrans.UnitID && e.AptTrsNo.TransNo.Trim() == "BookingFee" && e.PersonID == aptTrans.PersonID
                            select e.Payment).Sum();

      
            List<ArPiutang> Transaksi = new List<ArPiutang>();
            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();

            if (aptTrans.AptBayar.CaraBayar.Substring(0, 7) == "Inhouse")
            {
               
                var cekNull = (from e in db.AptSPesanans where e.SPesanan==aptTrans.NoRef select e).Count();
                if (cekNull == 0)
                {
                    decimal PPN = (aptTrans.Piutang * (decimal)0.1);
                    decimal DPP = (aptTrans.Piutang + PPN) - Uangmuka;

                    decimal angsuran = DPP / aptTrans.Cicilan;
                    decimal JumAngsur = 0;


                    var TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);
                    var Ket7 = "Angsuran 7";

                    for (int i = 0; i < aptTrans.Cicilan; i++)
                    {
                        var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, i);
                        //     TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);

                        Transaksi2.Add(new AptSPesanan { SPesanan = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0}", i + 1), Tanggal = TglAngsuran, Jumlah = angsuran, KodeTrans = aptTrans.TransID,Duedate=TglAngsuran });

                        if (i < 7)
                        {
                            Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0}", i + 1), Duedate = TglAngsuran, Tanggal = aptTrans.Tanggal, Jumlah = angsuran });

                        }
                        else if (i >= 7)
                        {

                            Ket7 = string.Format("Angsuran 8 sd {0} dr Tgl {1:d} sd Tgl {2:d}", i + 1, TglAwal, TglAngsuran);
                            JumAngsur = JumAngsur + angsuran;
                        }

                    };
                    Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = Ket7, Duedate = TglAwal, Tanggal = aptTrans.Tanggal, Jumlah = JumAngsur });

                    foreach (var values in Transaksi2)
                    {
                        
                        db.AptSPesanans.Add(values);
                        db.SaveChanges();
                    }
                }
                else
                {
                    var ListTrans = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).ToList();
                    var nTotal = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).Count();

                    int i = 1;
                    decimal JumAngsur = 0;
                    var dTgl1 = DateTime.Now;
                    var dTgl2 = DateTime.Now;
                    string Ket7 = " ";
                    foreach ( var e in ListTrans)
                    {
                        if (i <= 7)
                        {
                            Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = e.Jumlah });

                        }

                        else
                        {
                            if (i==8)
                            {
                                dTgl1 = e.Tanggal;
                                dTgl2 = e.Tanggal;
                            }
                            Ket7 = string.Format("Angsuran 8 sd {0} dr Tgl {1:d} sd Tgl {2:d}", i, dTgl1, e.Tanggal);
                            JumAngsur = JumAngsur + e.Jumlah;
                            if (i == nTotal)
                            {
                                Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = JumAngsur });

                            }
                        }
                        i++;
                    }

                }

            }
            else if (aptTrans.AptBayar.CaraBayar.Substring(0, 3) == "KPR")
            {
                var cekNull = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).Count();
                if (cekNull == 0)
                {

                    decimal PPN = (aptTrans.Piutang * (decimal)0.1);
                    decimal DPP = (aptTrans.Piutang + PPN);
                    decimal DpKPR = (DPP * (aptTrans.AptBayar.Bunga / 100)) - Uangmuka;
                    decimal SisaKPR = DPP - (DPP * (aptTrans.AptBayar.Bunga / 100));

                    decimal angsuran = DpKPR / aptTrans.Cicilan;
                    decimal JumAngsur = 0;
                    var TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);
                    var Ket7 = "Angsuran 7";
                    var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 1);

                    for (int i = 0; i < aptTrans.Cicilan; i++)
                    {
                        TglAngsuran = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, i);
                        //   TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);

                        
                        Transaksi2.Add(new AptSPesanan { SPesanan = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0}", i + 1), Tanggal = TglAngsuran, Jumlah = angsuran, KodeTrans = aptTrans.TransID, Duedate = TglAngsuran });

                        if (i < 7)
                        {
                            Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0}", i + 1), Duedate = TglAngsuran, Tanggal = aptTrans.Tanggal, Jumlah = angsuran });

                        }
                        else if (i >= 7)
                        {

                            Ket7 = string.Format("Angsuran 8 sd {0} dr Tgl {1:d} sd Tgl {2:d}", i + 1, TglAwal, TglAngsuran);
                            JumAngsur = JumAngsur + angsuran;
                        }

                    };
                    Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = Ket7, Duedate = TglAwal, Tanggal = aptTrans.Tanggal, Jumlah = JumAngsur });
                    Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = "Yang Lewat KPA", Duedate = TglAngsuran, Tanggal = aptTrans.Tanggal, Jumlah = SisaKPR });
                    Transaksi2.Add(new AptSPesanan { SPesanan = aptTrans.NoRef, Keterangan = "Yang Lewat KPA", Tanggal = TglAngsuran, Jumlah = SisaKPR, KodeTrans = aptTrans.TransID, Duedate = TglAngsuran });

                    foreach (var values in Transaksi2)
                    {

                        db.AptSPesanans.Add(values);
                        db.SaveChanges();
                    }

                }
                else
                {
                    var ListTrans = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).ToList();
                    var nTotal = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).Count();

                    int i = 1;
                    decimal JumAngsur = 0;
                    var dTgl1 = DateTime.Now;
                    var dTgl2 = DateTime.Now;
                    string Ket7 = " ";
                    foreach (var e in ListTrans)
                    {
                        if (i <= 7)
                        {
                            Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = e.Jumlah });

                        }

                        else
                        {
                            if (i == 8)
                            {
                                dTgl1 = e.Tanggal;
                                dTgl2 = e.Tanggal;
                            }
                            Ket7 = string.Format("Angsuran 8 sd {0} dr Tgl {1:d} sd Tgl {2:d}", i, dTgl1, e.Tanggal);
                            JumAngsur = JumAngsur + e.Jumlah;
                            if (i == (nTotal-1))
                            {
                                Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = JumAngsur });

                            }
                            if (i== nTotal)
                            {
                                Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = e.Jumlah });

                            }
                        }
                        i++;
                    }

                }



            }
            else if (aptTrans.AptBayar.CaraBayar.Substring(0, 4) == "Cash")
            {

            }

            ViewBag.ListTransaksi = Transaksi;

            ViewBag.UangMuka = Uangmuka;
            ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)aptTrans.Piutang);
            var TransUTJ = db.CbTranss.Include(c => c.AptUnit).Include(c => c.AptPayment).Include(c => c.AptTrsNo);
           var ListUangMuka = (from e in TransUTJ
                               where e.UnitID == aptTrans.UnitID && e.AptTrsNo.TransNo.Trim() == "BookingFee" && e.PersonID == aptTrans.PersonID
                               select e).ToList();

            ViewBag.ListUangMuka = ListUangMuka;
            return View(aptTrans);
        }

    }
}
