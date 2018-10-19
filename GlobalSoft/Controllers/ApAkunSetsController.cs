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
    public class ApAkunSetsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: ArAkunSets
        public ActionResult Index()
        {

            var dbgl = db.GlAccounts;
            var dbakun = db.ApAkunSets.ToList();
           
            foreach(var i in dbakun)
            {
                i.GlAkun1 = (i.GlAkunID1 != 0) ? (dbgl.Find(i.GlAkunID1).GlAkun + " - " + dbgl.Find(i.GlAkunID1).GlAkunName) : "--Kode Akun--";
                i.GlAkun2 = (i.GlAkunID2 != 0) ? (dbgl.Find(i.GlAkunID2).GlAkun + " - " + dbgl.Find(i.GlAkunID2).GlAkunName) : "--Kode Akun--";
                i.GlAkun3 = (i.GlAkunID3 != 0) ? (dbgl.Find(i.GlAkunID3).GlAkun + " - " + dbgl.Find(i.GlAkunID3).GlAkunName) : "--Kode Akun--";
                i.GlAkun4 = (i.GlAkunID4 != 0) ? (dbgl.Find(i.GlAkunID4).GlAkun + " - " + dbgl.Find(i.GlAkunID4).GlAkunName) : "--Kode Akun--";
            }

            return View(dbakun.ToList());
        }

        // GET: ArAkunSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApAkunSet arAkunSet = db.ApAkunSets.Find(id);
            if (arAkunSet == null)
            {
                return HttpNotFound();
            }
            return View(arAkunSet);
        }

        // GET: ArAkunSets/Create
        public ActionResult Create()
        {
            List<SelectListItem> akunGl = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Kode Akun---",
                    Value = "0"
                }
            };
            var dbakun = db.GlAccounts.OrderBy(x =>x.GlAkun).ToList();

            foreach(var i in dbakun)
            {
                akunGl.Add(new SelectListItem() { Text = i.GlAkun + " - " + i.GlAkunName, Value = i.GlAkunID.ToString() });
            }

            ViewBag.GlAkunID1 = akunGl;
            ViewBag.GlAkunID2 = akunGl;
            ViewBag.GlAkunID3 = akunGl;
            ViewBag.GlAkunID4 = akunGl;
            
            return View();
        }

        // POST: ArAkunSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AkunsetID,AkunSet,GlAkunID1,GlAkunID2,GlAkunID3,GlAkunID4")] ApAkunSet arAkunSet)
        {
            if (ModelState.IsValid)
            {
                db.ApAkunSets.Add(arAkunSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arAkunSet);
        }

        // GET: ArAkunSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApAkunSet arAkunSet = db.ApAkunSets.Find(id);
            if (arAkunSet == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> akunGl = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Kode Akun---",
                    Value = "0"
                }
            };
            var dbakun = db.GlAccounts.OrderBy(x => x.GlAkun).ToList();

            foreach (var i in dbakun)
            {
                akunGl.Add(new SelectListItem() { Text = i.GlAkun + " - " + i.GlAkunName, Value = i.GlAkunID.ToString() });
            }

            ViewBag.GlAkunID1 = akunGl.Select(p => new SelectListItem { Text = p.Text, Value = p.Value, Selected = p.Value == arAkunSet.GlAkunID1.ToString() });
            ViewBag.GlAkunID2 = akunGl.Select(p => new SelectListItem { Text = p.Text, Value = p.Value, Selected = p.Value == arAkunSet.GlAkunID2.ToString() });
            ViewBag.GlAkunID3 = akunGl.Select(p => new SelectListItem { Text = p.Text, Value = p.Value, Selected = p.Value == arAkunSet.GlAkunID3.ToString() });
            ViewBag.GlAkunID4 = akunGl.Select(p => new SelectListItem { Text = p.Text, Value = p.Value, Selected = p.Value == arAkunSet.GlAkunID4.ToString() });


            return View(arAkunSet);
        }

        // POST: ArAkunSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AkunsetID,AkunSet,GlAkunID1,GlAkunID2,GlAkunID3,GlAkunID4")] ApAkunSet arAkunSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arAkunSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arAkunSet);
        }

        // GET: ArAkunSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApAkunSet arAkunSet = db.ApAkunSets.Find(id);
            if (arAkunSet == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> akunGl = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Kode Akun---",
                    Value = "0"
                }
            };
            var dbakun = db.GlAccounts.OrderBy(x => x.GlAkun).ToList();

            foreach (var i in dbakun)
            {
                akunGl.Add(new SelectListItem() { Text = i.GlAkun + " - " + i.GlAkunName, Value = i.GlAkunID.ToString() });
            }
           // ViewBag.GlAkunID = db.GlAccounts.Select(p => new SelectListItem
            //{
            //    Text = p.GlAkun + "-" + p.GlAkunName,
            //    Value = p.GlAkunID.ToString(),
            //    Selected = p.GlAkunID == cbBank.GlAkunID

           // });

            //            ViewBag.GlAkunID = new SelectList(db.GlAccounts, "GlAkunID", "GlAkun", cbBank.GlAkunID);

           
            return View(arAkunSet);
        }

        // POST: ArAkunSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApAkunSet arAkunSet = db.ApAkunSets.Find(id);
            db.ApAkunSets.Remove(arAkunSet);
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
