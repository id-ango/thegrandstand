using System;
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
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class TransAngsuranController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();



        // GET: TransAngsuran
        public ActionResult Index()
        {
            var Transaksi = (from e in db.ArTransHs
                             join y in db.ArCustomers on e.CustomerID equals y.CustomerID
                             select new ArHView
                             {
                                 ArHID = e.ArHID,
                                 Bukti = e.Bukti,
                                 Tanggal = e.Tanggal,
                                 BankID = e.BankID,
                                 BankName = (from r in db.CbBanks where r.BankID == e.BankID select r.BankName).FirstOrDefault(),
                                 //                                BankName = db.CbBanks.Where(h =>h.BankID == e.BankID).FirstOrDefault(),
                                 CustomerID = e.CustomerID,
                                 CustomerName = y.CustomerName,
                                 Keterangan = e.Keterangan,
                                 Jumlah = e.Jumlah
                             });



            return View(Transaksi);
        }

        // GET: TransAngsuran/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransH arTransH = db.ArTransHs.Find(id);

            if (arTransH == null)
            {
                return HttpNotFound();
            }
            // List<ArTransH> OrderAndDetailList = arTransH;
            ViewBag.Bank = db.CbBanks.Find(arTransH.BankID).BankName;
            ViewBag.Customer = db.ArCustomers.Find(arTransH.CustomerID).CustomerName;
            ViewBag.TransNo = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            return View(arTransH);
        }

        // GET: TransAngsuran/Create
        public ActionResult Create()
        {
            var kodeno = "BM-";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno + thnbln;
            var maxvalue = "";
            var maxlist = db.ArTransHs.Where(x => x.Bukti.Substring(0, 7).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.Bukti);

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
            ViewBag.NoRef = cAngNo;
            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: TransAngsuran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        /*      [HttpPost]
              [ValidateAntiForgeryToken]
              public ActionResult Create([Bind(Include = "ArHID,ArHGd,Bukti,Tanggal,BankID,CustomerID,MarketingID,UnitID,Keterangan,JthTempo,Jumlah,Piutang,Unapplied,Diskon")] ArTransH arTransH)
              {
                  if (ModelState.IsValid)
                  {
                      db.ArTransHs.Add(arTransH);
                      db.SaveChanges();
                      return RedirectToAction("Index");
                  }

                  return View(arTransH);
              }
      */
        // GET: TransAngsuran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransH arTransH = db.ArTransHs.Find(id);
            if (arTransH == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bank = db.CbBanks.Find(arTransH.BankID).BankName;
            ViewBag.Customer = db.ArCustomers.Find(arTransH.CustomerID).CustomerName;
            ViewBag.TransNo = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            return View(arTransH);
        }

        // POST: TransAngsuran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArHID,ArHGd,Bukti,Tanggal,BankID,CustomerID,MarketingID,UnitID,Keterangan,JthTempo,Jumlah,Piutang,Unapplied,Diskon")] ArTransH arTransH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arTransH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arTransH);
        }

        // GET: TransAngsuran/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArTransH arTransH = db.ArTransHs.Find(id);
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
            ArTransH arTransH = db.ArTransHs.Find(id);
            db.ArTransHs.Remove(arTransH);
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

        public ActionResult DetailAngsuran(int Custid, int Unitid)
        {

            var allList = (from e in db.AptTranss
                           join
                           y in db.AptSPesanans on e.NoRef equals y.SPesanan
                           where e.CustomerID == Custid
                           orderby y.Duedate
                           select new
                           {
                               e.UnitID,
                               e.AptUnit.UnitNo,
                               e.CustomerID,
                               e.ArCustomer.CustomerName,
                               e.Piutang,
                               y.SPesananID,
                               y.SPesanan,
                               y.Duedate,
                               y.Keterangan,
                               Jumlah = y.Jumlah - db.ArTransDs.Where(x => x.SPesananID == y.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                               y.Bayar,
                               y.Diskon,
                               y.Sisa
                           });

            if (Custid != 0)
            {
                allList = (from e in db.AptTranss
                           join
                           y in db.AptSPesanans on e.NoRef equals y.SPesanan
                           where e.CustomerID == Custid
                           orderby y.Duedate
                           select new
                           {
                               e.UnitID,
                               e.AptUnit.UnitNo,
                               e.CustomerID,
                               e.ArCustomer.CustomerName,
                               e.Piutang,
                               y.SPesananID,
                               y.SPesanan,
                               y.Duedate,
                               y.Keterangan,
                               Jumlah = y.Jumlah - db.ArTransDs.Where(x => x.SPesananID == y.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                               y.Bayar,
                               y.Diskon,
                               y.Sisa
                           });
            }
            else
            {
                allList = (from e in db.AptTranss
                           join
                           y in db.AptSPesanans on e.NoRef equals y.SPesanan
                           where e.UnitID == Unitid
                           orderby y.Duedate
                           select new
                           {
                               e.UnitID,
                               e.AptUnit.UnitNo,
                               e.CustomerID,
                               e.ArCustomer.CustomerName,
                               e.Piutang,
                               y.SPesananID,
                               y.SPesanan,
                               y.Duedate,
                               y.Keterangan,
                               Jumlah = y.Jumlah - db.ArTransDs.Where(x => x.SPesananID == y.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                               y.Bayar,
                               y.Diskon,
                               y.Sisa
                           });
            }

            //   var allList = db.AptSPesanans.Where(x => x.AptTrans.CustomerID == Custid && (x.Jumlah-x.Bayar-x.Diskon)!=0).ToList();
            // && (x.Jumlah-x.Bayar-x.Diskon)!=0
            // var ListTrans = db.AptTranss.Where(x=>x.CustomerID==Custid).ToList();
            //   var allList = db.AptSPesanans.Where(x => x.AptTrans.CustomerID == Custid).ToList();
            //           TglString = Convert.ToDateTime(e.Tanggal).ToString("dd-MM-yyyy")

            List<PiutangDetail> Transaksi = new List<PiutangDetail>();
            foreach (var i in allList)
            {
                if (i.Jumlah != 0)
                {
                    Transaksi.Add(new PiutangDetail
                    {
                        UnitID = i.UnitID,
                        UnitNo = i.UnitNo,
                        CustomerID = i.CustomerID,
                        CustomerName = i.CustomerName,
                        SPesananID = i.SPesananID,
                        SPesanan = i.SPesanan,
                        Duedate = i.Duedate,
                        Keterangan = i.Keterangan,
                        Piutang = i.Jumlah,
                        Bayar = i.Bayar,
                        Diskon = i.Diskon,
                        Sisa = i.Jumlah - i.Bayar - i.Diskon
                    });
                }
                //    Transaksi.Add(new PiutangDetail { SPesanan = i.NoRef, Duedate = i.Tanggal, Keterangan = i.Keterangan, Piutang = i.Piutang, Bayar = i.Payment });
            }
            return PartialView(Transaksi);
        }

        public ActionResult SaveOrder(string bukti, String keterangan, string tanggal, int bank, int customer, ArTransD[] order)
        {
            string result = "Error! Pembayaran Is Not Complete!";
            if (bukti != null && keterangan != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                ArTransH model = new ArTransH();
                model.ArHGd = cutomerId;
                model.Bukti = bukti;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                model.BankID = bank;
                model.CustomerID = customer;
                decimal nJumlah = 0;
                decimal nDiskon = 0;

                foreach (var t in order)
                {
                    nJumlah = nJumlah + (t.Bayar);
                    nDiskon = nDiskon + t.Diskon;
                }

                model.Jumlah = nJumlah;
                model.Diskon = nDiskon;
                db.ArTransHs.Add(model);

                foreach (var item in order)
                {
                    if (item.Bayar != 0 || item.Diskon != 0)
                    {
                        var orderId = Guid.NewGuid();
                        ArTransD O = new ArTransD();
                        O.ArDGd = orderId;
                        O.Keterangan = item.Keterangan;
                        O.Tanggal = model.Tanggal;
                        O.Duedate = Convert.ToDateTime(item.Duedate);
                        O.SPesananID = item.SPesananID;
                        O.CustomerID = item.CustomerID;
                        O.Piutang = item.Piutang;
                        O.Bayar = item.Bayar;
                        O.Diskon = item.Diskon;
                        O.Sisa = item.Sisa;
                        O.ArHGd = cutomerId;
                        db.ArTransDs.Add(O);


                    }
                }


                db.SaveChanges();
                result = "Success! Pembayaran Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult BuktiTerima(string noref, int cetak)
        {
            List<ArDView> TransD = new List<ArDView>();

            var Transaksi = (from e in db.ArTransHs
                             join y in db.ArCustomers on e.CustomerID equals y.CustomerID
                             where e.Bukti == noref
                             select new ArHView
                             {
                                 ArHID = e.ArHID,
                                 ArHGd = e.ArHGd,
                                 Bukti = e.Bukti,
                                 Tanggal = e.Tanggal,
                                 BankID = e.BankID,
                                 BankName = (from r in db.CbBanks where r.BankID == e.BankID select r.BankName).FirstOrDefault(),
                                 //                                BankName = db.CbBanks.Where(h =>h.BankID == e.BankID).FirstOrDefault(),
                                 CustomerID = e.CustomerID,
                                 CustomerName = y.CustomerName,
                                 Alamat = y.AlamatSekarang,
                                 Keterangan = e.Keterangan,
                                 Jumlah = e.Jumlah,
                             }).FirstOrDefault();


            var Detail = (from e in db.ArTransDs where e.ArHGd == Transaksi.ArHGd select e).ToList();

            foreach (var item in Detail)
            {
                TransD.Add(new ArDView
                {


                    Keterangan = item.Keterangan,
                    Tanggal = item.Tanggal,
                    Duedate = item.Duedate,
                    SPesananID = item.SPesananID,
                    CustomerID = item.CustomerID,
                    Piutang = item.Piutang,
                    Bayar = item.Bayar,
                    Diskon = item.Diskon,
                    Sisa = item.Sisa
                });

            }
            Transaksi.TransDetail = TransD;
            ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)Transaksi.Jumlah);
            if (cetak == 1)
                return Json("Success", JsonRequestBehavior.AllowGet);

          
            return View(Transaksi);
        }

        public ActionResult DisplayManager()
        {
            return View();
        }

        public ActionResult Menu1(string tanggal)
        {
            var duedate = Convert.ToDateTime(tanggal);
            duedate = duedate.AddDays(2);
         
                     var allList = (from e in db.AptSPesanans 
                                    join y in db.AptTranss on e.SPesanan equals y.NoRef
                           where (e.Duedate == duedate)                          
                           select new
                           {
                               e.Duedate,
                               e.Keterangan,                               
                               y.ArCustomer.CustomerName,                               
                               e.SPesanan,
                               Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID ).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                              
                           }).ToList();
            return Json(allList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Menu2(string tanggal)
        {
            var duedate = Convert.ToDateTime(tanggal);
            duedate = duedate.AddDays(1);

            var allList = (from e in db.AptSPesanans
                           join y in db.AptTranss on e.SPesanan equals y.NoRef
                           where (e.Duedate == duedate)
                           select new
                           {
                               e.Duedate,
                               e.Keterangan,
                               y.ArCustomer.CustomerName,
                               e.SPesanan,
                               Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID ).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),

                           }).ToList();
            return Json(allList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Menu3(string tanggal)
        {
            var duedate = Convert.ToDateTime(tanggal);
            //duedate = duedate.AddDays(2);

            var allList = (from e in db.AptSPesanans
                           join y in db.AptTranss on e.SPesanan equals y.NoRef
                           where (e.Duedate == duedate)
                           select new
                           {
                               e.Duedate,
                               e.Keterangan,
                               y.ArCustomer.CustomerName,
                               e.SPesanan,
                               Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),

                           }).ToList();
            return Json(allList, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Menu4(string tanggal)
        {
            var duedate = Convert.ToDateTime(tanggal);
           // Duedate = duedate.AddDays(2);

            var allList = (from e in db.AptSPesanans
                           join y in db.AptTranss on e.SPesanan equals y.NoRef
                           where (e.Duedate < duedate)
                           select new
                           {
                               e.Duedate,
                               e.Keterangan,
                               y.ArCustomer.CustomerName,
                               e.SPesanan,
                               Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),

                           }).ToList();
            
            return Json(allList, JsonRequestBehavior.AllowGet);

        }
    }
}
