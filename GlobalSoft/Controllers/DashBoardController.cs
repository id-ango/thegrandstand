using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;
using WebGrease.Css.Extensions;

namespace GlobalSoft.Controllers
{
    public class DashBoardController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: DashBoard
        [Authorize]
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
        [Authorize(Roles = "Admin,Manager,Employee,Marketing")]
        public ActionResult List3Unit()
        {
            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            var listUnit = (from e in aptUnits
                           select new BookViewsModels
                           {
                               UnitNo = e.UnitNo,
                               Lantai = e.Lantai,
                               Categorie = e.AptCategorie.Categorie,
                               Status = e.AptStatus.Status
                           }).ToList();

            return View(listUnit);
           
        }
        [Authorize(Roles = "Admin,Manager,Employee,Marketing")]
        public ActionResult List2Unit()
        {
          // TabularViewModel TabelView = new TabularViewModel();
          //  TabelView.Gedungs = db.AptGedungs.ToList();
         //   TabelView.Units = db.AptUnits.ToList();
         //   TabelView.Kategoris = db.AptCategories.ToList();

            return View(db.AptGedungs.ToList());

        }
        [Authorize(Roles = "Admin,Marketing")]
        public ActionResult ListUnit()
        {
            List<UnitVM> allUnit = new List<UnitVM>();

            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            var cbTrans = db.CbTranss.Include(a => a.AptTrsNo).Include(a => a.AptUnit).Include(a => a.AptMarketing);
            var ListCb = from e in db.CbTranss
                         where e.AptTrsNo.TransNo.Contains("BookingFee")
                         select new UnitPiutang { NoRef = e.NoRef, Tanggal = e.Tanggal, UnitID = e.UnitID, UnitNo = e.AptUnit.UnitNo, Angsuran = 0, Bayar = e.Payment, Keterangan = e.Keterangan ?? "Booking Fee" };

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
            
            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            var listUnit = (from e in aptUnits
                            select new BookViewsModels
                            {

                                UnitID = e.UnitID,
                                UnitNo = e.UnitNo,
                                Lantai = e.Lantai,
                                Categorie = e.AptCategorie.Categorie,
                                Status = e.AptStatus.Status,
                                CustomerID = 0,
                                CustomerName = "",
                                MarketingName = "",
                                PaymentName = "",
                                NoRef = "",
                                Piutang = 0,
                                Pembayaran = 0,
                                Sisa = 0
 //                               CustomerName = (from y in db.AptTranss
  //                                              where y.UnitID == y.UnitID
  //                                              select y.ArCustomer.CustomerName).FirstOrDefault(),
  //                              MarketingName = (from y in db.AptTranss
  //                                               where y.UnitID == y.UnitID
  //                                               select y.AptMarketing.MarketingName).FirstOrDefault(),
  //                              PaymentName = (from y in db.AptTranss
  //                                             where y.UnitID == y.UnitID
  //                                             select y.AptBayar.CaraBayar).FirstOrDefault()

                            }).ToList();

            foreach (var y in db.CbTranss)
            {
                (from e in listUnit
                 where e.UnitID == y.UnitID
                 select e).ForEach(x => {
                     x.CustomerName = db.ArCustomers.Where(g => g.CustomerID == y.PersonID).Select(g => g.CustomerName).First();
                     x.Pembayaran = x.Pembayaran + y.Payment; x.Sisa = x.Sisa - y.Payment;
                 });
            }

            foreach (var y in db.AptTranss)
            {
                (from e in listUnit
                 where e.UnitID == y.UnitID
                 select e).ForEach( x => { x.CustomerName = y.ArCustomer.CustomerName; x.MarketingName = y.AptMarketing.MarketingName;
                     x.PaymentName = y.AptBayar.CaraBayar;x.NoRef = y.NoRef;
                     x.Piutang = y.Piutang;
                     x.Sisa = y.Piutang;
                     x.CustomerID = y.CustomerID;
                 });
            }
    
            foreach (var y in db.AptSPesanans)
            {
                (from e in listUnit
                 where e.NoRef == y.SPesanan
                 select e).ForEach(x => {
                     y.Bayar = db.ArTransDs.Where(r => r.SPesananID == y.SPesananID).Select(r => r.Bayar + r.Diskon).DefaultIfEmpty(0).Sum();
                     x.Pembayaran = x.Pembayaran+y.Bayar;
                     x.Sisa = x.Sisa-y.Bayar;
                 });
            }

            


            var dbResult = listUnit;
            var employees = (from employee in dbResult
                             select new
                             {
                                 employee.UnitNo,
                                 employee.Lantai,
                                 employee.Categorie,
                                 employee.Status,
                                 employee.CustomerName,
                                 employee.MarketingName,
                                 employee.PaymentName,
                                 employee.Piutang,
                                 employee.Pembayaran,
                                 employee.Sisa,
                                 employee.NoRef
            
                                 

                             });
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }
      
