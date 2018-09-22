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
    public class SetupTypeController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupType
        public ActionResult Index()
        {
            List<AptType> TipeApt = new List<AptType>();
            TipeApt.Add(new AptType { Tipe = "1BR" });
            TipeApt.Add(new AptType { Tipe = "2BR" });
            TipeApt.Add(new AptType { Tipe = "3BR" });

            var cekNull = (from e in db.AptTipes select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeApt)
                {
                    db.AptTipes.Add(values);
                    db.SaveChanges();
                }


            }
            var listtipe = from e in db.AptTipes
                           orderby e.Tipe
                           select e;

            return View(listtipe);
        }

        // GET: SetupType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptType aptType = db.AptTipes.Find(id);
            if (aptType == null)
            {
                return HttpNotFound();
            }
            return View(aptType);
        }

        // GET: SetupType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipeID,Tipe")] AptType aptType)
        {
            if (ModelState.IsValid)
            {
                db.AptTipes.Add(aptType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptType);
        }

        // GET: SetupType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptType aptType = db.AptTipes.Find(id);
            if (aptType == null)
            {
                return HttpNotFound();
            }
            return View(aptType);
        }

        // POST: SetupType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipeID,Tipe")] AptType aptType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptType);
        }

        // GET: SetupType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptType aptType = db.AptTipes.Find(id);
            if (aptType == null)
            {
                return HttpNotFound();
            }
            return View(aptType);
        }

        // POST: SetupType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptType aptType = db.AptTipes.Find(id);
            db.AptTipes.Remove(aptType);
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
