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
    public class BookingFeeController : Controller
    {
        private ApartmentDBContext db = new ApartmentDBContext();

        // GET: BookingFee
        public ActionResult Index()
        {
            var aptTranss2 = db.AptTranss.Include(a => a.AptMarketing).Include(a => a.AptPayment).Include(a => a.AptUnit).Include(a => a.ArCustomer);
            var aptTranss = from e in aptTranss2
                            where e.AptUnit.StatusID == 2
                            select e;
            return View(aptTranss.ToList());
        }

        // GET: BookingFee/Details/5
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

        // GET: BookingFee/Create
        public ActionResult Create()
        {
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName");
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName");
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo");
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: BookingFee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,Keterangan,Payment,PaymentID,TransNo")] AptTrans aptTrans)
        {
            
            if (ModelState.IsValid)
            {

                var validUnit = (from e in db.AptUnits
                                where e.UnitID == aptTrans.UnitID  &&  e.StatusID==3
                                select e).FirstOrDefault();

               // var validUnit = (from x in db.Units where x.UnitId == rental.UnitId && x.Status != 2 select x).FirstOrDefault();
                //var dulpliUser = from x in db.Rentals where x.UnitId==rental.UnitId&&x.User.UserName == rental.User.UserName select x;
                //var dulpliUser = (from x in db.Rentals where x.UnitId == rental.UnitId && x.User.UserName.Equals(rental.User.UserName) select x).Count();


                if (validUnit == null)     // jika tidak ketemu dengan unit yang sold
                {
                    aptTrans.TransNo = 1;        //booking fee Transaksi
                    aptTrans.TglSelesai = aptTrans.Tanggal;

                    db.AptTranss.Add(aptTrans);

                    //update to hold
                    (from u in db.AptUnits
                     where u.UnitID == aptTrans.UnitID
                     select u).ToList().ForEach(x => x.StatusID = 2);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "This unit is Sold!");
                }
            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // GET: BookingFee/Edit/5
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

        // POST: BookingFee/Edit/5
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

        // GET: BookingFee/Delete/5
        public ActionResult Delete(int? id)
        {
            var test = from e in db.AptUnits
                       where e.StatusID == 3 && e.UnitID == id   // jika sudah laku tidak bisa dihapus transaksinya
                       select e;

            if (test== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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

        // POST: BookingFee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptTrans aptTrans = db.AptTranss.Find(id);
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
    }
}
