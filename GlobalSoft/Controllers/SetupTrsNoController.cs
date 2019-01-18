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
            List<AptTrsNo> TipeGl = new List<AptTrsNo>();

            TipeGl.Add(new AptTrsNo { SourceCode = "", TransNo = "BookingFee" });
            TipeGl.Add(new AptTrsNo { SourceCode = "", TransNo = "SuratPesanan" });
            TipeGl.Add(new AptTrsNo { SourceCode = "AR", TransNo = "ANGSURAN" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B1", TransNo = "Kas" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B2", TransNo = "Biaya Bank CIMB" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B3", TransNo = "Biaya bank BCA" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B4", TransNo = "Biaya Bank CIMB Payroll" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B5", TransNo = "Biaya Bank Mandiri Giro" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B6", TransNo = "Biaya Bank Mandiri Tab Bisnis" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B7", TransNo = "BTN" });
            TipeGl.Add(new AptTrsNo { SourceCode = "B8", TransNo = "Biaya Bank MYBANK" });
            TipeGl.Add(new AptTrsNo { SourceCode = "BF", TransNo = "BOOKING FEE" });
            TipeGl.Add(new AptTrsNo { SourceCode = "CB", TransNo = "KAS/BANK CLEARING" });
            TipeGl.Add(new AptTrsNo { SourceCode = "CF", TransNo = "COMPLIMENT FEE" });
            TipeGl.Add(new AptTrsNo { SourceCode = "CP", TransNo = "CREDIT PROFIT/HIBAH" });
            TipeGl.Add(new AptTrsNo { SourceCode = "P", TransNo = "Pendapatan lain" });
            TipeGl.Add(new AptTrsNo { SourceCode = "P2", TransNo = "PEMASUKAN DARI CATTURA" });
            TipeGl.Add(new AptTrsNo { SourceCode = "P3", TransNo = "PENDAPATAN BUNGA" });
            TipeGl.Add(new AptTrsNo { SourceCode = "P4", TransNo = "PENDAPATAN PAJAK BUNGA" });
            TipeGl.Add(new AptTrsNo { SourceCode = "S1", TransNo = "SETORAN DR PUSAT" });
            TipeGl.Add(new AptTrsNo { SourceCode = "T1", TransNo = "PPH 21" });
            TipeGl.Add(new AptTrsNo { SourceCode = "T2", TransNo = "PPH 23" });
            TipeGl.Add(new AptTrsNo { SourceCode = "T3", TransNo = "PPH 4(2)" });
            TipeGl.Add(new AptTrsNo { SourceCode = "T4", TransNo = "PPN" });


            var cekNull = (from e in db.AptTrsNoes select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptTrsNoes.Add(values);
                    db.SaveChanges();
                }


            }
            var aptTranss2 = db.AptTrsNoes.ToList();

            var Booking = (from e in aptTranss2
                           select new TrsnoVM
                           {
                               TransNoID = e.TransNoID,
                               TransNo = e.TransNo,
                               GlAkunID = e.GlAkunID,
                               GlAkunName = (from y in db.GlAccounts where y.GlAkunID == e.GlAkunID select y.GlAkunName).FirstOrDefault()                              
                           }).ToList();

          

                return View(Booking);
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
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString()
            });

            return View();
        }

        // POST: SetupTrsNo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransNoID,TransNo,GlAkunID")] AptTrsNo aptTrsNo)
        {
            if (ModelState.IsValid)
            {
                db.AptTrsNoes.Add(aptTrsNo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Where(p => p.GlAkunID == aptTrsNo.GlAkunID).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString()
            });

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
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString(),
                Selected = p.GlAkunID == aptTrsNo.GlAkunID

            });
            return View(aptTrsNo);
        }

        // POST: SetupTrsNo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransNoID,TransNo,GlAkunID")] AptTrsNo aptTrsNo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptTrsNo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlAkunID = db.GlAccounts.OrderBy(x => x.GlAkun).Where(p => p.GlAkunID == aptTrsNo.GlAkunID).Select(p => new SelectListItem
            {
                Text = p.GlAkun + "-" + p.GlAkunName,
                Value = p.GlAkunID.ToString()
            });
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
