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
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class LaporanPiutangController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: LaporanPiutang
        public ActionResult Index()
        {
             var ListPiutang = db.AptTranss.ToList();

             var Trans1 = (from e in ListPiutang
                                                    select new LaporanPiutangVM
                                                    {
                                                        SpesananGd = e.SpesananGd,
                                                        NoRef = e.NoRef,
                                                        TransID = e.TransID,
                                                        TransNoID = e.TransNoID,
                                                        BayarID = e.BayarID,
                                                        CustomerID = e.CustomerID,
                                                        MarketingID = e.MarketingID,
                                                        UnitID = e.UnitID,
                                                        PaymentName = db.AptBayars.Find(e.BayarID).CaraBayar,
                                                        CustomerName = db.ArCustomers.Find(e.CustomerID).CustomerName,
                                                        MarketingName = db.AptMarketings.Find(e.MarketingID).MarketingName,
                                                        UnitNo = db.AptUnits.Find(e.UnitID).UnitNo,
                                                        Harga = e.Harga,
                                                        BookingFee = 0,
                                                        BonusFee = 0,
                                                        Piutang = 0,
                                                        Bayar = 0,
                                                        Sisa = 0
                                                    }).ToList();


            var ListCb = from e in db.CbTranss
                         where e.TransNoID == 1
                         select new UnitPiutang { NoRef = e.NoRef, Tanggal = e.Tanggal, UnitID = e.UnitID, CustomerID = e.PersonID, UnitNo = e.AptUnit.UnitNo, Angsuran = 0, Bayar = e.Payment, Keterangan = e.Keterangan ?? "Booking Fee" };

            var ListBn = from e in db.CbTranss
                         where e.TransNoID == 2
                         select new UnitPiutang { NoRef = e.NoRef, Tanggal = e.Tanggal, UnitID = e.UnitID, CustomerID = e.PersonID, UnitNo = e.AptUnit.UnitNo, Angsuran = 0, Bayar = e.Payment, Keterangan = e.Keterangan ?? "Booking Fee" };

            var ListSp = from e in db.AptSPesanans
                         join y in db.AptTranss on e.SpesananGd equals y.SpesananGd
                         select new UnitPiutang { NoRef = e.SPesanan, Tanggal = e.Duedate, UnitID = y.UnitID, CustomerID = y.CustomerID, Angsuran = e.Jumlah, Bayar = e.Bayar, Keterangan = e.Keterangan };

            var ListByr = from e in db.ArTransDs
                         join y in db.AptSPesanans on e.SPesananID equals y.SPesananID
                         join t in db.AptTranss on y.SpesananGd equals t.SpesananGd
                         select new UnitPiutang { NoRef = e.Bukti, Tanggal = e.Tanggal, UnitID = t.UnitID, CustomerID = e.CustomerID, Angsuran = e.Piutang, Bayar = e.Bayar+e.Diskon, Keterangan = e.Keterangan };

            foreach (var y in ListCb)
            {
                (from e in Trans1
                 where e.UnitID == y.UnitID && e.CustomerID == y.CustomerID
                 select e).ForEach(x =>
                 {
                     x.BookingFee = x.BookingFee + y.Bayar;
                 });
            }
            foreach (var y in ListBn)
            {
                (from e in Trans1
                 where e.UnitID == y.UnitID && e.CustomerID == y.CustomerID
                 select e).ForEach(x =>
                 {
                     x.BonusFee = x.BonusFee + y.Bayar;
                 });
            }

            foreach (var y in ListSp)
            {
                (from e in Trans1
                 where e.UnitID == y.UnitID && e.CustomerID == y.CustomerID
                 select e).ForEach(x =>
                 {
                     x.Piutang = x.Piutang + y.Angsuran;
                 });
            }
            foreach (var y in ListByr)
            {
                (from e in Trans1
                 where e.UnitID == y.UnitID && e.CustomerID == y.CustomerID
                 select e).ForEach(x =>
                 {
                     x.Bayar = x.Bayar + y.Bayar;
                 });
            }
            return View(Trans1);
        }
    }
}