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
    public class SetupMarketingController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupMarketing
        public ActionResult Index()
        {
            List<AptMarketing> TipeGl = new List<AptMarketing>();

            TipeGl.Add(new AptMarketing { KodeMarketing = "10001", AgenID = 1, MarketingName = "YANTH", Alamat = "SURABAYA", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10002", AgenID = 1, MarketingName = "ACI", Alamat = "  PUNCAK KERTAJAYA SURABAYA", Phone = "081222223027" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10003", AgenID = 1, MarketingName = "BAMBANG", Alamat = "RUKO PLASA SEGI 8 BLOK A NO 810 SURABAYA", Phone = "083876118198" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10004", AgenID = 1, MarketingName = "LIEM IVO VERONICA SWIEJAYA", Alamat = "citrawandutamulia@yahoo.com", Phone = "085230003233" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10005", AgenID = 1, MarketingName = "NITA RIVIDA", Alamat = "SURABAYA", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10006", AgenID = 1, MarketingName = "Bpk Candra S", Alamat = "", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10007", AgenID = 1, MarketingName = "ERLINDA WONGSO", Alamat = " SURABAYA", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10008", AgenID = 1, MarketingName = "WELLY TUNGGAL", Alamat = " tongwelly@yahoo.com", Phone = "081221345777" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10009", AgenID = 1, MarketingName = "PATRICK", Alamat = "patrickjs.propnex@yahoo.com", Phone = "08118880067" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10010", AgenID = 1, MarketingName = "MARIYATI", Alamat = "", Phone = "081336476292" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10011", AgenID = 1, MarketingName = "GANDA SAPUTRA", Alamat = "stefanus.ganda@gmail.com", Phone = "0811335323" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10012", AgenID = 1, MarketingName = "VICKY WIRONTONO SUSENO", Alamat = " KANTOR : XM 1ST HOME EASTLEAD AGEN : XM VISIONVickyws @live.com", Phone = "08170717262" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10013", AgenID = 1, MarketingName = "Bpk HENRY", Alamat = "", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10014", AgenID = 1, MarketingName = "KEZIA HANDAYANI", Alamat = "", Phone = "0818576020" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10015", AgenID = 1, MarketingName = "ZAHRIDA DINNANDA PARAMESWARI", Alamat = "  ZAHRIDA.PARAMESWARI@GMAIL.COM", Phone = "081234128532" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10016", AgenID = 1, MarketingName = "ERRY SOEWITO", Alamat = "  BUMIARJO 3/7 SURABAYA", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10017", AgenID = 1, MarketingName = "DEWI", Alamat = "", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10018", AgenID = 1, MarketingName = "SRI DWI YANTI", Alamat = "  BABATAN INDAH A13/4", Phone = "081515227772" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10019", AgenID = 1, MarketingName = "YONI ALWI HASAN", Alamat = "  JL BERINGIN 1 GEDANGAN", Phone = "081334262929" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "10020", AgenID = 1, MarketingName = "APRIMA LINA PRIBADI", Alamat = "  KEDUNG KLINTER 1/32 A", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "C0001", AgenID = 1, MarketingName = "CYNTHIA M TOMASOA", Alamat = "  GRIYA BABATAN MUKTI 4-53/ N-37", Phone = "081233900276" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "E0001", AgenID = 1, MarketingName = "ERIC SETIAWAN HANDIKO", Alamat = "  DUKUH KUPANG BARAT 25/15", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "E0002", AgenID = 1, MarketingName = "ESTHER", Alamat = "SURABAYA", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "H0001", AgenID = 1, MarketingName = "HARIYANTO", Alamat = "  WONOKROMO 6/3-C", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "L0001", AgenID = 1, MarketingName = "BOONY STEVANUS / LUCKY", Alamat = "  BRIGHT_LAU85@YAHOO.COM", Phone = "082233881147" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "M0001", AgenID = 1, MarketingName = "MERY", Alamat = "", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "R0001", AgenID = 1, MarketingName = "RICHARD HARRIS YOEWONO", Alamat = "  JL JERUK VI/27 PCI", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "R0002", AgenID = 1, MarketingName = "RUDIMARKI LUKITO", Alamat = "  KEDUNG COWEK NO 105", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "S0001", AgenID = 1, MarketingName = "SISILIA GUNAWAN", Alamat = "  KEDUNGDORO 128", Phone = "" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "S0002", AgenID = 1, MarketingName = "SUGENG SANTOSO", Alamat = "", Phone = "08161817204" });
            TipeGl.Add(new AptMarketing { KodeMarketing = "Y0001", AgenID = 1, MarketingName = "YULIANA", Alamat = "SURABAYA", Phone = "" });

            var cekNull = (from e in db.AptMarketings select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptMarketings.Add(values);
                    db.SaveChanges();
                }


            }
            var aptMarketings = db.AptMarketings.Include(a => a.AptAgen);
            return View(aptMarketings.ToList());
        }

        // GET: SetupMarketing/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            if (aptMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aptMarketing);
        }

        // GET: SetupMarketing/Create
        public ActionResult Create()
        {
            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName");
            return View();
        }

        // POST: SetupMarketing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketingID,MarketingName,Phone,AgenID")] AptMarketing aptMarketing)
        {
            if (ModelState.IsValid)
            {
                db.AptMarketings.Add(aptMarketing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName", aptMarketing.AgenID);
            return View(aptMarketing);
        }

        // GET: SetupMarketing/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            if (aptMarketing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName", aptMarketing.AgenID);
            return View(aptMarketing);
        }

        // POST: SetupMarketing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketingID,MarketingName,Phone,AgenID")] AptMarketing aptMarketing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptMarketing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AgenID = new SelectList(db.AptAgens, "AgenID", "AgenName", aptMarketing.AgenID);
            return View(aptMarketing);
        }

        // GET: SetupMarketing/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            if (aptMarketing == null)
            {
                return HttpNotFound();
            }
            return View(aptMarketing);
        }

        // POST: SetupMarketing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptMarketing aptMarketing = db.AptMarketings.Find(id);
            db.AptMarketings.Remove(aptMarketing);
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
