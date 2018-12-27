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

            var kodeno = "SP-";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno + thnbln;
            var maxvalue = "";
            var maxlist = db.AptTranss.Where(x => x.NoRef.Substring(0, 7).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.NoRef);

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

            int nRec = (from e in db.CbTranss
                        where e.UnitID == aptTrans.UnitID
                        select e).Count();

            if (nRec == 1)
            {
                (from e in db.AptUnits
                 where e.UnitID == aptTrans.UnitID
                 select e).ToList().ForEach(x => x.StatusID = 2);
            }
            List<AptSPesanan> aptsp = db.AptSPesanans.Where(e => e.KodeTrans == aptTrans.TransID).ToList();
            foreach (var i in aptsp)
                db.AptSPesanans.Remove(i);

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

        public ActionResult SPesanan(int? id)
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
            var ListUM = (from e in db.CbTranss
                          where e.UnitID == aptTrans.UnitID && e.PersonID == aptTrans.CustomerID
                          select e.Payment).ToList();

            var unitNo = db.AptUnits.Find(aptTrans.UnitID).UnitNo;

            decimal Uangmuka = 0;

            if (ListUM != null)
            {
                Uangmuka = ListUM.Sum();
            }


            List<ArPiutang> Transaksi = new List<ArPiutang>();
            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();

            if (aptTrans.AptBayar.CaraBayar.Contains("InHouse"))
            {

                var cekNull = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).Count();
                if (cekNull == 0)
                {
                    //decimal PPN = (aptTrans.Piutang * (decimal)0.1);
                    decimal PPN = 0;
                    decimal DPP = (aptTrans.Piutang + PPN) - Uangmuka;

                    decimal angsuran = aptTrans.Angsuran;
                    decimal JumAngsur = 0;


                    var TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 6);
                    var Ket7 = "Angsuran 6";

                    for (int i = 0; i < aptTrans.Cicilan; i++)
                    {
                        var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, i);
                        //     TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);

                        Transaksi2.Add(new AptSPesanan { SPesanan = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, unitNo), Tanggal = TglAngsuran, Jumlah = angsuran, KodeTrans = aptTrans.TransID, Duedate = TglAngsuran });

                        if (i < 6)
                        {
                            Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, unitNo), Duedate = TglAngsuran, Tanggal = aptTrans.Tanggal, Jumlah = angsuran });

                        }
                        else if (i >= 6)
                        {

                            Ket7 = string.Format("Angsuran  sd {0} dr Tgl {1:d} sd Tgl {2:d}", i + 1, TglAwal, TglAngsuran);
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
                    foreach (var e in ListTrans)
                    {
                        if (i <= 6)
                        {
                            Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = e.Jumlah });

                        }

                        else
                        {
                            if (i == 7)
                            {
                                dTgl1 = e.Tanggal;
                                dTgl2 = e.Tanggal;
                            }
                            Ket7 = string.Format("Angsuran   sd {0} dr Tgl {1:d} sd Tgl {2:d}", i, dTgl1, e.Tanggal);
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
            else if (aptTrans.AptBayar.CaraBayar.Contains("KPA"))
            {
                var cekNull = (from e in db.AptSPesanans where e.SPesanan == aptTrans.NoRef select e).Count();
                if (cekNull == 0)
                {

                    // decimal PPN = (aptTrans.Piutang * (decimal)0.1);
                    decimal PPN = 0;
                    decimal DPP = (aptTrans.Piutang + PPN);
                    decimal DpKPR = (DPP * (aptTrans.AptBayar.Bunga / 100)) - Uangmuka;
                    //decimal SisaKPR = DPP - (DPP * (aptTrans.AptBayar.Bunga / 100));
                    decimal SisaKPR = aptTrans.Harga;

                    //decimal angsuran = DpKPR / aptTrans.Cicilan;
                    decimal angsuran = aptTrans.Angsuran;
                    decimal JumAngsur = 0;
                    var TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 6);
                    var Ket7 = "Angsuran 6";
                    var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 1);

                    for (int i = 0; i < aptTrans.Cicilan; i++)
                    {
                        TglAngsuran = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, i);
                        //   TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);


                        Transaksi2.Add(new AptSPesanan { SPesanan = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, unitNo), Tanggal = TglAngsuran, Jumlah = angsuran, KodeTrans = aptTrans.TransID, Duedate = TglAngsuran });

                        if (i < 6)
                        {
                            Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, unitNo), Duedate = TglAngsuran, Tanggal = aptTrans.Tanggal, Jumlah = angsuran });

                        }
                        else if (i >= 6)
                        {

                            Ket7 = string.Format("Angsuran  sd {0} dr Tgl {1:d} sd Tgl {2:d}", i + 1, TglAwal, TglAngsuran);
                            JumAngsur = JumAngsur + angsuran;
                        }

                    };
                    Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = Ket7, Duedate = TglAwal, Tanggal = aptTrans.Tanggal, Jumlah = JumAngsur });
                    Transaksi.Add(new ArPiutang { LPB = aptTrans.NoRef, Keterangan = "Dengan KPA", Duedate = TglAngsuran, Tanggal = aptTrans.Tanggal, Jumlah = SisaKPR });
                    Transaksi2.Add(new AptSPesanan { SPesanan = aptTrans.NoRef, Keterangan = "Dengan KPA", Tanggal = TglAngsuran, Jumlah = SisaKPR, KodeTrans = aptTrans.TransID, Duedate = TglAngsuran });

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
                        if (i <= 6)
                        {
                            Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = e.Jumlah });

                        }

                        else
                        {
                            if (i == 7)
                            {
                                dTgl1 = e.Tanggal;
                                dTgl2 = e.Tanggal;
                            }
                            Ket7 = string.Format("Angsuran  sd {0} dr Tgl {1:d} sd Tgl {2:d}", i, dTgl1, e.Tanggal);
                            JumAngsur = JumAngsur + e.Jumlah;
                            if (i == (nTotal - 1))
                            {
                                Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = JumAngsur });

                            }
                            if (i == nTotal)
                            {
                                Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Tanggal, Tanggal = aptTrans.Tanggal, Jumlah = e.Jumlah });

                            }
                        }
                        i++;
                    }

                }



            }
            else if (aptTrans.AptBayar.CaraBayar.Contains("Cash"))
            {

            }

            ViewBag.ListTransaksi = Transaksi;

            ViewBag.UangMuka = Uangmuka;
            ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)aptTrans.Piutang);
            var TransUTJ = db.CbTranss.Include(c => c.AptUnit).Include(c => c.AptPayment).Include(c => c.AptTrsNo);
            var ListUangMuka = (from e in TransUTJ
                                where e.UnitID == aptTrans.UnitID && e.PersonID == aptTrans.CustomerID
                                select e).ToList();

            ViewBag.ListUangMuka = ListUangMuka;
            return View(aptTrans);
        }

        public ActionResult Proses(int? id)
        {
            var aptTranss2 = (from e in db.AptSPesanans
                              where e.KodeTrans == id && (e.Jumlah - e.Bayar - e.Diskon) != 0
                              select e).ToList();


            return View(aptTranss2.ToList());

        }
        [HttpPost]
        public ActionResult Saveuser(int id, string propertyName, string value)
        {
            var status = false;
            var message = "";

            //Update data to database 
            using (GlobalsoftDBContext dc = new GlobalsoftDBContext())
            {
                var Pesanan = dc.AptSPesanans.Find(id);

                object updateValue = value;
                bool isValid = true;

                if (propertyName == "DueDate")
                {
                    DateTime dob;
                    if (DateTime.TryParseExact(value, "dd-MM-yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out dob))
                    {
                        updateValue = dob;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                if (propertyName == "Jumlah")
                {
                    Decimal Jumlah;
                    if (Decimal.TryParse(value, out Jumlah))
                    {
                        updateValue = Jumlah;
                    }
                    else
                    {
                        isValid = false;
                    }
                }

                if (Pesanan != null && isValid)
                {
                    dc.Entry(Pesanan).Property(propertyName).CurrentValue = updateValue;
                    dc.SaveChanges();
                    status = true;
                }
                else
                {
                    message = "Error!";
                }
            }

            var response = new { value = value, status = status, message = message };
            JObject o = JObject.FromObject(response);
            return Content(o.ToString());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GETSubType(string Typeid)
        {
            var listCust = (from e in db.CbTranss
                            where e.AptUnit.UnitNo.Trim() == Typeid
                            select new
                            {
                                e.UnitID
                            });



            return Json(listCust, JsonRequestBehavior.AllowGet);

        }

        public ActionResult PesananInHouse(int Unitid, int Custid, string UnitNo, decimal angsuran, DateTime tanggal, int cicilan, string noref)
        {


            var Tanggal = Convert.ToDateTime(tanggal);


            var ListUM = (from e in db.CbTranss
                          where e.UnitID == Unitid && e.PersonID == Custid
                          select e.Payment).ToList();



            decimal Uangmuka = 0;

            if (ListUM != null)
            {
                Uangmuka = ListUM.Sum();
            }


            List<ArPiutang> Transaksi = new List<ArPiutang>();
            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();



            //decimal PPN = (aptTrans.Piutang * (decimal)0.1);
            //  decimal PPN = 0;
            //   decimal DPP = (aptTrans.Piutang + PPN) - Uangmuka;




            var TglAwal = FungsiController.Fungsi.HitungAngsuran(Tanggal, 6);


            for (int i = 0; i < cicilan; i++)
            {
                var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(Tanggal, i);
                //     TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);

                Transaksi2.Add(new AptSPesanan { SPesanan = noref, Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, UnitNo), Tanggal = TglAngsuran, Jumlah = angsuran, KodeTrans = 1, Duedate = TglAngsuran });

            };

            return Json(Transaksi2, JsonRequestBehavior.AllowGet);
        }


    }
}
