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
    [Authorize(Roles ="Admin,Manager,Employee")]
    public class SetupBankController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupBank
        public ActionResult Index()
        {
            var cbBanks = db.CbBanks.Include(c => c.GlAccount);
            return View(cbBanks.ToList());
        }

        // GET: SetupBank/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbBank cbBank = db.CbBanks.Find(id);
            if (cbBank == null)
            {
                return HttpNotFound();
            }
            return View(cbBank);
        }

        // GET: SetupBank/Create
        public ActionResult Create()
        {
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x=>x.GlAkun).Select(p => new SelectListItem
      {
          Text = p.GlAkun + "-" + p.GlAkunName,
          Value = p.GlAkunID.ToString()
      });
            return View();
        }

        // POST: SetupBank/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankID,BankName,BankAccount,Saldo,GlAkunID")] CbBank cbBank)
        {
            if (ModelState.IsValid)
            {
                db.CbBanks.Add(cbBank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Where(p=>p.GlAkunID == cbBank.GlAkunID).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString()
            });
    //        ViewBag.GlAkunID = new SelectList(db.GlAccounts, "GlAkunID", "GlAkun", cbBank.GlAkunID);
            return View(cbBank);
        }

        // GET: SetupBank/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbBank cbBank = db.CbBanks.Find(id);
            if (cbBank == null)
            {
                return HttpNotFound();
            }
         
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString(),
                Selected  = p.GlAkunID == cbBank.GlAkunID
                
            });

//            ViewBag.GlAkunID = new SelectList(db.GlAccounts, "GlAkunID", "GlAkun", cbBank.GlAkunID);
            return View(cbBank);
        }

        // POST: SetupBank/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankID,BankName,BankAccount,Saldo,GlAkunID")] CbBank cbBank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cbBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString(),
                Selected = p.GlAkunID == cbBank.GlAkunID

            });

//            ViewBag.GlAkunID = new SelectList(db.GlAccounts, "GlAkunID", "GlAkun", cbBank.GlAkunID);
            return View(cbBank);
        }

        // GET: SetupBank/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbBank cbBank = db.CbBanks.Find(id);
            if (cbBank == null)
            {
                return HttpNotFound();
            }
            return View(cbBank);
        }

        // POST: SetupBank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CbBank cbBank = db.CbBanks.Find(id);
            db.CbBanks.Remove(cbBank);
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
