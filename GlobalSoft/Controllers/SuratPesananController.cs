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
    public class SuratPesananController : Controller
    {
        private ApartmentDBContext db = new ApartmentDBContext();

        // GET: SuratPesanan
        public ActionResult Index()
        {
            var aptTranss2 = db.AptTranss.Include(a => a.AptMarketing).Include(a => a.AptPayment).Include(a => a.AptUnit).Include(a => a.ArCustomer);
            var aptTranss = from e in aptTranss2
                            where e.TransNo == 2
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
            List<SelectListItem> CaraBayar = new List<SelectListItem>();
            CaraBayar.Add(new SelectListItem { Value = "1", Text = "Angsuran" });
            CaraBayar.Add(new SelectListItem { Value = "2", Text = "KPA" });
            CaraBayar.Add(new SelectListItem { Value = "3", Text = "Cash Keras" });

            var unitList = from e in db.AptUnits
                           where e.StatusID == 2
                           select e;

            ViewBag.CaraBayar = CaraBayar;
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName");
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName");
            ViewBag.UnitID = new SelectList(unitList, "UnitID", "UnitNo");
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: SuratPesanan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,Keterangan,CaraBayar,TglSelesai,Cicilan,TransNo")] AptTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                var validUnit = (from e in db.AptUnits
                                 where e.UnitID == aptTrans.UnitID && e.StatusID == 2   //status hold
                                 select e).FirstOrDefault();

                if (validUnit != null)     // jika tidak ketemu dengan unit yang hold
                {

                    
                    aptTrans.TransNo = 2;        //surat Pesanan Transaksi
                    aptTrans.TglSelesai =  FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal,aptTrans.Cicilan) ;
                    aptTrans.PaymentID = 1;


                    //update to sold
                    (from u in db.AptUnits
                     where u.UnitID == aptTrans.UnitID
                     select u).ToList().ForEach(x => x.StatusID = 3);

                    db.AptTranss.Add(aptTrans);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "This unit is Not Yet Reservasi!");
                }
            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
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
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // POST: SuratPesanan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,Keterangan,Payment,PaymentID,TglSelesai,Cicilan,TransNo")] AptTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptTrans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
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
        public ActionResult DeleteConfirmed(int id)
        {
            AptTrans aptTrans = db.AptTranss.Find(id);

            int nRec = (from e in db.AptTranss
                        where e.UnitID == aptTrans.UnitID
                        select e).Count();

            if (nRec == 1)
            {
                (from e in db.AptUnits
                 where e.UnitID == aptTrans.UnitID
                 select e).ToList().ForEach(x => x.StatusID = 2);
            }


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
            ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)aptTrans.Piutang);

            return View(aptTrans);
        }


    }
}
