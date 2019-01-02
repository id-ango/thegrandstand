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
    public class SetupBayarController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupBayar
        public ActionResult Index()
        {
            List<AptBayar> TipeGl = new List<AptBayar>();
            TipeGl.Add(new AptBayar { CaraBayar = "InHouse" });
            TipeGl.Add(new AptBayar { CaraBayar = "KPA" });

            

            var cekNull = (from e in db.AptBayars select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptBayars.Add(values);
                    db.SaveChanges();
                }


            }
            return View(db.AptBayars.ToList());
        }

        public ActionResult Index2()
        {
            List<AptBayar> TipeGl = new List<AptBayar>
            {
                 new AptBayar { CaraBayar="InHouse"}

            };

            var cekNull = (from e in db.AptBayars select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptBayars.Add(values);
                    db.SaveChanges();
                }


            }
            return View(db.AptBayars.ToList());
        }
        // GET: SetupBayar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptBayar aptBayar = db.AptBayars.Find(id);
            if (aptBayar == null)
            {
                return HttpNotFound();
            }
            return View(aptBayar);
        }

        // GET: SetupBayar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupBayar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BayarID,CaraBayar,Bunga")] AptBayar aptBayar)
        {
            if (ModelState.IsValid)
            {
                db.AptBayars.Add(aptBayar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptBayar);
        }

        // GET: SetupBayar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptBayar aptBayar = db.AptBayars.Find(id);
            if (aptBayar == null)
            {
                return HttpNotFound();
            }
            return View(aptBayar);
        }

        // POST: SetupBayar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BayarID,CaraBayar,Bunga")] AptBayar aptBayar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptBayar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptBayar);
        }

        // GET: SetupBayar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptBayar aptBayar = db.AptBayars.Find(id);
            if (aptBayar == null)
            {
                return HttpNotFound();
            }
            return View(aptBayar);
        }

        // POST: SetupBayar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptBayar aptBayar = db.AptBayars.Find(id);
            db.AptBayars.Remove(aptBayar);
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
