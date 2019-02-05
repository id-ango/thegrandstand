using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;
using Newtonsoft.Json.Linq;

namespace GlobalSoft.Controllers
{
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class SuratPesananController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        public ActionResult CekCustomer(int Custid, int Unitid)
        {
            var allList2 = (from e in db.CbTranss
                            where e.UnitID == Unitid
                            select new { e.PersonID, e.MarketingID }).ToList().LastOrDefault();

            decimal Book1 = 0;

            Book1 = (from e in db.CbTranss
                     where (e.UnitID == Unitid && e.PersonID == allList2.PersonID) && (e.TransNoID == 1 || e.TransNoID == 2)
                     select e.Payment).Sum();


            CbTrans allList = new CbTrans();
            allList.PersonID = allList2.PersonID;
            allList.MarketingID = allList2.MarketingID;
            allList.Piutang = Book1;

            return Json(allList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CekBook(int Custid, int Unitid, decimal harga, int cicil)
        {
            decimal Book1 = 0;
            Book1 = (from e in db.CbTranss
                     where (e.UnitID == Unitid && e.PersonID == Custid) && (e.TransNoID == 1 || e.TransNoID == 2)
                     select e.Payment).Sum();

            AptTrans allList = new AptTrans();


            decimal total = (harga - Book1) / cicil;
            Console.Write(Book1);
            Console.WriteLine(total);

            allList.Payment = total;
            allList.Harga = (harga - Book1);
            allList.Piutang = Book1;

            return Json(allList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CekUM(int Custid, int Unitid)
        {
            //  var TransUTJ = db.CbTranss.Include(c => c.AptUnit).Include(c => c.AptPayment).Include(c => c.AptTrsNo);
            var ListUangMuka = (from e in db.CbTranss
                                where e.UnitID == Unitid && e.PersonID == Custid
                                select new { e.Keterangan, e.Payment, e.NoRef, e.AptPayment.PaymentName, e.Tanggal }).ToList();
            return Json(ListUangMuka, JsonRequestBehavior.AllowGet);
        }

        // GET: SuratPesanan
        public ActionResult Index()
        {
            List<AptTrans> TipeGl = new List<AptTrans>();

            TipeGl.Add(new AptTrans { NoRef = "SP-0000001", Tanggal = Convert.ToDateTime(",2017-07-28"), CustomerID = 38, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-07-28"), Unit = "1018", Piutang = 531719773.92M, Cicilan = 36, Payment = 433375819.2M, Harga = 541719774, Angsuran = 108343954.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000003", Tanggal = Convert.ToDateTime(",2017-08-01"), CustomerID = 28, MarketingID = 1, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-08-01"), Unit = "0927", Piutang = 663199980M, Cicilan = 0, Payment = 0M, Harga = 673199980, Angsuran = 663199980M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000004", Tanggal = Convert.ToDateTime(",2017-08-08"), CustomerID = 68, MarketingID = 2, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-08-08"), Unit = "1512", Piutang = 782266108.85M, Cicilan = 60, Payment = 13204435.15M, Harga = 792266109, Angsuran = 792266109M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000006", Tanggal = Convert.ToDateTime(",2017-08-17"), CustomerID = 9, MarketingID = 4, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-08-17"), Unit = "1011", Piutang = 492423557.96M, Cicilan = 36, Payment = 401938846.4M, Harga = 502423558, Angsuran = 100484711.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000007", Tanggal = Convert.ToDateTime(",2017-08-16"), CustomerID = 52, MarketingID = 5, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-08-16"), Unit = "0727", Piutang = 887577534.08M, Cicilan = 36, Payment = 718062027.2M, Harga = 897577534, Angsuran = 179515506.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000009", Tanggal = Convert.ToDateTime(",2017-08-20"), CustomerID = 77, MarketingID = 7, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-08-20"), Unit = "0923", Piutang = 887577534.08M, Cicilan = 36, Payment = 718062027.2M, Harga = 897577534, Angsuran = 179515506.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000010", Tanggal = Convert.ToDateTime(",2017-08-16"), CustomerID = 39, MarketingID = 8, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-08-16"), Unit = "1212", Piutang = 808595244M, Cicilan = 40, Payment = 654876195.2M, Harga = 818595244, Angsuran = 163719048.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000011", Tanggal = Convert.ToDateTime(",2017-08-17"), CustomerID = 42, MarketingID = 9, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-08-17"), Unit = "1027", Piutang = 887577534.08M, Cicilan = 36, Payment = 718062027.2M, Harga = 897577534, Angsuran = 179515506.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000012", Tanggal = Convert.ToDateTime(",2017-08-22"), CustomerID = 90, MarketingID = 10, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-08-22"), Unit = "0718", Piutang = 531719773.92M, Cicilan = 36, Payment = 433375819.2M, Harga = 541719774, Angsuran = 108343954.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000013", Tanggal = Convert.ToDateTime(",2017-08-16"), CustomerID = 43, MarketingID = 11, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-08-16"), Unit = "0911", Piutang = 476747550.6M, Cicilan = 60, Payment = 7945792.51M, Harga = 486747551, Angsuran = 476747551M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000014", Tanggal = Convert.ToDateTime(",2017-08-26"), CustomerID = 85, MarketingID = 6, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-08-26"), Unit = "2708", Piutang = 2600621269.3M, Cicilan = 36, Payment = 72656146.38M, Harga = 2615621270, Angsuran = 2615621270M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000015", Tanggal = Convert.ToDateTime(",2017-08-25"), CustomerID = 21, MarketingID = 12, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-08-25"), Unit = "1017", Piutang = 464030195.76M, Cicilan = 36, Payment = 12889727.66M, Harga = 474030196, Angsuran = 464030196M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000016", Tanggal = Convert.ToDateTime(",2017-08-30"), CustomerID = 31, MarketingID = 11, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-08-30"), Unit = "2706", Piutang = 2085000000M, Cicilan = 0, Payment = 0M, Harga = 2100000000, Angsuran = 2085000000M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-0000021", Tanggal = Convert.ToDateTime(",2017-09-14"), CustomerID = 60, MarketingID = 13, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-09-14"), Unit = "1501", Piutang = 1628200452M, Cicilan = 8, Payment = 203525056.5M, Harga = 1628200452, Angsuran = 1628200452M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881122", Tanggal = Convert.ToDateTime(",2017-09-18"), CustomerID = 29, MarketingID = 12, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-09-18"), Unit = "0919", Piutang = 531719773.92M, Cicilan = 36, Payment = 433375819.2M, Harga = 541719774, Angsuran = 108343954.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881125", Tanggal = Convert.ToDateTime(",2017-10-20"), CustomerID = 24, MarketingID = 15, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-10-20"), Unit = "1026", Piutang = 778780256.96M, Cicilan = 36, Payment = 631024205.6M, Harga = 788780257, Angsuran = 157756051.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881128", Tanggal = Convert.ToDateTime(",2017-10-21"), CustomerID = 6, MarketingID = 22, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-10-21"), Unit = "0712", Piutang = 507496262.96M, Cicilan = 36, Payment = 413997010.4M, Harga = 517496263, Angsuran = 103499252.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881132", Tanggal = Convert.ToDateTime(",2017-10-30"), CustomerID = 45, MarketingID = 12, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-10-30"), Unit = "1005", Piutang = 547971368.16M, Cicilan = 36, Payment = 446377094.4M, Harga = 557971368, Angsuran = 111594273.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881136", Tanggal = Convert.ToDateTime(",2017-11-21"), CustomerID = 22, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-11-21"), Unit = "0812", Piutang = 514908783.07M, Cicilan = 39, Payment = 413997011.2M, Harga = 517496264, Angsuran = 103499252.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881137", Tanggal = Convert.ToDateTime(",2017-10-25"), CustomerID = 40, MarketingID = 25, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-10-25"), Unit = "0912", Piutang = 517496263.04M, Cicilan = 36, Payment = 413997010.4M, Harga = 517496263, Angsuran = 103499252.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881138", Tanggal = Convert.ToDateTime(",2017-11-17"), CustomerID = 10, MarketingID = 13, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-11-17"), Unit = "0818", Piutang = 555314584.17M, Cicilan = 41, Payment = 446377331.2M, Harga = 557971590, Angsuran = 111594258.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881139", Tanggal = Convert.ToDateTime(",2017-12-04"), CustomerID = 61, MarketingID = 13, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-04"), Unit = "0918", Piutang = 555109975.96M, Cicilan = 38, Payment = 446377094.4M, Harga = 557971368, Angsuran = 111594273.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881140", Tanggal = Convert.ToDateTime(",2017-12-04"), CustomerID = 86, MarketingID = 12, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-04"), Unit = "0819", Piutang = 547971368.16M, Cicilan = 36, Payment = 446377094.4M, Harga = 557971368, Angsuran = 111594273.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881141", Tanggal = Convert.ToDateTime(",2017-12-04"), CustomerID = 16, MarketingID = 12, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-04"), Unit = "0803", Piutang = 547971368.16M, Cicilan = 36, Payment = 446377094.4M, Harga = 557971368, Angsuran = 111594273.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881142", Tanggal = Convert.ToDateTime(",2017-11-24"), CustomerID = 87, MarketingID = 28, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-11-24"), Unit = "1209", Piutang = 926166227.96M, Cicilan = 36, Payment = 748932982.4M, Harga = 936166228, Angsuran = 187233245.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881144", Tanggal = Convert.ToDateTime(",2017-12-06"), CustomerID = 47, MarketingID = 29, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-06"), Unit = "0823", Piutang = 914504859.08M, Cicilan = 36, Payment = 739603887.2M, Harga = 924504859, Angsuran = 184900971.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881145", Tanggal = Convert.ToDateTime(",2017-12-04"), CustomerID = 17, MarketingID = 24, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-12-04"), Unit = "1019", Piutang = 430000000M, Cicilan = 0, Payment = 0M, Harga = 435000000, Angsuran = 430000000M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881146", Tanggal = Convert.ToDateTime(",2017-10-31"), CustomerID = 7, MarketingID = 21, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-10-31"), Unit = "1012", Piutang = 507496264.12M, Cicilan = 36, Payment = 413997011.2M, Harga = 517496264, Angsuran = 103499252.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881149", Tanggal = Convert.ToDateTime(",2017-12-11"), CustomerID = 8, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-11"), Unit = "0811", Piutang = 514842436.82M, Cicilan = 38, Payment = 413997011.2M, Harga = 517496264, Angsuran = 103499252.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881150", Tanggal = Convert.ToDateTime(",2017-12-18"), CustomerID = 62, MarketingID = 22, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-18"), Unit = "0817", Piutang = 547971367M, Cicilan = 36, Payment = 446377093.6M, Harga = 557971367, Angsuran = 111594273.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881152", Tanggal = Convert.ToDateTime(",2017-09-18"), CustomerID = 12, MarketingID = 6, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-09-18"), Unit = "0909", Piutang = 771050516.04M, Cicilan = 36, Payment = 21418069.89M, Harga = 781050516, Angsuran = 771050516M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881153", Tanggal = Convert.ToDateTime(",2017-12-27"), CustomerID = 34, MarketingID = 28, BayarID = 2, TglSelesai = Convert.ToDateTime("2017-12-27"), Unit = "1505", Piutang = 832314984.84M, Cicilan = 36, Payment = 673851981.6M, Harga = 842314985, Angsuran = 168463003.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881155", Tanggal = Convert.ToDateTime(",2017-11-26"), CustomerID = 88, MarketingID = 27, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-11-26"), Unit = "0917", Piutang = 483251084M, Cicilan = 49, Payment = 8137518M, Harga = 488251102, Angsuran = 483251102M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881156", Tanggal = Convert.ToDateTime(",2018-10-25"), CustomerID = 57, MarketingID = 13, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-10-25"), Unit = "1511", Piutang = 1726170302.88M, Cicilan = 36, Payment = 47949175.08M, Harga = 1736170303, Angsuran = 1726170303M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881158", Tanggal = Convert.ToDateTime(",2018-03-08"), CustomerID = 71, MarketingID = 21, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-03-08"), Unit = "1502A", Piutang = 750983734M, Cicilan = 60, Payment = 12516395.9M, Harga = 760983754, Angsuran = 750983754M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881159", Tanggal = Convert.ToDateTime(",2017-10-31"), CustomerID = 46, MarketingID = 13, BayarID = 1, TglSelesai = Convert.ToDateTime("2017-10-31"), Unit = "2808", Piutang = 2684089906.92M, Cicilan = 36, Payment = 74558052.97M, Harga = 2694089907, Angsuran = 2684089907M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881160", Tanggal = Convert.ToDateTime(",2018-03-27"), CustomerID = 11, MarketingID = 18, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-03-27"), Unit = "0726", Piutang = 855322517.04M, Cicilan = 36, Payment = 692258013.6M, Harga = 865322517, Angsuran = 173064503.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881161", Tanggal = Convert.ToDateTime(",2018-03-27"), CustomerID = 72, MarketingID = 19, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-03-27"), Unit = "0717", Piutang = 547971367M, Cicilan = 36, Payment = 446377093.6M, Harga = 557971367, Angsuran = 111594273.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881162", Tanggal = Convert.ToDateTime(",2018-02-26"), CustomerID = 25, MarketingID = 8, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-02-26"), Unit = "0902", Piutang = 643690303.92M, Cicilan = 36, Payment = 522952243.2M, Harga = 653690304, Angsuran = 130738060.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881163", Tanggal = Convert.ToDateTime(",2018-02-26"), CustomerID = 25, MarketingID = 8, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-02-26"), Unit = "0903", Piutang = 547971368.16M, Cicilan = 36, Payment = 446377094.4M, Harga = 557971368, Angsuran = 111594273.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881164", Tanggal = Convert.ToDateTime(",2018-04-08"), CustomerID = 26, MarketingID = 22, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-04-08"), Unit = "0805", Piutang = 547971367M, Cicilan = 36, Payment = 446377093.6M, Harga = 557971367, Angsuran = 111594273.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881165", Tanggal = Convert.ToDateTime(",2018-04-17"), CustomerID = 26, MarketingID = 22, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-04-17"), Unit = "0806", Piutang = 547971367M, Cicilan = 36, Payment = 446377093.6M, Harga = 557971367, Angsuran = 111594273.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881166", Tanggal = Convert.ToDateTime(",2018-05-11"), CustomerID = 2, MarketingID = 8, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-05-11"), Unit = "0719", Piutang = 547971367M, Cicilan = 36, Payment = 446377093.6M, Harga = 557971367, Angsuran = 111594273.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881169", Tanggal = Convert.ToDateTime(",2018-05-11"), CustomerID = 81, MarketingID = 8, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-05-11"), Unit = "0815", Piutang = 2023443770.16M, Cicilan = 36, Payment = 1626755016M, Harga = 2033443770, Angsuran = 406688754M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881170", Tanggal = Convert.ToDateTime(",2018-05-24"), CustomerID = 74, MarketingID = 13, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-05-24"), Unit = "1105", Piutang = 453251102.04M, Cicilan = 18, Payment = 25180616.78M, Harga = 463251102, Angsuran = 453251102M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881171", Tanggal = Convert.ToDateTime(",2018-06-02"), CustomerID = 18, MarketingID = 30, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-06-02"), Unit = "1111", Piutang = 507496263.98M, Cicilan = 18, Payment = 439871824.4M, Harga = 517496264, Angsuran = 77624439.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881173", Tanggal = Convert.ToDateTime(",2018-07-06"), CustomerID = 48, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-06"), Unit = "0711", Piutang = 514621284.95M, Cicilan = 35, Payment = 413997011.2M, Harga = 517496264, Angsuran = 103499252.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881174", Tanggal = Convert.ToDateTime(",2018-07-02"), CustomerID = 56, MarketingID = 30, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-02"), Unit = "0723", Piutang = 914504859.98M, Cicilan = 18, Payment = 785829131M, Harga = 924504860, Angsuran = 138675729M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881176", Tanggal = Convert.ToDateTime(",2018-07-23"), CustomerID = 82, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-23"), Unit = "0821", Piutang = 629682647.75M, Cicilan = 26, Payment = 543730256.75M, Harga = 639682655, Angsuran = 95952398.25M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881177", Tanggal = Convert.ToDateTime(",2018-07-21"), CustomerID = 49, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-21"), Unit = "0925", Piutang = 855322539.85M, Cicilan = 19, Payment = 735524159.85M, Harga = 865322541, Angsuran = 129798381.15M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881178", Tanggal = Convert.ToDateTime(",2018-07-28"), CustomerID = 64, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-28"), Unit = "0926", Piutang = 855322543.85M, Cicilan = 26, Payment = 735524159.85M, Harga = 865322541, Angsuran = 129798381.15M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881179", Tanggal = Convert.ToDateTime(",2018-07-21"), CustomerID = 23, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-21"), Unit = "0827", Piutang = 914504871M, Cicilan = 26, Payment = 785829131M, Harga = 924504860, Angsuran = 138675729M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881180", Tanggal = Convert.ToDateTime(",2018-08-04"), CustomerID = 53, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-08-04"), Unit = "1110", Piutang = 657359430.6M, Cicilan = 27, Payment = 567255520.6M, Harga = 667359436, Angsuran = 100103915.4M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881182", Tanggal = Convert.ToDateTime(",2018-07-28"), CustomerID = 35, MarketingID = 30, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-28"), Unit = "1126", Piutang = 855322543.85M, Cicilan = 26, Payment = 735524159.85M, Harga = 865322541, Angsuran = 129798381.15M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881183", Tanggal = Convert.ToDateTime(",2018-08-05"), CustomerID = 54, MarketingID = 30, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-08-05"), Unit = "0507", Piutang = 914504859M, Cicilan = 19, Payment = 785829131M, Harga = 924504860, Angsuran = 138675729M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881184", Tanggal = Convert.ToDateTime(",2018-08-15"), CustomerID = 84, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-08-15"), Unit = "0906", Piutang = 547971367.95M, Cicilan = 26, Payment = 474275661.95M, Harga = 557971367, Angsuran = 83695705.05M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881185", Tanggal = Convert.ToDateTime(",2018-08-11"), CustomerID = 83, MarketingID = 1, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-08-11"), Unit = "1123", Piutang = 718086578M, Cicilan = 0, Payment = 0M, Harga = 728086580, Angsuran = 718086580M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881186", Tanggal = Convert.ToDateTime(",2018-08-15"), CustomerID = 3, MarketingID = 1, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-08-15"), Unit = "1125", Piutang = 747197791M, Cicilan = 0, Payment = 0M, Harga = 757197786, Angsuran = 747197786M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881187", Tanggal = Convert.ToDateTime(",2018-06-15"), CustomerID = 75, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-06-15"), Unit = "0921", Piutang = 661538852.2M, Cicilan = 25, Payment = 570808024.2M, Harga = 671538852, Angsuran = 100730827.8M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881188", Tanggal = Convert.ToDateTime(",2018-07-15"), CustomerID = 58, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-15"), Unit = "0825", Piutang = 855322544.85M, Cicilan = 26, Payment = 735524159.85M, Harga = 865322541, Angsuran = 129798381.15M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881189", Tanggal = Convert.ToDateTime(",2018-08-13"), CustomerID = 4, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-08-13"), Unit = "1103", Piutang = 547971362.8M, Cicilan = 19, Payment = 474275662.8M, Harga = 557971368, Angsuran = 83695705.2M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881190", Tanggal = Convert.ToDateTime(",2018-08-15"), CustomerID = 50, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-08-15"), Unit = "1112", Piutang = 507496256.4M, Cicilan = 26, Payment = 439871824.4M, Harga = 517496264, Angsuran = 77624439.6M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881192", Tanggal = Convert.ToDateTime(",2018-08-03"), CustomerID = 65, MarketingID = 31, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-08-03"), Unit = "1106", Piutang = 547971367.95M, Cicilan = 27, Payment = 474275661.95M, Harga = 557971367, Angsuran = 83695705.05M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881194", Tanggal = Convert.ToDateTime(",2018-07-31"), CustomerID = 30, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-31"), Unit = "2807", Piutang = 836505595.2M, Cicilan = 19, Payment = 719529759.15M, Harga = 846505599, Angsuran = 126975839.85M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881195", Tanggal = Convert.ToDateTime(",2018-09-11"), CustomerID = 76, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-09-11"), Unit = "1006", Piutang = 547971367.95M, Cicilan = 26, Payment = 474275661.95M, Harga = 557971367, Angsuran = 83695705.05M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881197", Tanggal = Convert.ToDateTime(",2018-07-30"), CustomerID = 20, MarketingID = 22, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-07-30"), Unit = "2806", Piutang = 2254749187M, Cicilan = 0, Payment = 0M, Harga = 2254749187, Angsuran = 2249749187M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881198", Tanggal = Convert.ToDateTime(",2018-09-08"), CustomerID = 89, MarketingID = 1, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-09-08"), Unit = "1119", Piutang = 547971361.95M, Cicilan = 19, Payment = 474275661.95M, Harga = 557971367, Angsuran = 83695705.05M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881199", Tanggal = Convert.ToDateTime(",2018-07-30"), CustomerID = 37, MarketingID = 23, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-30"), Unit = "1116", Piutang = 828124362.75M, Cicilan = 26, Payment = 712405701.75M, Harga = 838124355, Angsuran = 125718653.25M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881200", Tanggal = Convert.ToDateTime(",2018-07-28"), CustomerID = 32, MarketingID = 26, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-28"), Unit = "1117", Piutang = 547971374.8M, Cicilan = 25, Payment = 474275662.8M, Harga = 557971368, Angsuran = 83695705.2M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881201", Tanggal = Convert.ToDateTime(",2018-07-29"), CustomerID = 14, MarketingID = 30, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-07-29"), Unit = "1127", Piutang = 798985082M, Cicilan = 20, Payment = 39949254.45M, Harga = 808985089, Angsuran = 798985089M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881202", Tanggal = Convert.ToDateTime(",2018-09-08"), CustomerID = 27, MarketingID = 27, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-09-08"), Unit = "0503", Piutang = 914504871M, Cicilan = 26, Payment = 785829131M, Harga = 924504860, Angsuran = 138675729M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881203", Tanggal = Convert.ToDateTime(",2018-10-26"), CustomerID = 51, MarketingID = 23, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-10-26"), Unit = "1121", Piutang = 629682648.75M, Cicilan = 27, Payment = 543730256.75M, Harga = 639682655, Angsuran = 95952398.25M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881205", Tanggal = Convert.ToDateTime(",2018-11-10"), CustomerID = 15, MarketingID = 30, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-11-10"), Unit = "1611", Piutang = 1768255412M, Cicilan = 0, Payment = 295542568.5M, Harga = 1788255411, Angsuran = 1773255411M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881206", Tanggal = Convert.ToDateTime(",2018-11-10"), CustomerID = 41, MarketingID = 22, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-11-10"), Unit = "0826", Piutang = 845322544M, Cicilan = 25, Payment = 735524160M, Harga = 865322541, Angsuran = 129798381M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881207", Tanggal = Convert.ToDateTime(",2018-07-02"), CustomerID = 19, MarketingID = 30, BayarID = 2, TglSelesai = Convert.ToDateTime("2018-07-02"), Unit = "1023", Piutang = 904504871M, Cicilan = 29, Payment = 785829131M, Harga = 924504860, Angsuran = 138675729M, UnitID = 1, TransNoID = 2, PaymentID = 1 });
            TipeGl.Add(new AptTrans { NoRef = "SP-7881208", Tanggal = Convert.ToDateTime(",2018-11-12"), CustomerID = 66, MarketingID = 27, BayarID = 1, TglSelesai = Convert.ToDateTime("2018-11-12"), Unit = "1010", Piutang = 573970781M, Cicilan = 29, Payment = 18799026M, Harga = 563970790, Angsuran = 563970790M, UnitID = 1, TransNoID = 2, PaymentID = 1 });



            var cekNull = (from e in db.AptTranss select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptTranss.Add(values);
                    db.SaveChanges();
                }


            }
            var aptTranss2 = db.AptTranss.Include(a => a.AptMarketing).Include(a => a.AptUnit).Include(a => a.AptBayar);
            var aptTranss = from e in aptTranss2
                            select e;


            return View(aptTranss.ToList());
        }

