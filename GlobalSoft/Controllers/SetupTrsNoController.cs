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
    public class SetupTrsNoController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupTrsNo
        public ActionResult Index()
        {
            List<AptTrsNo> TipeGl = new List<AptTrsNo>
            {
                 new AptTrsNo { TransNo="BookingFee"},
                 new AptTrsNo { TransNo = "SuratPesanan" }
            };

            var cekNull = (from e in db.AptTrsNoes select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptTrsNoes.Add(values);
                    db.SaveChanges();
                }


            }

            return View(db.AptTrsNoes.ToList());
        }

        // GET: SetupTrsNo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrsNo aptTrsNo = db.AptTrsNoes.Find(id);
            if (aptTrsNo == null)
            {
                return HttpNotFound();
            }
            return View(aptTrsNo);
        }

        // GET: SetupTrsNo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupTrsNo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransNoID,TransNo")] AptTrsNo aptTrsNo)
        {
            if (ModelState.IsValid)
            {
                db.AptTrsNoes.Add(aptTrsNo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptTrsNo);
        }

        // GET: SetupTrsNo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrsNo aptTrsNo = db.AptTrsNoes.Find(id);
            if (aptTrsNo == null)
            {
                return HttpNotFound();
            }
            return View(aptTrsNo);
        }

        // POST: SetupTrsNo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransNoID,TransNo")] AptTrsNo aptTrsNo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptTrsNo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptTrsNo);
        }

        // GET: SetupTrsNo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrsNo aptTrsNo = db.AptTrsNoes.Find(id);
            if (aptTrsNo == null)
            {
                return HttpNotFound();
            }
            return View(aptTrsNo);
        }

        // POST: SetupTrsNo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptTrsNo aptTrsNo = db.AptTrsNoes.Find(id);
            db.AptTrsNoes.Remove(aptTrsNo);
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
