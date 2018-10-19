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
    public class SetupSupplierController : Controller
    {

        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupCustomer
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "";

            var customers = from s in db.ApSuppliers select s;

            if (!String.IsNullOrEmpty(searchString) )
            {
                customers = customers.Where(s => s.SupplierName.Contains(searchString)
                || s.AlamatSekarang.Contains(searchString)
                || s.Alamat.Contains(searchString)
                || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.SupplierName);
                    break;
                case "address_desc":
                    customers = customers.OrderBy(s => s.AlamatSekarang);
                    break;
                default:              
                    customers = customers.OrderBy(s => s.SupplierName);
                    break;
            }
            return View(customers.ToList());
        }

        // GET: SetupCustomer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApSupplier arCustomer = db.ApSuppliers.Find(id);
            if (arCustomer == null)
            {
                return HttpNotFound();
            }
            return View(arCustomer);
        }

        // GET: SetupCustomer/Create
        public ActionResult Create()
        {
            List<SelectListItem> akunGl = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Akun Set---",
                    Value = "0"
                }
            };
            var dbakun = db.ApAkunSets.OrderBy(x => x.AkunSet).ToList();

            foreach (var i in dbakun)
            {
                akunGl.Add(new SelectListItem() { Text = i.AkunSet, Value = i.AkunsetID.ToString() });
            }

            ViewBag.AkunSetID = akunGl;

            return View();
        }

        // POST: SetupCustomer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,ShortName,Alamat,Ktp,Phone,AlamatSekarang,KodePos,Email,Npwp,AkunSetID")] ApSupplier arCustomer)
        {
            if (ModelState.IsValid)
            {
                db.ApSuppliers.Add(arCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arCustomer);
        }

        // GET: SetupCustomer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApSupplier arCustomer = db.ApSuppliers.Find(id);
            if (arCustomer == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> akunGl = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Akun Set---",
                    Value = "0"
                }
            };
            var dbakun = db.ApAkunSets.OrderBy(x => x.AkunSet).ToList();

            foreach (var i in dbakun)
            {

                akunGl.Add(new SelectListItem() { Text = i.AkunSet, Value = i.AkunsetID.ToString(),Selected = (i.AkunsetID == arCustomer.AkunSetID) ? true : false });
            }

            ViewBag.AkunSetID = akunGl;

         //   ViewBag.AkunSetID = new SelectList(db.ArAkunSets, "AkunSetID", "AkunSet",arCustomer.AkunSetID);
           
            return View(arCustomer);
        }

        // POST: SetupCustomer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,ShortName,Alamat,Ktp,Phone,AlamatSekarang,KodePos,Email,Npwp,AkunSetID")] ApSupplier arCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arCustomer);
        }

        // GET: SetupCustomer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApSupplier arCustomer = db.ApSuppliers.Find(id);
            if (arCustomer == null)
            {
                return HttpNotFound();
            }
            return View(arCustomer);
        }

        // POST: SetupCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApSupplier arCustomer = db.ApSuppliers.Find(id);
            db.ApSuppliers.Remove(arCustomer);
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