        // GET: SuratPesanan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrans aptTrans = db.AptTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            return View(aptTrans);
        }

        // GET: SuratPesanan/Create

        public ActionResult Create()
        {


            var unitList = from e in db.AptUnits
                           where e.StatusID == 2
                           select e;

            var kodeno = "SP-788";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno;  //   + thnbln;
            var maxvalue = "";
            var maxlist = db.AptTranss.Where(x => x.NoRef.Substring(0, 6).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.NoRef);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "0000";
            if (maxvalue == null)
            {
                nourut = "0000";
            }
            else
            {
                nourut = maxvalue.Substring(6, 4);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeno  + (Int32.Parse(nourut) + 1).ToString("0000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            string cNoref = cAngNo;

            ViewBag.NoRef = cNoref;

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName");
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar");
            ViewBag.UnitID = new SelectList(unitList, "UnitID", "UnitNo");
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: SuratPesanan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,Keterangan,Angsuran,Piutang,Harga,BayarID,Cicilan")] AptTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                var validUnit = (from e in db.AptUnits
                                 where e.UnitID == aptTrans.UnitID && e.StatusID == 2   //status hold
                                 select e).FirstOrDefault();

                if (validUnit != null)     // jika tidak ketemu dengan unit yang hold
                {


                    aptTrans.TransNoID = 2;        //surat Pesanan Transaksi
                    aptTrans.TglSelesai = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, aptTrans.Cicilan);
                    //var CekID = db.AptPayments.FirstOrDefault(x => x.PaymentName.Trim() == "Tunai");
                    //                aptTrans.PaymentID 
                    aptTrans.PaymentID = 1;

                    //update to sold
                    (from u in db.AptUnits
                     where u.UnitID == aptTrans.UnitID
                     select u).ToList().ForEach(x => x.StatusID = 3);

                    db.AptTranss.Add(aptTrans);
                    //   db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "This unit is Not Yet Reservasi!");
                }
            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // GET: SuratPesanan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrans aptTrans = db.AptTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // POST: SuratPesanan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,NoRef,Tanggal,UnitID,CustomerID,MarketingID,BayarID,Keterangan,Piutang,Angsuran,Harga,Cicilan")] AptTrans aptTrans)
        {
            aptTrans.TransNoID = 2;        //surat Pesanan Transaksi
            aptTrans.TglSelesai = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, aptTrans.Cicilan);
            // var CekID = db.AptPayments.FirstOrDefault(x => x.PaymentName.Trim() == "Tunai");
            //                aptTrans.PaymentID 
            aptTrans.PaymentID = 1;

            if (ModelState.IsValid)
            {
                db.Entry(aptTrans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.BayarID = new SelectList(db.AptBayars, "BayarID", "CaraBayar", aptTrans.BayarID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.CustomerID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.CustomerID);
            return View(aptTrans);
        }

        // GET: SuratPesanan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptTrans aptTrans = db.AptTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            return View(aptTrans);
        }

        // POST: SuratPesanan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]        
        public ActionResult DeleteConfirmed(int id)
        {
            AptTrans aptTrans = db.AptTranss.Find(id);

           // int nRec = (from e in db.CbTranss
           //             where e.UnitID == aptTrans.UnitID
           //             select e).Count();

            db.AptUnits.Find(aptTrans.UnitID).StatusID = 2;

           // if (nRec != 0)
           // {
           //     (from e in db.AptUnits
           //      where e.UnitID == aptTrans.UnitID
           //      select e).ToList().ForEach(x => x.StatusID = 2);
           // }
            List<AptSPesanan> aptsp = db.AptSPesanans.Where(e => e.SPesanan == aptTrans.NoRef).ToList();
           // foreach (var i in aptsp)
           //     db.AptSPesanans.Remove(i);
            db.AptSPesanans.RemoveRange(aptsp);
            db.AptTranss.Remove(aptTrans);
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

        public ActionResult SPesanan(string noref,int cetak)
        {
            AptTrans TransSP = (from e in db.AptTranss
                                where e.NoRef == noref
                                select e).FirstOrDefault();

            int Unitid = TransSP.UnitID;
            int Custid = TransSP.CustomerID;
            int ref_menu = TransSP.BayarID;


            var ListUangMuka = (from e in db.CbTranss
                                where e.UnitID == Unitid && e.PersonID == Custid
                                select e).ToList();

            var unitNo = db.AptUnits.Find(Unitid).UnitNo;

            decimal Uangmuka = 0;

            if (ListUangMuka != null)
            {
                Uangmuka = ListUangMuka.Sum(x => x.Payment);
            }

            ViewBag.Carabayar = ref_menu == 1 ? "InHouse" : "KPA";

            List<ArPiutang> Transaksi = new List<ArPiutang>();

            decimal JumAngsur = 0;
            decimal Total = 0;

            var cekNull = (from e in db.AptSPesanans where e.SPesanan == noref select e).Count();
            if (cekNull != 0)
            {
                var ListTrans = (from e in db.AptSPesanans where e.SPesanan == noref select e).ToList();


                int i = 1;
              
                var dTgl1 = DateTime.Now;
                var dTgl2 = DateTime.Now;
                string Ket7 = " ";
                foreach (var e in ListTrans)
                {
                    Total += e.Jumlah;
                    if (cetak != 3)
                    {
                        if (i <= 6)
                        {
                            Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = e.Jumlah });

                        }

                        else
                        {
                            JumAngsur = JumAngsur + e.Jumlah;

                            if (i == 7)
                            {
                                Ket7 = string.Format("{0} dr Tgl {1:d} ", e.Keterangan.Trim(), e.Duedate);

                            }

                            switch (ref_menu)
                            {
                                case 1:
                                    if (i == cekNull)
                                    {
                                        Ket7 = Ket7 + string.Format("sd {0} ", e.Keterangan.Trim());
                                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = JumAngsur });

                                    };
                                    break;
                                case 2:
                                    if (i == (cekNull - 1))
                                    {
                                        Ket7 = Ket7 + string.Format("sd {0} ", e.Keterangan.Trim());
                                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = Ket7, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = JumAngsur });

                                    };
                                    if (i == cekNull)
                                    {
                                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = e.Jumlah });

                                    };
                                    break;
                            }



                        }
                    }
                    else
                    {
                        Transaksi.Add(new ArPiutang { LPB = e.SPesanan, Keterangan = e.Keterangan, Duedate = e.Duedate, Tanggal = e.Tanggal, Jumlah = e.Jumlah });

                    }
                    i++;
                }

            }




            ViewBag.ListTransaksi = Transaksi;

            ViewBag.UangMuka = Uangmuka;
                   ViewBag.Num2Char = FungsiController.Fungsi.NumberToText((long)TransSP.Harga);
            var TransUTJ = db.CbTranss.Include(c => c.AptUnit).Include(c => c.AptPayment).Include(c => c.AptTrsNo);


            ViewBag.ListUangMuka = ListUangMuka;

            if (cetak == 1)
                return Json("Success", JsonRequestBehavior.AllowGet);

            return View(TransSP);
        }



        public ActionResult PesananInHouse(int Unitid, int Custid, string UnitNo, decimal angsuran, DateTime tanggal, int cicilan, decimal sisakpa, string ref_this)
        {


            //  var Tanggal = Convert.ToDateTime(tanggal);
            var Tanggal = tanggal;

            //  List<ArPiutang> Transaksi = new List<ArPiutang>();
            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();



            //decimal PPN = (aptTrans.Piutang * (decimal)0.1);
            //  decimal PPN = 0;
            //   decimal DPP = (aptTrans.Piutang + PPN) - Uangmuka;




            //    var TglAwal = FungsiController.Fungsi.HitungAngsuran(Tanggal, 6);


            for (int i = 0; i < cicilan; i++)
            {
                var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(Tanggal, i);
                //     TglAwal = FungsiController.Fungsi.HitungAngsuran(aptTrans.Tanggal, 7);

                Transaksi2.Add(new AptSPesanan { Keterangan = string.Format("Angsuran {0} Unit {1}", i + 1, UnitNo), Tanggal = TglAngsuran, Jumlah = angsuran });

            };
            if (ref_this == "#menu2")
            {
                var TglAngsuran = FungsiController.Fungsi.HitungAngsuran(Tanggal, cicilan);
                Transaksi2.Add(new AptSPesanan { Keterangan = string.Format("KPA Unit {0}", UnitNo), Tanggal = TglAngsuran, Jumlah = sisakpa });

            }
            return PartialView(Transaksi2);
        }
      

        public ActionResult SaveOrder(string bukti, string keterangan, string tanggal, int row_num, int row_cust,
                    int marketing, decimal harga1, decimal piutang1, int cicil1, decimal angsuran1,
                    decimal harga2, decimal piutang2, int cicil2, decimal angsuran2, decimal sisakpa,
                    string ref_this, SpesananVM[] order)
        {
            string result = "Error! Surat Pesanan Is Not Complete!";
            AptTrans model = new AptTrans();

            if (bukti != null && order != null)
            {



                //   var cutomerId = Guid.NewGuid();

                var CutomerId = Guid.NewGuid();

                model.SpesananGd = CutomerId;
                model.NoRef = bukti;
                model.Keterangan = keterangan;
                model.Tanggal = Convert.ToDateTime(tanggal);
                model.TglSelesai = Convert.ToDateTime(tanggal);              
                model.UnitID = row_num;
                model.CustomerID = row_cust;
                model.MarketingID = marketing;
                model.TransNoID = 1;
                if (ref_this == "#menu1")
                {
                    model.Harga = harga1;
                    model.Piutang = piutang1;
                    model.Angsuran = angsuran1;
                    model.Cicilan = cicil1;
                    model.Payment = 0;
                    model.PaymentID = 2;
                    model.BayarID = 1;
                }
                else
                {
                    model.Harga = harga2;
                    model.Piutang = piutang2;
                    model.Angsuran = angsuran2;
                    model.Cicilan = cicil2;
                    model.Payment = sisakpa;
                    model.PaymentID = 2;
                    model.BayarID = 2;
                }

                //       db.AptTranss.Add(model);

                foreach (var item in order)
                {
                    if (item.Jumlah != 0)
                    {

                        AptSPesanan O = new AptSPesanan();
                        O.SPesanan = model.NoRef;
                        O.SpesananGd = CutomerId;
                        O.Keterangan = item.Keterangan;
                        O.Tanggal = Convert.ToDateTime(tanggal);
                        O.Duedate = Convert.ToDateTime(item.Duedate);
                        O.Jumlah = item.Jumlah;
                        O.KodeTrans = 0;
                        db.AptSPesanans.Add(O);

                        model.TglSelesai = Convert.ToDateTime(item.Duedate);
                    }
                }

                db.AptTranss.Add(model);

                //update to sold

                db.AptUnits.Find(row_num).StatusID = 3;

                db.SaveChanges();
                result = "Success! Pembayaran Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditPesanan(string noref)
        {

          var  Transaksi = (from e in db.AptSPesanans
                              where e.SPesanan == noref
                              select new {
                                  e.SPesananID,
                                  e.Duedate,
                                  e.Keterangan,
                                  Sisa = db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                  Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                  e.SpesananGd                                  
                              }).ToList();

            List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();

            foreach (var i in Transaksi)
            {
                if (i.Sisa == 0)
                {
                    Transaksi2.Add(new AptSPesanan
                    {

                        SPesananID = i.SPesananID,
                        Duedate = i.Duedate,
                        Keterangan = i.Keterangan,
                        Jumlah = i.Jumlah,
                        SpesananGd = i.SpesananGd

                    });
                }
            }
                return PartialView(Transaksi2);
        }

        public ActionResult SimpanEdit(string bukti, string keterangan, string tanggal, int row_num, int row_cust,
             int marketing,  AptSPesanan[] order)
        {
            string result = "Error! Surat Pesanan Is Not Complete!";
            AptTrans model = new AptTrans();

            if (bukti != null && order != null)
            {
                (from y in db.AptTranss
                  where y.NoRef == bukti
                  select y).ToList().ForEach(x => { x.Tanggal = Convert.ToDateTime(tanggal); x.Keterangan = keterangan; });

                var Transaksi = (from e in db.AptSPesanans
                                 where e.SPesanan == bukti
                                 select new
                                 {
                                     e.SPesananID,
                                     e.Duedate,
                                     e.Keterangan,
                                     Sisa = db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                     Jumlah = e.Jumlah - db.ArTransDs.Where(x => x.SPesananID == e.SPesananID).Select(x => x.Bayar + x.Diskon).DefaultIfEmpty(0).Sum(),
                                     e.SpesananGd
                                 }).ToList();

                List<AptSPesanan> Transaksi2 = new List<AptSPesanan>();

                foreach (var i in Transaksi)
                {
                    if (i.Sisa == 0)
                    {
                        Transaksi2.Add(new AptSPesanan
                        {

                            SPesananID = i.SPesananID,
                            Duedate = i.Duedate,
                            Keterangan = i.Keterangan,
                            Jumlah = i.Jumlah,
                            SpesananGd = i.SpesananGd

                        });
                    }
                }


                foreach (var e in Transaksi2)
                {
                   AptSPesanan MauHapus =  db.AptSPesanans.Find(e.SPesananID);
                    db.AptSPesanans.Remove(MauHapus);
                }
                

                db.SaveChanges();
              
                foreach (var e in order)
                {
                   // (from y in db.AptSPesanans
                   //  where y.SPesananID == e.SPesananID
                   //  select y).ToList().ForEach(x => { x.Tanggal = Convert.ToDateTime(tanggal); x.Keterangan = keterangan; });

                   
                    AptSPesanan O = new AptSPesanan();
                    O.SpesananGd = e.SpesananGd;
                    O.Keterangan = e.Keterangan;
                    O.Duedate = e.Duedate;
                    O.Jumlah = e.Jumlah;
                    O.Tanggal = Convert.ToDateTime(tanggal);
                    O.SPesanan = bukti;
                    db.AptSPesanans.Add(O);
                }
                db.SaveChanges();

            }
               

                //   var cutomerId = Guid.NewGuid();

                
                result = "Success! Edit Pembayaran Is Complete!";
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
