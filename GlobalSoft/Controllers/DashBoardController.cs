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
    public class DashBoardController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: DashBoard
        public ActionResult DsbUnit(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "kategori_desc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";

            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            if (!String.IsNullOrEmpty(searchString))
            {
                aptUnits = aptUnits.Where(s => s.AptCategorie.Categorie.Contains(searchString)
                || s.AptStatus.Status.Contains(searchString)
                || s.UnitNo.Contains(searchString));
                
            }
            switch (sortOrder)
            {
                case "kategori_desc":
                    aptUnits = aptUnits.OrderByDescending(s => s.AptCategorie.Categorie);
                    break;
                case "status_desc":
                    aptUnits = aptUnits.OrderBy(s => s.AptStatus.Status);
                    break;
                default:
                    aptUnits = aptUnits.OrderBy(s => s.UnitNo);
                    break;
            }


            return View(aptUnits.ToList());


        }
        public ActionResult List2Unit()
        {
            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            return View(aptUnits.ToList());
           
        }
        public ActionResult ListUnit()
        {
            List<UnitVM> allUnit = new List<UnitVM>();

            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            var cbTrans = db.CbTranss.Include(a => a.AptTrsNo).Include(a => a.AptUnit).Include(a => a.AptMarketing);
            var ListCb = from e in db.CbTranss
                         where e.AptTrsNo.TransNo.Contains("BookingFee")
                         select new UnitPiutang { NoRef = e.NoRef, Tanggal = e.Tanggal, UnitID = e.UnitID, UnitNo = e.AptUnit.UnitNo, Angsuran = 0, Bayar = e.Payment, Keterangan = (e.Keterangan == null) ? "Booking Fee" : e.Keterangan };

            var ListSp = from e in db.AptSPesanans
                         join y in db.AptTranss on e.SPesanan equals y.NoRef
                         select new UnitPiutang { NoRef = e.SPesanan, Tanggal = e.Duedate, UnitID = y.UnitID, UnitNo = y.AptUnit.UnitNo, Angsuran = e.Jumlah, Bayar = e.Bayar, Keterangan = e.Keterangan };
            //var ListCb = (from e in cbTrans where e.AptTrsNo.TransNo.Contains("BookingFee") select e).ToList();
            //var ListSp = (from e in db.AptTranss where e.AptTrsNo.TransNo.Contains("SuratPesanan") select e).ToList();

            var ListAll = ListCb.Concat(ListSp);

            foreach (var i in aptUnits)
            {

                var ox = ListAll.Where(a => a.UnitID.Equals(i.UnitID)).ToList();
                allUnit.Add(new UnitVM { Unit = i, Piutang = ox });
            }
            return View(allUnit);
        }

        public JsonResult GetUnit()
        {
            var dbResult = db.AptUnits.ToList();
            var data = (from employee in dbResult
                             select new
                             {
                                 employee.UnitNo,
                                 employee.Lantai,
                                 employee.AptCategorie.Categorie,
                                 employee.AptStatus.Status,
                                 employee.PriceKPR,
                                 employee.Inhouse
                             });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail()
        {
            var cbTrans = db.CbTranss.Include(a => a.AptTrsNo).Include(a => a.AptUnit).Include(a => a.AptMarketing);
            var ListCb = from e in db.CbTranss
                         where e.AptTrsNo.TransNo.Contains("BookingFee")
                         select new UnitPiutang { NoRef = e.NoRef, Tanggal = e.Tanggal, UnitID = e.UnitID, UnitNo = e.AptUnit.UnitNo, Angsuran = 0, Bayar = e.Payment, Keterangan = (e.Keterangan == null) ? "Booking Fee" : e.Keterangan };
            var data = (from employee in ListCb
                             select new
                             {
                                 employee.UnitNo,
                                 employee.NoRef,
                                 employee.Tanggal,
                                 employee.Keterangan,
                                 employee.Angsuran,
                                 employee.Bayar
                             });
            return Json(data, JsonRequestBehavior.AllowGet);

        }
    }
}