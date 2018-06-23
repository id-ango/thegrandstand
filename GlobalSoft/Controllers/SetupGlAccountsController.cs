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
    public class SetupGlAccountsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupGlAccounts
        public ActionResult Index()
        {
            var glAccounts = db.GlAccounts.Include(g => g.GlTipe);
            return View(glAccounts.ToList());
        }

        // GET: SetupGlAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlAccount glAccount = db.GlAccounts.Find(id);
            if (glAccount == null)
            {
                return HttpNotFound();
            }
            return View(glAccount);
        }

        // GET: SetupGlAccounts/Create
        public ActionResult Create()
        {
            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName");
            return View();
        }

        // POST: SetupGlAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlAKunID,GlAkun,GlAkun2,GlAkunName,GlTipeID")] GlAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                db.GlAccounts.Add(glAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName", glAccount.GlTipeID);
            return View(glAccount);
        }

        // GET: SetupGlAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlAccount glAccount = db.GlAccounts.Find(id);
            if (glAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName", glAccount.GlTipeID);
            return View(glAccount);
        }

        // POST: SetupGlAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlAKunID,GlAkun,GlAkun2,GlAkunName,GlTipeID")] GlAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName", glAccount.GlTipeID);
            return View(glAccount);
        }

        // GET: SetupGlAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlAccount glAccount = db.GlAccounts.Find(id);
            if (glAccount == null)
            {
                return HttpNotFound();
            }
            return View(glAccount);
        }

        // POST: SetupGlAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlAccount glAccount = db.GlAccounts.Find(id);
            db.GlAccounts.Remove(glAccount);
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
