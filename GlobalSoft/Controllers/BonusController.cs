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
    public class BonusController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: BookingFee
        public ActionResult Index()
        {
            var aptTranss2 = db.CbTranss.Include(a => a.AptMarketing).Include(a => a.AptPayment).Include(a => a.AptUnit);
         
            var Booking = (from e in aptTranss2         
                           join y in db.ArCustomers 
                           on e.PersonID equals y.CustomerID
                           where e.TransNoID == 2
                            select new  { e.TransID,e.NoRef,e.Tanggal,e.UnitID,e.AptUnit.UnitNo,e.AptPayment.PaymentName,
                                e.AptMarketing.MarketingName,e.AptMarketing.AptAgen.AgenName,e.PersonID,y.CustomerName,e.Keterangan,e.PaymentID,e.Payment,e.MarketingID }).ToList();

            List<BookViewsModels> cbViews = new List<BookViewsModels>();
                 foreach (var e in Booking)
            {
                cbViews.Add(new BookViewsModels { TransID = e.TransID,
                    NoRef = e.NoRef,
                    Tanggal = e.Tanggal,
                    UnitID = e.UnitID,
                    UnitNo = e.UnitNo,
                    CustomerID = e.PersonID,
                    CustomerName = e.CustomerName,
                    MarketingID = e.MarketingID,
                    MarketingName = e.MarketingName,
                    AgenName = e.AgenName,
                    Keterangan = e.Keterangan,
                    Payment = e.Payment,
                    PaymentID = e.PaymentID,
                    PaymentName = e.PaymentName});
            }
                    
            
            return View(cbViews.ToList());
        }

        // GET: BookingFee/Details/5
        public ActionResult Details(int? id)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            CbTrans cbTrans = db.CbTranss.Find(id);
            if (cbTrans == null)
            {
                return HttpNotFound();
            }
            var NamaCustomer = (from e in db.ArCustomers                                              
                           where e.CustomerID == cbTrans.PersonID
                           select e).First().CustomerName;

            ViewBag.NamaCustomer = NamaCustomer;

            return View(cbTrans);
        }

        // GET: BookingFee/Create
        public ActionResult Create()
        {
            //   int maxvalue = 0;
            //   var Cekvalue = (from a in db.AptUruts where a.TipeTrans == 1 select a).FirstOrDefault();
            //    if (Cekvalue != null)
            //   {
            //        maxvalue = (from a in db.AptUruts where a.TipeTrans == 1 select a).FirstOrDefault().NoUrut;
            //    }
            //    else
            //    {
            //        AptUrut TipeGl = new AptUrut { TipeTrans = 1, NoUrut=0,Tanggal=DateTime.Now};
            //        db.AptUruts.Add(TipeGl);
            //        db.SaveChanges();

            //     }

            var unitList = from e in db.AptUnits
                           where e.StatusID == 2
                           select e;

            var kodeno = "BN-";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno + thnbln;
            var maxvalue = "";
            var maxlist = db.CbTranss.Where(x => x.NoRef.Substring(0, 7).Equals(xbukti)).ToList();
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
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName");
            ViewBag.UnitID = new SelectList(unitList, "UnitID", "UnitNo");
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: BookingFee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,PersonID,MarketingID,Keterangan,Payment,PaymentID,TransNoID")] CbTrans cbTrans)
        {
            
            if (ModelState.IsValid)
            {

                var validUnit = (from e in db.AptUnits
                                where e.UnitID == cbTrans.UnitID  &&  e.StatusID==3
                                select e).FirstOrDefault();

               // var validUnit = (from x in db.Units where x.UnitId == rental.UnitId && x.Status != 2 select x).FirstOrDefault();
                //var dulpliUser = from x in db.Rentals where x.UnitId==rental.UnitId&&x.User.UserName == rental.User.UserName select x;
                //var dulpliUser = (from x in db.Rentals where x.UnitId == rental.UnitId && x.User.UserName.Equals(rental.User.UserName) select x).Count();

                if (validUnit == null)  // berarti unit ini  dalam posisi hold
                {
                    cbTrans.TransNoID = 2;        //Bonus Transaksi
                    cbTrans.TglSelesai = cbTrans.Tanggal;
                    cbTrans.BayarID = 1;

                    db.CbTranss.Add(cbTrans);
                    
                    //update to hold
               //     (from u in db.AptUnits
               //      where u.UnitID == cbTrans.UnitID
               //      select u).ToList().ForEach(x => x.StatusID = 2);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("", "This unit is already Sold!");
                }


            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", cbTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", cbTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", cbTrans.UnitID);
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", cbTrans.PersonID);
            return View(cbTrans);
        }

        // GET: BookingFee/Edit/5
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
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.PersonID);
            return View(aptTrans);
        }

        // POST: BookingFee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,NoRef,Tanggal,UnitID,PersonID,MarketingID,Keterangan,Payment,PaymentID")] CbTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                aptTrans.TransNoID = 2;        //Booking Transaksi
                aptTrans.TglSelesai = aptTrans.Tanggal;
                aptTrans.BayarID = 1;
                
                db.Entry(aptTrans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.PersonID);
            return View(aptTrans);
        }

        // GET: BookingFee/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CbTrans aptTrans = db.CbTranss.Find(id);

            var test = (from e in db.AptUnits
                       where e.StatusID == 3 && e.UnitID == aptTrans.UnitID   // jika sudah laku tidak bisa dihapus transaksinya
                       select e).ToList().Count();

            if (test != 0)
            {
                // TempData["msg"] = "<script>alert('Change succesfully');</script>";
             //   return JavaScript(alert("Hello this is an alert"));
                return Content("<script language='javascript' type='text/javascript'>alert('Sudah ada Transaksi SP, tidak bisa dihapus!');</script>");
                //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   // ada revisi untuk messagenya
            }

            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            var NamaCustomer = (from e in db.ArCustomers
                                where e.CustomerID == aptTrans.PersonID
                                select e).First().CustomerName;

            ViewBag.NamaCustomer = NamaCustomer;

            return View(aptTrans);
        }

        // POST: BookingFee/Delete/5
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
                 select e).ToList().ForEach(x => x.StatusID = 1);
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

        public ActionResult TandaTerima(int? id)
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

            var NamaCustomer = (from e in db.ArCustomers
                                where e.CustomerID == aptTrans.PersonID
                                select e).First().CustomerName;

            ViewBag.NamaCustomer = NamaCustomer;

            return View(aptTrans);
        }
    }
}
