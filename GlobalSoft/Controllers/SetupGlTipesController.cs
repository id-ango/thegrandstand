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
    public class SetupGlTipesController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupGlTipes
        public ActionResult Index()
        {
            List<GlTipe> TipeGl = new List<GlTipe>();
            TipeGl.Add(new GlTipe { GlTipeName = "Bank and Cash" });
            TipeGl.Add(new GlTipe { GlTipeName = "Credit Card" });
            TipeGl.Add(new GlTipe { GlTipeName = "Receivable" });
            TipeGl.Add(new GlTipe { GlTipeName = "Current Assets" });
            TipeGl.Add(new GlTipe { GlTipeName = "Non Current Assets" });
            TipeGl.Add(new GlTipe { GlTipeName = "Depreciation" });
            TipeGl.Add(new GlTipe { GlTipeName = "Payable" });                    
            TipeGl.Add(new GlTipe { GlTipeName = "Prepayments" });
            TipeGl.Add(new GlTipe { GlTipeName = "Fixed Assets" });
            TipeGl.Add(new GlTipe { GlTipeName = "Current Liabilities" });
            TipeGl.Add(new GlTipe { GlTipeName = "Non-current Liabilities" });
            TipeGl.Add(new GlTipe { GlTipeName = "Current Year Earnings" });
            TipeGl.Add(new GlTipe { GlTipeName = "Other Income" });
            TipeGl.Add(new GlTipe { GlTipeName = "Income" });
            TipeGl.Add(new GlTipe { GlTipeName = "Expenses" });
            TipeGl.Add(new GlTipe { GlTipeName = "Cost of Revenue" });
            TipeGl.Add(new GlTipe { GlTipeName = "Equity" });
          

            var cekNull = (from e in db.GlTipes select e).Count();
           if (cekNull == 0)
            {
               

                foreach (var values in TipeGl)
                {
                    db.GlTipes.Add(values);
                    db.SaveChanges();
                }

               
           }


            return View(db.GlTipes.ToList());
        }

        // GET: SetupGlTipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlTipe glTipe = db.GlTipes.Find(id);
            if (glTipe == null)
            {
                return HttpNotFound();
            }
            return View(glTipe);
        }

        // GET: SetupGlTipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupGlTipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlTipeID,GlTipeName")] GlTipe glTipe)
        {
            if (ModelState.IsValid)
            {
                db.GlTipes.Add(glTipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glTipe);
        }

        // GET: SetupGlTipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlTipe glTipe = db.GlTipes.Find(id);
            if (glTipe == null)
            {
                return HttpNotFound();
            }
            return View(glTipe);
        }

        // POST: SetupGlTipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlTipeID,GlTipeName")] GlTipe glTipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glTipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glTipe);
        }

        // GET: SetupGlTipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlTipe glTipe = db.GlTipes.Find(id);
            if (glTipe == null)
            {
                return HttpNotFound();
            }
            return View(glTipe);
        }

        // POST: SetupGlTipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlTipe glTipe = db.GlTipes.Find(id);
            db.GlTipes.Remove(glTipe);
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