        public JsonResult GetDetail(string unitNo)
        {
            var testUnit = unitNo;

              var cbTrans = db.CbTranss.Include(a => a.AptTrsNo).Include(a => a.AptUnit).Include(a => a.AptMarketing);
              var ListCb = (from e in db.CbTranss
                            where e.AptUnit.UnitNo == testUnit && (e.TransNoID == 1 || e.TransNoID ==2)
                           select new UnitPiutang {
                               NoRef = e.NoRef,
                               Tanggal = e.Tanggal,
                               UnitID = e.UnitID,
                               UnitNo = e.AptUnit.UnitNo,
                               Angsuran = 0,
                               Bayar = e.Payment,
                               Keterangan = e.Keterangan ?? "Booking Fee" }).ToList();
            foreach (var i in ListCb)
            {
                i.TglString = i.Tanggal.ToString("dd/MM/yyyy");
            }

            var ListSp = (from e in db.AptTranss join
                              y in db.AptSPesanans on e.NoRef equals y.SPesanan
                          where e.AptUnit.UnitNo == testUnit
                          select new UnitPiutang {
                              NoRef = e.NoRef,
                              Duedate = y.Duedate,                              
                              UnitID = e.UnitID,
                              UnitNo = e.AptUnit.UnitNo,
                              Angsuran = y.Jumlah,
                              Bayar =  db.ArTransDs.Where(x =>x.SPesananID == y.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                              Keterangan =  y.Keterangan }).ToList();

            foreach (var gt in ListSp)
            {
                gt.TglString = gt.Duedate.ToString("dd/MM/yyyy");
            }

            var allList = ListCb.Concat(ListSp);
            //           TglString = Convert.ToDateTime(e.Tanggal).ToString("dd-MM-yyyy")
            var employees = (from employee in allList
                             select new
                             {
                                 employee.NoRef,
                                 employee.Tanggal,
                                 employee.Keterangan,
                                 employee.UnitNo,
                                 employee.Angsuran,
                                 employee.Bayar,
                                 employee.TglString
                             });
          
            return Json( employees , JsonRequestBehavior.AllowGet);
          //  return Json(new { data2 = ListCb }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetTabular(int Level)
        {
            
            var Gedung = db.AptGedungs.Where(x => x.GedungID == Level).First();
            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            var listUnit = (from e in aptUnits where( e.Lantai >= Gedung.Lantai1 && e.Lantai <= Gedung.Lantai2)
                            select new BookViewsModels
                            {

                                UnitID = e.UnitID,
                                UnitNo = e.UnitNo,
                                Lantai = e.Lantai,
                                Categorie = e.AptCategorie.Categorie,
                                Status = e.AptStatus.Status,
                                Luas = e.AptCategorie.Luas,
                                CustomerID = 0,
                                CustomerName = "",
                                MarketingName = "",
                                PaymentName = "",
                                NoRef = "",
                                Piutang = 0,
                                Pembayaran = 0,
                                Sisa = 0
                                //                               CustomerName = (from y in db.AptTranss
                                //                                              where y.UnitID == y.UnitID
                                //                                              select y.ArCustomer.CustomerName).FirstOrDefault(),
                                //                              MarketingName = (from y in db.AptTranss
                                //                                               where y.UnitID == y.UnitID
                                //                                               select y.AptMarketing.MarketingName).FirstOrDefault(),
                                //                              PaymentName = (from y in db.AptTranss
                                //                                             where y.UnitID == y.UnitID
                                //                                             select y.AptBayar.CaraBayar).FirstOrDefault()

                            }).ToList();

            foreach (var y in db.AptTranss)
            {
                (from e in listUnit
                 where e.UnitID == y.UnitID
                 select e).ForEach(x => {
                     x.CustomerName = y.ArCustomer.CustomerName; x.MarketingName = y.AptMarketing.MarketingName;
                     x.PaymentName = y.AptBayar.CaraBayar; x.NoRef = y.NoRef;
                     x.Piutang = y.Piutang;
                     x.Sisa = y.Piutang;
                     x.CustomerID = y.CustomerID;
                 });
            }

            foreach (var y in db.AptSPesanans)
            {
                (from e in listUnit
                 where e.NoRef == y.SPesanan
                 select e).ForEach(x => {
                     y.Bayar = db.ArTransDs.Where(r => r.SPesananID == y.SPesananID).Select(r => r.Bayar + r.Diskon).DefaultIfEmpty(0).Sum();
                     x.Pembayaran = x.Pembayaran + y.Bayar;
                     x.Sisa = x.Sisa - y.Bayar;
                 });
            }

            foreach (var y in db.CbTranss)
            {
                (from e in listUnit
                 where e.UnitID == y.UnitID
                 select e).ForEach(x => {
                     x.Pembayaran = x.Pembayaran + y.Payment; x.Sisa = x.Sisa - y.Payment;
                 });
            }

    
            var dbResult = listUnit; 

            var employees = (from employee in dbResult
                             select new
                             {
                                 employee.UnitNo,
                                 employee.Lantai,
                                 employee.Categorie,
                                 employee.Status,      
                                 employee.Luas,
                                 employee.CustomerName,
                                 employee.MarketingName,
                                 employee.PaymentName,
                                 employee.Piutang,
                                 employee.Pembayaran,
                                 employee.Sisa,
                                 employee.NoRef



                             });
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Tabular()
        {
            // TabularViewModel TabelView = new TabularViewModel();
            //  TabelView.Gedungs = db.AptGedungs.ToList();
            //   TabelView.Units = db.AptUnits.ToList();
            //   TabelView.Kategoris = db.AptCategories.ToList();

            return View(db.AptGedungs.ToList());

        }

        public JsonResult GetLevel()
        {

            var Gedung = db.AptGedungs.ToList();
            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            var listUnit = (from e in Gedung
                            select new GedungViewsModels
                            {

                                GedungID = e.GedungID,
                                Gedung = e.Gedung,
                                Lantai1 = e.Lantai1,
                                Lantai2 = e.Lantai2
                            }).ToList();

            /*           foreach (var y in db.AptTranss)
                       {
                           (from e in listUnit
                            where e.UnitID == y.UnitID
                            select e).ForEach(x => {
                                x.CustomerName = y.ArCustomer.CustomerName; x.MarketingName = y.AptMarketing.MarketingName;
                                x.PaymentName = y.AptBayar.CaraBayar; x.NoRef = y.NoRef;
                                x.Piutang = y.Piutang;
                                x.Sisa = y.Piutang;
                                x.CustomerID = y.CustomerID;
                            });
                       }

                       foreach (var y in db.AptSPesanans)
                       {
                           (from e in listUnit
                            where e.NoRef == y.SPesanan
                            select e).ForEach(x => {
                                x.Pembayaran = x.Pembayaran + y.Bayar; x.Sisa = x.Sisa - y.Bayar;
                            });
                       }

                       foreach (var y in db.CbTranss)
                       {
                           (from e in listUnit
                            where e.UnitID == y.UnitID
                            select e).ForEach(x => {
                                x.Pembayaran = x.Pembayaran + y.Payment; x.Sisa = x.Sisa - y.Payment;
                            });
                       }

               */
            var dbResult = listUnit;

            var employees = (from employee in dbResult
                             select new
                             {
                                 employee.UnitNo,
                                 employee.Lantai,
                                 employee.Categorie,
                                 employee.Status,
                                 employee.Luas,
                                 employee.CustomerName,
                                 employee.MarketingName,
                                 employee.PaymentName,
                                 employee.Piutang,
                                 employee.Pembayaran,
                                 employee.Sisa,
                                 employee.NoRef



                             });
            return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
        }
    }
}