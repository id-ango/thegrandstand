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
    public class SetupCustomerController : Controller
    {

        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupCustomer
        public ActionResult Index(string sortOrder, string searchString)
        {
            List<ArCustomer> TipeGl = new List<ArCustomer>();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "";

            var customers = from s in db.ArCustomers select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.CustomerName.Contains(searchString)
                || s.AlamatSekarang.Contains(searchString)
                || s.Alamat.Contains(searchString)
                || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(s => s.CustomerName);
                    break;
                case "address_desc":
                    customers = customers.OrderBy(s => s.AlamatSekarang);
                    break;
                default:
                    customers = customers.OrderBy(s => s.CustomerName);
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
            ArCustomer arCustomer = db.ArCustomers.Find(id);
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
            var dbakun = db.ArAkunSets.OrderBy(x => x.AkunSet).ToList();

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
        public ActionResult Create([Bind(Include = "CustomerID,CustomerName,ShortName,Alamat,Ktp,Phone,AlamatSekarang,KodePos,Email,Npwp,AkunSetID")] ArCustomer arCustomer)
        {
            if (ModelState.IsValid)
            {
                db.ArCustomers.Add(arCustomer);
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
            ArCustomer arCustomer = db.ArCustomers.Find(id);
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
            var dbakun = db.ArAkunSets.OrderBy(x => x.AkunSet).ToList();

            foreach (var i in dbakun)
            {

                akunGl.Add(new SelectListItem() { Text = i.AkunSet, Value = i.AkunsetID.ToString(), Selected = (i.AkunsetID == arCustomer.AkunSetID) ? true : false });
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
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,ShortName,Alamat,Ktp,Phone,AlamatSekarang,KodePos,Email,Npwp,AkunSetID")] ArCustomer arCustomer)
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
            ArCustomer arCustomer = db.ArCustomers.Find(id);
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
            ArCustomer arCustomer = db.ArCustomers.Find(id);
            db.ArCustomers.Remove(arCustomer);
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
