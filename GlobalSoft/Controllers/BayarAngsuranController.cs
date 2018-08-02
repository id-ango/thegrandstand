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
    public class BayarAngsuranController : Controller
    {
        // GET: BayarAngsuran
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        public ActionResult Index()
        {
            var aptTranss2 = db.PiutangMains.Include(a => a.AptUnit).Include(a => a.ArCustomer);

            return View(aptTranss2.ToList());
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

       
        public ActionResult PiutangDetail(int? i)
        {
            ViewBag.i = i;
            return PartialView();
        }

        public ActionResult DetailAngsuran(int? i)
        {
            ViewBag.i = i;
            return PartialView();
        }
    }
}


