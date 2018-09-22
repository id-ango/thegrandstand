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
    [Authorize(Roles = "Admin,Manager")]
    public class SetupCategorieController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupCategorie
        public ActionResult Index()
        {
            List<AptCategorie> TipeGl = new List<AptCategorie>();
            TipeGl.Add(new AptCategorie { Categorie = "Emerald A",TipeID=1,Luas=35.90M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald B", TipeID = 1, Luas = 23.90M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald C", TipeID = 1, Luas = 28.00M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald D", TipeID = 1, Luas = 27.40M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald E", TipeID = 1, Luas = 35.30M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald F", TipeID = 1, Luas = 39.90M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald G", TipeID = 1, Luas = 22.10M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald H", TipeID = 1, Luas = 28.50M });
            TipeGl.Add(new AptCategorie { Categorie = "Emerald I", TipeID = 1, Luas = 39.60M });
            TipeGl.Add(new AptCategorie { Categorie = "Sapphire A", TipeID = 2, Luas = 87.10M });
            TipeGl.Add(new AptCategorie { Categorie = "Sapphire B", TipeID = 2, Luas = 84.50M });            
            TipeGl.Add(new AptCategorie { Categorie = "Sapphire C", TipeID = 2, Luas = 71.70M });
            TipeGl.Add(new AptCategorie { Categorie = "Sapphire D", TipeID = 2, Luas = 95.30M });
            TipeGl.Add(new AptCategorie { Categorie = "Sapphire E", TipeID = 2, Luas = 94.40M });
            TipeGl.Add(new AptCategorie { Categorie = "Diamond A", TipeID = 3, Luas = 123.60M });
            TipeGl.Add(new AptCategorie { Categorie = "Diamond B", TipeID = 3, Luas = 130.70M });

            var cekNull = (from e in db.AptCategories select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptCategories.Add(values);
                    db.SaveChanges();
                }


            }
            var aptCategories = db.AptCategories.Include(a => a.AptType);
            return View(aptCategories.ToList());
        }

        // GET: SetupCategorie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            if (aptCategorie == null)
            {
                return HttpNotFound();
            }
            return View(aptCategorie);
        }

        // GET: SetupCategorie/Create
        public ActionResult Create()
        {
            ViewBag.TipeID = new SelectList(db.AptTipes.OrderBy( y => y.Tipe), "TipeID", "Tipe");
            return View();
        }

        // POST: SetupCategorie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategorieID,Categorie,Luas,TipeID")] AptCategorie aptCategorie)
        {
            if (ModelState.IsValid)
            {
                db.AptCategories.Add(aptCategorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe", aptCategorie.TipeID);
            return View(aptCategorie);
        }

        // GET: SetupCategorie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            if (aptCategorie == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe", aptCategorie.TipeID);
            return View(aptCategorie);
        }

        // POST: SetupCategorie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategorieID,Categorie,Luas,TipeID")] AptCategorie aptCategorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptCategorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipeID = new SelectList(db.AptTipes, "TipeID", "Tipe", aptCategorie.TipeID);
            return View(aptCategorie);
        }

        // GET: SetupCategorie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            if (aptCategorie == null)
            {
                return HttpNotFound();
            }
            return View(aptCategorie);
        }

        // POST: SetupCategorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptCategorie aptCategorie = db.AptCategories.Find(id);
            db.AptCategories.Remove(aptCategorie);
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
