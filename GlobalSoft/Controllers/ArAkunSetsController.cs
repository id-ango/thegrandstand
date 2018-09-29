﻿using System;
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
    public class ArAkunSetsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: ArAkunSets
        public ActionResult Index()
        {

            var dbgl = db.GlAccounts;
            var dbakun = db.ArAkunSets.ToList();
           
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
            ArAkunSet arAkunSet = db.ArAkunSets.Find(id);
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
        public ActionResult Create([Bind(Include = "AkunsetID,AkunSet,GlAkunID1,GlAkunID2,GlAkunID3,GlAkunID4")] ArAkunSet arAkunSet)
        {
            if (ModelState.IsValid)
            {
                db.ArAkunSets.Add(arAkunSet);
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
            ArAkunSet arAkunSet = db.ArAkunSets.Find(id);
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

            ViewBag.GlAkunID1 = akunGl;
            ViewBag.GlAkunID2 = akunGl;
            ViewBag.GlAkunID3 = akunGl;
            ViewBag.GlAkunID4 = akunGl;

            return View(arAkunSet);
        }

        // POST: ArAkunSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AkunsetID,AkunSet,GlAkunID1,GlAkunID2,GlAkunID3,GlAkunID4")] ArAkunSet arAkunSet)
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
            ArAkunSet arAkunSet = db.ArAkunSets.Find(id);
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

            ViewBag.GlAkunID1 = akunGl;
            ViewBag.GlAkunID2 = akunGl;
            ViewBag.GlAkunID3 = akunGl;
            ViewBag.GlAkunID4 = akunGl;

            return View(arAkunSet);
        }

        // POST: ArAkunSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArAkunSet arAkunSet = db.ArAkunSets.Find(id);
            db.ArAkunSets.Remove(arAkunSet);
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
