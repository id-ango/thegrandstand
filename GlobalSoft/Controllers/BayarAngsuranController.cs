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
    public class BayarAngsuranController : Controller
    {
        // GET: BayarAngsuran
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        public ActionResult Index()
        {
            
            return View(db.PiutangMains.ToList());
        }
        
        public ActionResult Create()
        {
            // var maxvalue = db.AptTranss.Max(x =>  x.NoRef.Substring(0, 10));
          
            string thnbln = DateTime.Now.ToString("yyMM");
            var maxvalue = (from e in db.PiutangMains where e.NoBukti.Substring(0, 7) == "ANG" + thnbln select e).FirstOrDefault();
            string nourut = "000";
            if (maxvalue == null)
            {
                nourut = "000";
            }  else
            {
                nourut = maxvalue.NoBukti.Substring(7, 3);
            }
            
           //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);
           
            



            string cAngNo = "ANG" + thnbln+ (Int32.Parse(nourut) + 1).ToString("000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            string cNoref = cAngNo;
            ViewBag.NoRef = cNoref;
            ViewBag.Tanggal = DateTime.Now;
            var unitList = from e in db.AptUnits
                           where e.StatusID == 3
                           select e;



            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName");
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar");
            ViewBag.UnitID = new SelectList(unitList, "UnitID", "UnitNo");
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = " NoBukti,Tanggal,CustomerID,Keterangan")] PiutangMain piutangMain,List<PiutangDetail> piutangDetail )
        {
            if (ModelState.IsValid)
            {
                db.PiutangMains.Add(piutangMain);
                db.SaveChanges();
                foreach (var e in piutangDetail)
                {
                    if (e.Bayar !=0 || e.Diskon!=0)
                    {
                        db.PiutangDetails.Add(e);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            var unitList = from e in db.AptUnits
                           where e.StatusID == 3
                           select e;

            
       //     ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", piutangMain.UnitID);
       //     ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", piutangMain.CustomerID);
            return View(piutangMain);
        }

        public ActionResult DetailAngsuran(int Custid,int Unitid)
        {

            var allList = (from e in db.AptTranss
                           join
                           y in db.AptSPesanans on e.NoRef equals y.SPesanan
                           where e.CustomerID == Custid
                           select new
                           { e.UnitID, e.AptUnit.UnitNo,e.CustomerID,e.ArCustomer.CustomerName,y.SPesananID,y.SPesanan,y.Duedate,
                               y.Keterangan,
                               y.Jumlah,y.Bayar,y.Diskon,y.Sisa
                           });

            if (Custid !=  0)
            {
                allList = (from e in db.AptTranss
                           join
                           y in db.AptSPesanans on e.NoRef equals y.SPesanan
                           where e.CustomerID == Custid
                           select new
                           {
                               e.UnitID,
                               e.AptUnit.UnitNo,
                               e.CustomerID,
                               e.ArCustomer.CustomerName,                               
                               y.SPesananID,
                               y.SPesanan,
                               y.Duedate,
                               y.Keterangan,
                               y.Jumlah,
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
                           select new
                           {
                               e.UnitID,
                               e.AptUnit.UnitNo,
                               e.CustomerID,
                               e.ArCustomer.CustomerName,                               
                               y.SPesananID,
                               y.SPesanan,
                               y.Duedate,
                               y.Keterangan,
                               y.Jumlah,
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
                Transaksi.Add(new PiutangDetail { UnitID = i.UnitID, UnitNo=i.UnitNo, CustomerID=i.CustomerID,
                    CustomerName =i.CustomerName,SPesananID = i.SPesananID, SPesanan = i.SPesanan, Duedate = i.Duedate,
                    Keterangan = i.Keterangan, Piutang = i.Jumlah, Bayar = i.Bayar, Diskon = i.Diskon,
                    Sisa = i.Jumlah - i.Bayar - i.Diskon });
                //    Transaksi.Add(new PiutangDetail { SPesanan = i.NoRef, Duedate = i.Tanggal, Keterangan = i.Keterangan, Piutang = i.Piutang, Bayar = i.Payment });
            }
            return PartialView(Transaksi);
        }
    }
}


