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
    [Authorize]
    public class SetupAgenController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupAgen
        public ActionResult Index()
        { 
         List<AptAgen> TipeGl = new List<AptAgen>();
            TipeGl.Add(new AptAgen {AgenName = "Internal" });

            var cekNull = (from e in db.AptAgens select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptAgens.Add(values);
                    db.SaveChanges();
                }


            }

            return View(db.AptAgens.ToList());
        }

        // GET: SetupAgen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptAgen aptAgen = db.AptAgens.Find(id);
            if (aptAgen == null)
            {
                return HttpNotFound();
            }
            return View(aptAgen);
        }

        // GET: SetupAgen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupAgen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgenID,AgenName,Phone")] AptAgen aptAgen)
        {
            if (ModelState.IsValid)
            {
                db.AptAgens.Add(aptAgen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptAgen);
        }

        // GET: SetupAgen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptAgen aptAgen = db.AptAgens.Find(id);
            if (aptAgen == null)
            {
                return HttpNotFound();
            }
            return View(aptAgen);
        }

        // POST: SetupAgen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgenID,AgenName,Phone")] AptAgen aptAgen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptAgen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptAgen);
        }

        // GET: SetupAgen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptAgen aptAgen = db.AptAgens.Find(id);
            if (aptAgen == null)
            {
                return HttpNotFound();
            }
            return View(aptAgen);
        }

        // POST: SetupAgen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptAgen aptAgen = db.AptAgens.Find(id);
            db.AptAgens.Remove(aptAgen);
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
