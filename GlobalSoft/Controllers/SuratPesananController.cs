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
    public class SuratPesananController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        public ActionResult CekCustomer(int Custid, int Unitid)
        {
            var allList2 = (from e in db.CbTranss
                            where e.UnitID == Unitid
                            select new { e.PersonID, e.MarketingID }).ToList().LastOrDefault();

            decimal Book1 = 0;

            Book1 = (from e in db.CbTranss
                     where (e.UnitID == Unitid && e.PersonID == allList2.PersonID) && (e.TransNoID == 1 || e.TransNoID == 2)
                     select e.Payment).Sum();


            CbTrans allList = new CbTrans();
            allList.PersonID = allList2.PersonID;
            allList.MarketingID = allList2.MarketingID;
            allList.Piutang = Book1;

            return Json(allList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CekBook(int Custid, int Unitid, decimal harga, int cicil)
        {
            decimal Book1 = 0;
            Book1 = (from e in db.CbTranss
                     where (e.UnitID == Unitid && e.PersonID == Custid) && (e.TransNoID == 1 || e.TransNoID == 2)
                     select e.Payment).Sum();

            AptTrans allList = new AptTrans();


            decimal total = (harga - Book1) / cicil;
            Console.Write(Book1);
            Console.WriteLine(total);

            allList.Payment = total;
            allList.Harga = (harga - Book1);
            allList.Piutang = Book1;

            return Json(allList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CekUM(int Custid, int Unitid)
        {
            //  var TransUTJ = db.CbTranss.Include(c => c.AptUnit).Include(c => c.AptPayment).Include(c => c.AptTrsNo);
            var ListUangMuka = (from e in db.CbTranss
                                where e.UnitID == Unitid && e.PersonID == Custid
                                select new { e.Keterangan, e.Payment, e.NoRef, e.AptPayment.PaymentName, e.Tanggal }).ToList();
            return Json(ListUangMuka, JsonRequestBehavior.AllowGet);
        }

        // GET: SuratPesanan
        public ActionResult Index()
        {
            var aptTranss2 = db.AptTranss.Include(a => a.AptMarketing).Include(a => a.AptUnit).Include(a => a.AptBayar);
            var aptTranss = from e in aptTranss2
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
            AptTrans aptTrans = db.AptTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            return View(aptTrans);
        }

        // GET: SuratPesanan/Create

        public ActionResult Create()
        {


            var unitList = from e in db.AptUnits
                           where e.StatusID == 2
                           select e;

            var kodeno = "SP-788";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno;  //   + thnbln;
            var maxvalue = "";
            var maxlist = db.AptTranss.Where(x => x.NoRef.Substring(0, 6).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.NoRef);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "0000";
            if (maxvalue == null)
            {
                nourut = "0000";
            }
            else
            {
                nourut = maxvalue.Substring(6, 4);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeno  + (Int32.Parse(nourut) + 1).ToString("0000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            string cNoref = cAngNo;

            ViewBag.NoRef = cNoref;

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
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,Keterangan,Angsuran,Piutang,Harga,BayarID,Cicilan")] AptTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                var validUnit = (from e in db.AptUnits
                                 where e.UnitID == aptTrans.UnitID && e.StatusID == 2   //status hold
                                 select e).FirstOrDefault();

                if (validUnit != null)     // jika tidak ketemu dengan unit yang hold
                {


                    aptTrans.TransNoID = 2;        //surat Pesanan Transaksi
                    aptTrans.TglSelesai = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, aptTrans.Cicilan);
                    //var CekID = db.AptPayments.FirstOrDefault(x => x.PaymentName.Trim() == "Tunai");
                    //                aptTrans.PaymentID 
                    aptTrans.PaymentID = 1;

                    //update to sold
                    (from u in db.AptUnits
                     where u.UnitID == aptTrans.UnitID
                     select u).ToList().ForEach(x => x.StatusID = 3);

                    db.AptTranss.Add(aptTrans);
                    //   db.SaveChanges();
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
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // GET: SuratPesanan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrans aptTrans = db.AptTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // POST: SuratPesanan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,BayarID,Keterangan,Piutang,Angsuran,Harga,Cicilan")] AptTrans aptTrans)
        {
            aptTrans.TransNoID = 2;        //surat Pesanan Transaksi
            aptTrans.TglSelesai = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, aptTrans.Cicilan);
            // var CekID = db.AptPayments.FirstOrDefault(x => x.PaymentName.Trim() == "Tunai");
            //                aptTrans.PaymentID 
            aptTrans.PaymentID = 1;

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
            AptTrans aptTrans = db.AptTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            return View(aptTrans);
        }

        // POST: SuratPesanan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]        
        public ActionResult DeleteConfirmed(int id)
        {
            AptTrans aptTrans = db.AptTranss.Find(id);

           // int nRec = (from e in db.CbTranss
           //             where e.UnitID == aptTrans.UnitID
           //             select e).Count();

            db.AptUnits.Find(aptTrans.UnitID).StatusID = 2;

           // if (nRec != 0)
           // {
           //     (from e in db.AptUnits
           //      where e.UnitID == aptTrans.UnitID
           //      select e).ToList().ForEach(x => x.StatusID = 2);
           // }
            List<AptSPesanan> aptsp = db.AptSPesanans.Where(e => e.SPesanan == aptTrans.NoRef).ToList();
           // foreach (var i in aptsp)
           //     db.AptSPesanans.Remove(i);
            db.AptSPesanans.RemoveRange(aptsp);
            db.AptTranss.Remove(aptTrans);
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

        public ActionResult SPesanan(string noref,int cetak)
        {
            AptTrans TransSP = (from e in db.AptTranss
                                where e.NoRef == noref
                                select e).FirstOrDefault();

            int Unitid = TransSP.UnitID;
            int Custid = TransSP.CustomerID;
            int ref_menu = TransSP.BayarID;


            var ListUangMuka = (from e in db.CbTranss
                                where e.UnitID == Unitid && e.PersonID == Custid
                                select e).ToList();

            var unitNo = db.AptUnits.Find(Unitid).UnitNo;

            decimal Uangmuka = 0;

            if (ListUangMuka != null)
            {
                Uangmuka = ListUangMuka.Sum(x => x.Payment);
            }

            ViewBag.Carabayar = ref_menu == 1 ? "InHouse" : "KPA";

            List<ArPiutang> Transaksi = new List<ArPiutang>();

            decimal JumAngsur = 0;
            decimal Total = 0;

            var cekNull = (from e in db.AptSPesanans where e.SPesanan == noref select e).Count();
            if (cekNull != 0)
            {
                var ListTrans = (from e in db.AptSPesanans where e.SPesanan == noref select e).ToList();


                int i = 1;
              
                var dTgl1 = DateTime.Now;
                var dTgl2 = DateTime.Now;
                string Ket7 = " ";
                foreach (var e in ListTrans)
                {
                    Total += e.Jumlah;
                    if (cetak != 3)
                    {
                        if (i <= 6)
                        {
                            Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = e.Jumlah });

                        }

                        else
                        {
                            JumAngsur = JumAngsur + e.Jumlah;

                            if (i == 7)
                            {
                                Ket7 = string.Format("{0} dr Tgl {1:d} ", e.Keterangan.Trim(), e.Duedate);

                            }

                            switch (ref_menu)
                            {
                                case 1:
                                    if (i == cekNull)
                                    {
                                        Ket7 = Ket7 + string.Format("sd {0} ", e.Keterangan.Trim());
                                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = JumAngsur });

                                    };
                                    break;
                                case 2:
                                    if (i == (cekNull - 1))
                                    {
                                        Ket7 = Ket7 + string.Format("sd {0} ", e.Keterangan.Trim());
                                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = JumAngsur });

                                    };
                                    if (i == cekNull)
                                    {
                                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = e.Jumlah });

                                    };
                                    break;
                            }



                        }
                    }
                    else
                    {
                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = e.Jumlah });

                    }
                    i++;
                }

            }




            ViewBag.ListTransaksi = Transaksi;

            ViewBag.UangMuka = Uangmuka;
                   ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)TransSP.Harga);
            var TransUTJ = db.CbTranss.Include(c => c.AptUnit).Include(c => c.AptPayment).Include(c => c.AptTrsNo);


            ViewBag.ListUangMuka = ListUangMuka;

            if (cetak == 1)
                return Json("Success", JsonRequestBehavior.AllowGet);

            return View(TransSP);
        }



        public ActionResult PesananInHouse(int Unitid, int Custid, string UnitNo, decimal angsuran, DateTime tanggal, int cicilan, decimal sisakpa, string ref_this)
        {


            //  var Tanggal = Convert.ToDateTime(tanggal);
            var Tanggal = tanggal;

            //  List<ArPiutang> Transaksi = new List<ArPiutang>();
            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();



            //decimal PPN = (aptTrans.Piutang * (decimal)0.1);
            //  decimal PPN = 0;
            //   decimal DPP = (aptTrans.Piutang + PPN) - Uangmuka;




            //    var TglAwal = FungsiController.Fungsi.HitungAngsuran(Tanggal, 6);


            for (int i = 0; i < cicilan; i++)
            {
                var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(Tanggal, i);
                //     TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);

                Transaksi2.Add(new AptSPesanan { Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, UnitNo), Tanggal = TglAngsuran, Jumlah = angsuran });

            };
            if (ref_this == "#menu2")
            {
                var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(Tanggal, cicilan);
                Transaksi2.Add(new AptSPesanan { Keterangan = string.Format("KPA Unit {0}", UnitNo), Tanggal = TglAngsuran, Jumlah = sisakpa });

            }
            return PartialView(Transaksi2);
        }
      

        public ActionResult SaveOrder(string bukti, string keterangan, string tanggal, int row_num, int row_cust,
                    int marketing, decimal harga1, decimal piutang1, int cicil1, decimal angsuran1,
                    decimal harga2, decimal piutang2, int cicil2, decimal angsuran2, decimal sisakpa,
                    string ref_this, SpesananVM[] order)
        {
            string result = "Error! Surat Pesanan Is Not Complete!";
            AptTrans model = new AptTrans();

            if (bukti != null && order != null)
            {



                //   var cutomerId = Guid.NewGuid();

                var CutomerId = Guid.NewGuid();

                model.SpesananGd = CutomerId;
                model.NoRef = bukti;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                model.TglSelesai = Convert.ToDateTime(tanggal);              
                model.UnitID = row_num;
                model.CustomerID = row_cust;
                model.MarketingID = marketing;
                model.TransNoID = 1;
                if (ref_this == "#menu1")
                {
                    model.Harga = harga1;
                    model.Piutang = piutang1;
                    model.Angsuran = angsuran1;
                    model.Cicilan = cicil1;
                    model.Payment = 0;
                    model.PaymentID = 2;
                    model.BayarID = 1;
                }
                else
                {
                    model.Harga = harga2;
                    model.Piutang = piutang2;
                    model.Angsuran = angsuran2;
                    model.Cicilan = cicil2;
                    model.Payment = sisakpa;
                    model.PaymentID = 2;
                    model.BayarID = 2;
                }

                //       db.AptTranss.Add(model);

                foreach (var item in order)
                {
                    if (item.Jumlah != 0)
                    {

                        AptSPesanan O = new AptSPesanan();
                        O.SPesanan = model.NoRef;
                        O.SpesananGd = CutomerId;
                        O.Keterangan = item.Keterangan;
                        O.Tanggal = Convert.ToDateTime(tanggal);
                        O.Duedate = Convert.ToDateTime(item.Duedate);
                        O.Jumlah = item.Jumlah;
                        O.KodeTrans = 0;
                        db.AptSPesanans.Add(O);

                        model.TglSelesai = Convert.ToDateTime(item.Duedate);
                    }
                }

                db.AptTranss.Add(model);

                //update to sold

                db.AptUnits.Find(row_num).StatusID = 3;

                db.SaveChanges();
                result = "Success! Pembayaran Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditPesanan(string noref)
        {

          var  Transaksi = (from e in db.AptSPesanans
                              where e.SPesanan == noref
                              select new {
                                  e.SPesananID,
                                  e.Duedate,
                                  e.Keterangan,
                                  Sisa = db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                  Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                  e.SpesananGd                                  
                              }).ToList();

            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();

            foreach (var i in Transaksi)
            {
                if (i.Sisa == 0)
                {
                    Transaksi2.Add(new AptSPesanan
                    {

                        SPesananID = i.SPesananID,
                        Duedate = i.Duedate,
                        Keterangan = i.Keterangan,
                        Jumlah = i.Jumlah,
                        SpesananGd = i.SpesananGd

                    });
                }
            }
                return PartialView(Transaksi2);
        }

        public ActionResult SimpanEdit(string bukti, string keterangan, string tanggal, int row_num, int row_cust,
             int marketing, int carabayar, decimal harga, AptSPesanan[] order)
        {
            string result = "Error! Surat Pesanan Is Not Complete!";
            AptTrans model = new AptTrans();

            if (bukti != null && order != null)
            {
                (from y in db.AptTranss
                  where y.NoRef == bukti
                  select y).ToList().ForEach(x => { x.Tanggal = Convert.ToDateTime(tanggal); x.Keterangan = keterangan; x.BayarID = carabayar; x.Harga = harga; });

                var Transaksi = (from e in db.AptSPesanans
                                 where e.SPesanan == bukti
                                 select new
                                 {
                                     e.SPesananID,
                                     e.Duedate,
                                     e.Keterangan,                                     
                                     Sisa = db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                     Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                     e.SpesananGd
                                 }).ToList();

                List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();

                foreach (var i in Transaksi)
                {
                    if (i.Sisa == 0)
                    {
                        Transaksi2.Add(new AptSPesanan
                        {

                            SPesananID = i.SPesananID,
                            Duedate = i.Duedate,
                            Keterangan = i.Keterangan,
                            Jumlah = i.Jumlah,
                            SpesananGd = i.SpesananGd

                        });
                    }
                }


                foreach (var e in Transaksi2)
                {
                   AptSPesanan MauHapus =  db.AptSPesanans.Find(e.SPesananID);
                    db.AptSPesanans.Remove(MauHapus);
                }
                

                db.SaveChanges();
              
                foreach (var e in order)
                {
                   // (from y in db.AptSPesanans
                   //  where y.SPesananID == e.SPesananID
                   //  select y).ToList().ForEach(x => { x.Tanggal = Convert.ToDateTime(tanggal); x.Keterangan = keterangan; });

                   
                    AptSPesanan O = new AptSPesanan();
                    O.SpesananGd = e.SpesananGd;
                    O.Keterangan = e.Keterangan;
                    O.Duedate = e.Duedate;
                    O.Jumlah = e.Jumlah;
                    O.Tanggal = Convert.ToDateTime(tanggal);
                    O.SPesanan = bukti;
                    db.AptSPesanans.Add(O);
                }
                db.SaveChanges();

            }
               

                //   var cutomerId = Guid.NewGuid();

                
                result = "Success! Edit Pembayaran Is Complete!";
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
