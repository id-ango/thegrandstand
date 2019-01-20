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
    public class BookingFeeController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: BookingFee
        public ActionResult Index()
        {
            List<CbTrans> TipeGl = new List<CbTrans>();
            TipeGl.Add(new CbTrans { NoRef = "BF-1707002", Tanggal = Convert.ToDateTime("2017-7-28"), ShortCode = "J0001", KodeMarketing = "10001", Unit = "1018", KodeBank = "B1", BankID = 1, Keterangan = "UTJ UNIT 1018 TYPE EMERALD B LUAS 23.9 M2", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-7-28"), MarketingID = 1, PersonID = 38 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708001", Tanggal = Convert.ToDateTime("2017-8-1"), ShortCode = "H0001", KodeMarketing = "10001", Unit = "0927", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-1"), MarketingID = 1, PersonID = 28 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708002", Tanggal = Convert.ToDateTime("2017-8-8"), ShortCode = "S0002", KodeMarketing = "10002", Unit = "1512", KodeBank = "B1", BankID = 1, Keterangan = "Biayanya booking fee akan di masukkan ke dlm angsuran pertama", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-8"), MarketingID = 2, PersonID = 68 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708004", Tanggal = Convert.ToDateTime("2017-8-17"), ShortCode = "C0001", KodeMarketing = "10004", Unit = "1011", KodeBank = "B1", BankID = 1, Keterangan = "BF UNIT EMERALD G LUAS 22.1M2", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-17"), MarketingID = 4, PersonID = 9 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708005", Tanggal = Convert.ToDateTime("2017-8-16"), ShortCode = "M0001", KodeMarketing = "10005", Unit = "0727", KodeBank = "B1", BankID = 1, Keterangan = "BF UNIT EMERALD I LUAS 39.6", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-16"), MarketingID = 5, PersonID = 52 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708007", Tanggal = Convert.ToDateTime("2017-8-19"), ShortCode = "Y0001", KodeMarketing = "10006", Unit = "2708", KodeBank = "B1", BankID = 1, Keterangan = "Booking Fee lantai 27 unit 8", Payment = 15000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-19"), MarketingID = 6, PersonID = 85 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708008", Tanggal = Convert.ToDateTime("2017-8-20"), ShortCode = "T0001", KodeMarketing = "10007", Unit = "0923", KodeBank = "B1", BankID = 1, Keterangan = "unit  0923 emerald I", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-20"), MarketingID = 7, PersonID = 77 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708009", Tanggal = Convert.ToDateTime("2017-8-16"), ShortCode = "J0002", KodeMarketing = "10008", Unit = "1212", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-16"), MarketingID = 8, PersonID = 39 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708010", Tanggal = Convert.ToDateTime("2017-8-17"), ShortCode = "K0001", KodeMarketing = "10009", Unit = "1027", KodeBank = "B1", BankID = 1, Keterangan = "BF unit Emerald I  1027", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-17"), MarketingID = 9, PersonID = 42 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708011", Tanggal = Convert.ToDateTime("2017-8-22"), ShortCode = "Z0001", KodeMarketing = "10010", Unit = "0718", KodeBank = "B1", BankID = 1, Keterangan = "BF unit Emerald B", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-22"), MarketingID = 10, PersonID = 90 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708012", Tanggal = Convert.ToDateTime("2017-8-16"), ShortCode = "K0002", KodeMarketing = "10011", Unit = "0911", KodeBank = "B1", BankID = 1, Keterangan = "BF UNIT EMERALD G", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-16"), MarketingID = 11, PersonID = 43 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708013", Tanggal = Convert.ToDateTime("2017-8-25"), ShortCode = "F0001", KodeMarketing = "10012", Unit = "1017", KodeBank = "B1", BankID = 1, Keterangan = "Booking fee a/n Fransisca Ratna Rahardjo", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-25"), MarketingID = 12, PersonID = 21 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1708014", Tanggal = Convert.ToDateTime("2017-8-30"), ShortCode = "H0005", KodeMarketing = "10011", Unit = "2706", KodeBank = "B1", BankID = 1, Keterangan = "Booking fee a/n HADIJANTO TJOKROWIDJOJO", Payment = 15000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-8-30"), MarketingID = 11, PersonID = 31 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1709002", Tanggal = Convert.ToDateTime("2017-9-18"), ShortCode = "H0002", KodeMarketing = "10012", Unit = "0919", KodeBank = "B1", BankID = 1, Keterangan = "BOOKING FEE A/N HERRY SUSASTRIA", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-9-18"), MarketingID = 12, PersonID = 29 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1709004", Tanggal = Convert.ToDateTime("2017-9-18"), ShortCode = "D0001", KodeMarketing = "10006", Unit = "0909", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N DEVY BUDYANTO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-9-18"), MarketingID = 6, PersonID = 12 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710003", Tanggal = Convert.ToDateTime("2017-10-16"), ShortCode = "G0001", KodeMarketing = "10015", Unit = "1026", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N GIDEON SATRIA NUGRAHA", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-16"), MarketingID = 15, PersonID = 24 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710006", Tanggal = Convert.ToDateTime("2017-10-21"), ShortCode = "B0002", KodeMarketing = "E0001", Unit = "0712", KodeBank = "B1", BankID = 1, Keterangan = "BOOKING FEE A/N BUDI DARMAWAN", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-21"), MarketingID = 22, PersonID = 6 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710010", Tanggal = Convert.ToDateTime("2017-10-30"), ShortCode = "L0001", KodeMarketing = "10012", Unit = "1005", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N LEON ANDRUS SUSENIO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-30"), MarketingID = 12, PersonID = 45 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710011", Tanggal = Convert.ToDateTime("2017-10-31"), ShortCode = "L0002", KodeMarketing = "10013", Unit = "2808", KodeBank = "B1", BankID = 1, Keterangan = "BOOKING FEE A/N LIDIAWATI", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-31"), MarketingID = 13, PersonID = 46 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710013", Tanggal = Convert.ToDateTime("2017-10-25"), ShortCode = "J0003", KodeMarketing = "L0001", Unit = "0912", KodeBank = "B1", BankID = 1, Keterangan = "ANGSURAN KE 1 JEFRILLIN KANGIN", Payment = 2874979, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-25"), MarketingID = 25, PersonID = 40 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710014", Tanggal = Convert.ToDateTime("2017-10-31"), ShortCode = "B0003", KodeMarketing = "C0001", Unit = "1012", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N BUNGA AYU PRIMANANDA", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-31"), MarketingID = 21, PersonID = 7 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1710015", Tanggal = Convert.ToDateTime("2017-10-25"), ShortCode = "P0001", KodeMarketing = "10013", Unit = "1511", KodeBank = "B2", BankID = 2, Keterangan = "ANGSURAN A/N PT KARUNIA MULTIVEST INDOMAKMUR", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-10-25"), MarketingID = 13, PersonID = 57 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1711002", Tanggal = Convert.ToDateTime("2017-11-21"), ShortCode = "F0002", KodeMarketing = "R0001", Unit = "0812", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N FIBULA DIFINCI HALIM", Payment = 2587481, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-11-21"), MarketingID = 27, PersonID = 22 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1711003", Tanggal = Convert.ToDateTime("2017-11-17"), ShortCode = "C0002", KodeMarketing = "10013", Unit = "0818", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N CYNTHIA M TOMASOA", Payment = 2657006, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-11-17"), MarketingID = 13, PersonID = 10 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1711004", Tanggal = Convert.ToDateTime("2017-11-24"), ShortCode = "Y0003", KodeMarketing = "R0002", Unit = "1209", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N YOSUA MARTIANSIA", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-11-24"), MarketingID = 28, PersonID = 87 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1711005", Tanggal = Convert.ToDateTime("2017-11-26"), ShortCode = "Y0004", KodeMarketing = "R0001", Unit = "0917", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N YOEL SETIA PERMAI", Payment = 5000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-11-26"), MarketingID = 27, PersonID = 88 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1711006", Tanggal = Convert.ToDateTime("2017-11-24"), ShortCode = "E0002", KodeMarketing = "H0001", Unit = "1019", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N ENGE CHRISTINA", Payment = 5000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-11-24"), MarketingID = 24, PersonID = 17 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712001", Tanggal = Convert.ToDateTime("2017-12-4"), ShortCode = "R0003", KodeMarketing = "10013", Unit = "0918", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N RICHARD HARRIS YOEWONO", Payment = 2861392, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-4"), MarketingID = 13, PersonID = 61 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712002", Tanggal = Convert.ToDateTime("2017-12-4"), ShortCode = "Y0002", KodeMarketing = "10012", Unit = "0819", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N YOHANA YUTAWATI YUWONO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-4"), MarketingID = 12, PersonID = 86 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712003", Tanggal = Convert.ToDateTime("2017-12-4"), ShortCode = "E0001", KodeMarketing = "10012", Unit = "0803", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N ELIZA KURNIAWATI YUWONO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-4"), MarketingID = 12, PersonID = 16 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712004", Tanggal = Convert.ToDateTime("2017-12-6"), ShortCode = "L0003", KodeMarketing = "S0001", Unit = "0823", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N LIANTO ATMODJO. DRS", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-6"), MarketingID = 29, PersonID = 47 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712005", Tanggal = Convert.ToDateTime("2017-12-11"), ShortCode = "B0004", KodeMarketing = "R0001", Unit = "0811", KodeBank = "K2", BankID = 9, Keterangan = "BF A/N BILLY DANUHARJA", Payment = 2653827, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-11"), MarketingID = 27, PersonID = 8 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712006", Tanggal = Convert.ToDateTime("2017-12-15"), ShortCode = "R0005", KodeMarketing = "E0001", Unit = "0817", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N R.E. EKO BONDAN KURNIAWAN", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-15"), MarketingID = 22, PersonID = 62 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1712008", Tanggal = Convert.ToDateTime("2017-12-27"), ShortCode = "I0001", KodeMarketing = "R0002", Unit = "1505", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N IDA TJEMPAKA JUWONO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2017-12-27"), MarketingID = 28, PersonID = 34 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1802002", Tanggal = Convert.ToDateTime("2018-2-21"), ShortCode = "S0005", KodeMarketing = "C0001", Unit = "1502A", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N SILVIA PUSPITA SETIAWATI", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-2-21"), MarketingID = 21, PersonID = 71 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1802003", Tanggal = Convert.ToDateTime("2018-2-26"), ShortCode = "G0002", KodeMarketing = "10008", Unit = "0902", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N YUSIK ARIANTO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-2-26"), MarketingID = 8, PersonID = 25 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1802004", Tanggal = Convert.ToDateTime("2018-2-26"), ShortCode = "G0002", KodeMarketing = "10008", Unit = "0903", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N YUSIK ARIANTO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-2-26"), MarketingID = 8, PersonID = 25 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1802005", Tanggal = Convert.ToDateTime("2018-2-14"), ShortCode = "S0009", KodeMarketing = "R0001", Unit = "0921", KodeBank = "B1", BankID = 1, Keterangan = "BOOKING FEE ATAS NAMA SUYANI", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-2-14"), MarketingID = 27, PersonID = 75 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1803001", Tanggal = Convert.ToDateTime("2018-3-27"), ShortCode = "S0006", KodeMarketing = "10019", Unit = "0717", KodeBank = "B2", BankID = 2, Keterangan = "BF A.N STEPHEN EVERARDO BF KE 1 CASH 3.000.000 TGL 22 MARET 2018", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018 - 3 - 27"), MarketingID = 19, PersonID = 72 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1803002", Tanggal = Convert.ToDateTime("2018-3-27"), ShortCode = "C0003", KodeMarketing = "10018", Unit = "0726", KodeBank = "B2", BankID = 2, Keterangan = "BF A.N CHRISTOPHER WILLIAM SAPUTRA BF KE 1 CASH 3.000.000 TGL 22 MARET 2018 BF KE 2 Rp 7.000.000 TGL 27 MARET 2018 KE REK BCA", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-3-27"), MarketingID = 18, PersonID = 11 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1804001", Tanggal = Convert.ToDateTime("2018-4-8"), ShortCode = "G0003", KodeMarketing = "E0001", Unit = "0805", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N GUNTUR PRATAMA WIJAYANTO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-4-8"), MarketingID = 22, PersonID = 26 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1804002", Tanggal = Convert.ToDateTime("2018-4-17"), ShortCode = "G0003", KodeMarketing = "E0001", Unit = "0806", KodeBank = "B5", BankID = 5, Keterangan = "BF A/N GUNTUR PRATAMA WIJAYANTO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-4-17"), MarketingID = 22, PersonID = 26 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1805001", Tanggal = Convert.ToDateTime("2018-5-11"), ShortCode = "A0002", KodeMarketing = "10008", Unit = "0719", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N AGUS SUYANTO", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-5-11"), MarketingID = 8, PersonID = 2 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1805003", Tanggal = Convert.ToDateTime("2018-5-11"), ShortCode = "S0007", KodeMarketing = "R0001", Unit = "1112", KodeBank = "B1", BankID = 1, Keterangan = "BF PAK SRI INDRA MULYONO TERMIN 1 Rp.1.816.000 TERMIN 2 : Rp. 1.059.000", Payment = 2874979, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-5-11"), MarketingID = 27, PersonID = 73 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1805004", Tanggal = Convert.ToDateTime("2018-5-11"), ShortCode = "T0005", KodeMarketing = "10008", Unit = "0815", KodeBank = "B2", BankID = 2, Keterangan = "BF A/N TETTT MARIA A.MD", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-5-11"), MarketingID = 8, PersonID = 81 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1805005", Tanggal = Convert.ToDateTime("2018-5-24"), ShortCode = "S0008", KodeMarketing = "10013", Unit = "1105", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N SUNARYADI AGUS HERNOWO DRS", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-5-24"), MarketingID = 13, PersonID = 74 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1806001", Tanggal = Convert.ToDateTime("2018-6-6"), ShortCode = "E0003", KodeMarketing = "S0002", Unit = "1111", KodeBank = "B1", BankID = 1, Keterangan = "BF A/N ENDANG PURWANTI", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-6-6"), MarketingID = 30, PersonID = 18 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807001", Tanggal = Convert.ToDateTime("2018-7-7"), ShortCode = "L0004", KodeMarketing = "R0001", Unit = "0711", KodeBank = "B1", BankID = 1, Keterangan = "BOOKING FEE A/N LIM TJING HAUW/HENNY INDA L. H.", Payment = 2874979, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-7"), MarketingID = 27, PersonID = 48 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807002", Tanggal = Convert.ToDateTime("2018-7-7"), ShortCode = "O0002", KodeMarketing = "S0002", Unit = "0723", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-7"), MarketingID = 30, PersonID = 56 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807004", Tanggal = Convert.ToDateTime("2018-7-16"), ShortCode = "T0008", KodeMarketing = "10001", Unit = "0821", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-16"), MarketingID = 1, PersonID = 82 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807005", Tanggal = Convert.ToDateTime("2018-7-17"), ShortCode = "L0006", KodeMarketing = "10001", Unit = "0925", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-17"), MarketingID = 1, PersonID = 49 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807006", Tanggal = Convert.ToDateTime("2018-7-21"), ShortCode = "R0007", KodeMarketing = "10001", Unit = "0926", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-21"), MarketingID = 1, PersonID = 64 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807007", Tanggal = Convert.ToDateTime("2018-7-21"), ShortCode = "F0003", KodeMarketing = "10001", Unit = "0827", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-21"), MarketingID = 1, PersonID = 23 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807008", Tanggal = Convert.ToDateTime("2018-7-25"), ShortCode = "M0002", KodeMarketing = "10001", Unit = "1110", KodeBank = "K2", BankID = 9, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-25"), MarketingID = 1, PersonID = 53 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807010", Tanggal = Convert.ToDateTime("2018-7-21"), ShortCode = "I0002", KodeMarketing = "S0002", Unit = "1126", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-21"), MarketingID = 30, PersonID = 35 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807011", Tanggal = Convert.ToDateTime("2018-7-29"), ShortCode = "M0004", KodeMarketing = "S0002", Unit = "0507", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-29"), MarketingID = 30, PersonID = 54 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807012", Tanggal = Convert.ToDateTime("2018-7-12"), ShortCode = "T0010", KodeMarketing = "10001", Unit = "1123", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-12"), MarketingID = 1, PersonID = 83 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807013", Tanggal = Convert.ToDateTime("2018-7-23"), ShortCode = "A0005", KodeMarketing = "10001", Unit = "1125", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-23"), MarketingID = 1, PersonID = 3 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807014", Tanggal = Convert.ToDateTime("2018-7-18"), ShortCode = "P0003", KodeMarketing = "10001", Unit = "0825", KodeBank = "B2", BankID = 2, Keterangan = "BOOKING FEE UNIT 0825 A/N PT. DEANOVA MITRA MANDIRI", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-18"), MarketingID = 1, PersonID = 58 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807016", Tanggal = Convert.ToDateTime("2018-7-31"), ShortCode = "H0004", KodeMarketing = "10001", Unit = "2807", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-31"), MarketingID = 1, PersonID = 30 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807017", Tanggal = Convert.ToDateTime("2018-7-30"), ShortCode = "E0005", KodeMarketing = "E0001", Unit = "2806", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-30"), MarketingID = 22, PersonID = 20 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807018", Tanggal = Convert.ToDateTime("2018-7-30"), ShortCode = "I0004", KodeMarketing = "E0002", Unit = "1116", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-30"), MarketingID = 23, PersonID = 37 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807019", Tanggal = Convert.ToDateTime("2018-7-30"), ShortCode = "H0006", KodeMarketing = "M0001", Unit = "1117", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 5000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-30"), MarketingID = 26, PersonID = 32 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807020", Tanggal = Convert.ToDateTime("2018-7-29"), ShortCode = "D0007", KodeMarketing = "S0002", Unit = "1127", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-29"), MarketingID = 30, PersonID = 14 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1807021", Tanggal = Convert.ToDateTime("2018-7-2"), ShortCode = "E0004", KodeMarketing = "S0002", Unit = "1023", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-7-2"), MarketingID = 30, PersonID = 19 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1808001", Tanggal = Convert.ToDateTime("2018-8-8"), ShortCode = "W0001", KodeMarketing = "10001", Unit = "0906", KodeBank = "B1", BankID = 1, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-8-8"), MarketingID = 1, PersonID = 84 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1808002", Tanggal = Convert.ToDateTime("2018-8-13"), ShortCode = "A0007", KodeMarketing = "R0001", Unit = "1103", KodeBank = "B2", BankID = 2, Keterangan = "BOOKING FEE UNIT 1103 A/N AL AMIN IBNU FAJAR", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-8-13"), MarketingID = 27, PersonID = 4 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1808003", Tanggal = Convert.ToDateTime("2018-8-14"), ShortCode = "L0008", KodeMarketing = "10001", Unit = "1112", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-8-14"), MarketingID = 1, PersonID = 50});
            TipeGl.Add(new CbTrans { NoRef = "BF-1808004", Tanggal = Convert.ToDateTime("2018-8-6"), ShortCode = "R0011", KodeMarketing = "Y0001", Unit = "1106", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-8-6"), MarketingID = 31, PersonID = 65 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1809001", Tanggal = Convert.ToDateTime("2018-9-12"), ShortCode = "S0010", KodeMarketing = "R0001", Unit = "1006", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-9-12"), MarketingID = 27, PersonID = 76 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1809002", Tanggal = Convert.ToDateTime("2018-9-10"), ShortCode = "Y0005", KodeMarketing = "10001", Unit = "1119", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-9-10"), MarketingID = 1, PersonID = 89 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1809003", Tanggal = Convert.ToDateTime("2018-9-8"), ShortCode = "G0004", KodeMarketing = "R0001", Unit = "0503", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-9-8"), MarketingID = 27, PersonID = 27 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1810001", Tanggal = Convert.ToDateTime("2018-10-26"), ShortCode = "L0009", KodeMarketing = "E0002", Unit = "1121", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-10-26"), MarketingID = 23, PersonID = 51 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1811002", Tanggal = Convert.ToDateTime("2018-11-10"), ShortCode = "J0004", KodeMarketing = "E0001", Unit = "0826", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-11-10"), MarketingID = 22, PersonID = 41 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1811003", Tanggal = Convert.ToDateTime("2018-11-10"), ShortCode = "D0008", KodeMarketing = "S0002", Unit = "1611", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 20000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-11-10"), MarketingID = 30, PersonID = 15 });
            TipeGl.Add(new CbTrans { NoRef = "BF-1811004", Tanggal = Convert.ToDateTime("2018-11-12"), ShortCode = "R0013", KodeMarketing = "R0001", Unit = "1010", KodeBank = "B2", BankID = 2, Keterangan = "", Payment = 10000000, UnitID = 1, PaymentID = 1, BayarID = 1, TransNoID = 1, TglSelesai = Convert.ToDateTime("2018-11-12"), MarketingID = 27, PersonID = 66 });





            var cekNull = (from e in db.CbTranss select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.CbTranss.Add(values);
                    db.SaveChanges();
                }


            }


            var aptTranss2 = db.CbTranss.Include(a => a.AptMarketing).Include(a => a.AptPayment).Include(a => a.AptUnit);

            var Booking = (from e in aptTranss2
                           join y in db.ArCustomers
                           on e.PersonID equals y.CustomerID
                           where e.TransNoID == 1
                           select new
                           {
                               e.TransID,
                               e.NoRef,
                               e.Tanggal,
                               e.UnitID,
                               e.AptUnit.UnitNo,
                               e.AptPayment.PaymentName,
                               e.AptMarketing.MarketingName,
                               e.AptMarketing.AptAgen.AgenName,
                               e.PersonID,
                               y.CustomerName,
                               e.Keterangan,
                               e.PaymentID,
                               e.Payment,
                               e.MarketingID
                           }).ToList();

            List<BookViewsModels> cbViews = new List<BookViewsModels>();
            foreach (var e in Booking)
            {
                cbViews.Add(new BookViewsModels
                {
                    TransID = e.TransID,
                    NoRef = e.NoRef,
                    Tanggal = e.Tanggal,
                    UnitID = e.UnitID,
                    UnitNo = e.UnitNo,
                    CustomerID = e.PersonID,
                    CustomerName = e.CustomerName,
                    MarketingID = e.MarketingID,
                    MarketingName = e.MarketingName,
                    AgenName = e.AgenName,
                    Keterangan = e.Keterangan,
                    Payment = e.Payment,
                    PaymentID = e.PaymentID,
                    PaymentName = e.PaymentName
                });
            }


            return View(cbViews.ToList());
        }

        // GET: BookingFee/Details/5
        public ActionResult Details(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CbTrans cbTrans = db.CbTranss.Find(id);
            if (cbTrans == null)
            {
                return HttpNotFound();
            }
            var NamaCustomer = (from e in db.ArCustomers
                                where e.CustomerID == cbTrans.PersonID
                                select e).First().CustomerName;

            ViewBag.NamaCustomer = NamaCustomer;

            return View(cbTrans);
        }

        // GET: BookingFee/Create
        public ActionResult Create()
        {
            //   int maxvalue = 0;
            //   var Cekvalue = (from a in db.AptUruts where a.TipeTrans == 1 select a).FirstOrDefault();
            //    if (Cekvalue != null)
            //   {
            //        maxvalue = (from a in db.AptUruts where a.TipeTrans == 1 select a).FirstOrDefault().NoUrut;
            //    }
            //    else
            //    {
            //        AptUrut TipeGl = new AptUrut { TipeTrans = 1, NoUrut=0,Tanggal=DateTime.Now};
            //        db.AptUruts.Add(TipeGl);
            //        db.SaveChanges();

            //     }
            var unitList = from e in db.AptUnits
                           where e.StatusID <= 2
                           select e;

            var kodeno = "BF-";
            string thnbln = DateTime.Now.ToString("yyMM");
            string xbukti = kodeno + thnbln;
            var maxvalue = "";
            var maxlist = db.CbTranss.Where(x => x.NoRef.Substring(0, 7).Equals(xbukti)).ToList();
            if (maxlist != null)
            {
                maxvalue = maxlist.Max(x => x.NoRef);

            }

            //            var maxvalue = (from e in db.CbTransHs where  e.Docno.Substring(0, 7) == kodeno + thnbln select e).Max();
            string nourut = "000";
            if (maxvalue == null)
            {
                nourut = "000";
            }
            else
            {
                nourut = maxvalue.Substring(7, 3);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeno + thnbln + (Int32.Parse(nourut) + 1).ToString("000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            string cNoref = cAngNo;

            ViewBag.NoRef = cNoref;


            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName");
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName");
            ViewBag.UnitID = new SelectList(unitList, "UnitID", "UnitNo");
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName");
            return View();
        }

        // POST: BookingFee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransID,NoRef,Tanggal,UnitID,PersonID,MarketingID,Keterangan,Payment,PaymentID,TransNoID")] CbTrans cbTrans)
        {

            if (ModelState.IsValid)
            {

                var validUnit = (from e in db.AptUnits
                                 where e.UnitID == cbTrans.UnitID && e.StatusID == 3
                                 select e).FirstOrDefault();

                // var validUnit = (from x in db.Units where x.UnitId == rental.UnitId && x.Status != 2 select x).FirstOrDefault();
                //var dulpliUser = from x in db.Rentals where x.UnitId==rental.UnitId&&x.User.UserName == rental.User.UserName select x;
                //var dulpliUser = (from x in db.Rentals where x.UnitId == rental.UnitId && x.User.UserName.Equals(rental.User.UserName) select x).Count();

                if (validUnit == null)  // berarti unit ini  dalam posisi hold
                {
                    cbTrans.TransNoID = 1;        //Booking Transaksi
                    cbTrans.TglSelesai = cbTrans.Tanggal;
                    cbTrans.BayarID = 1;

                    db.CbTranss.Add(cbTrans);

                    //update to hold
                    (from u in db.AptUnits
                     where u.UnitID == cbTrans.UnitID
                     select u).ToList().ForEach(x => x.StatusID = 2);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ModelState.AddModelError("", "This unit is already Sold!");
                }


            }

            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", cbTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", cbTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", cbTrans.UnitID);
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", cbTrans.PersonID);
            return View(cbTrans);
        }

        // GET: BookingFee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTrans aptTrans = db.CbTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.PersonID);
            return View(aptTrans);
        }

        // POST: BookingFee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransID,NoRef,Tanggal,UnitID,PersonID,MarketingID,Keterangan,Payment,PaymentID")] CbTrans aptTrans)
        {
            if (ModelState.IsValid)
            {
                aptTrans.TransNoID = 1;        //Booking Transaksi
                aptTrans.TglSelesai = aptTrans.Tanggal;
                aptTrans.BayarID = 1;

                db.Entry(aptTrans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketingID = new SelectList(db.AptMarketings, "MarketingID", "MarketingName", aptTrans.MarketingID);
            ViewBag.PaymentID = new SelectList(db.AptPayments, "PaymentID", "PaymentName", aptTrans.PaymentID);
            ViewBag.UnitID = new SelectList(db.AptUnits, "UnitID", "UnitNo", aptTrans.UnitID);
            ViewBag.PersonID = new SelectList(db.ArCustomers, "CustomerID", "CustomerName", aptTrans.PersonID);
            return View(aptTrans);
        }

        // GET: BookingFee/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CbTrans aptTrans = db.CbTranss.Find(id);

            var test = (from e in db.AptUnits
                        where e.StatusID == 3 && e.UnitID == aptTrans.UnitID   // jika sudah laku tidak bisa dihapus transaksinya
                        select e).ToList().Count();

            if (test != 0)
            {
                // TempData["msg"] = "<script>alert('Change succesfully');</script>";
                //   return JavaScript(alert("Hello this is an alert"));
                return Content("<script language='javascript' type='text/javascript'>alert('Sudah ada Transaksi SP, tidak bisa dihapus!');</script>");
                //  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   // ada revisi untuk messagenya
            }

            if (aptTrans == null)
            {
                return HttpNotFound();
            }
            var NamaCustomer = (from e in db.ArCustomers
                                where e.CustomerID == aptTrans.PersonID
                                select e).First().CustomerName;

            ViewBag.NamaCustomer = NamaCustomer;

            return View(aptTrans);
        }

        // POST: BookingFee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            CbTrans aptTrans = db.CbTranss.Find(id);

            int nRec = (from e in db.CbTranss
                        where e.UnitID == aptTrans.UnitID
                        select e).Count();

            if (nRec == 1)
            {
                (from e in db.AptUnits
                 where e.UnitID == aptTrans.UnitID
                 select e).ToList().ForEach(x => x.StatusID = 1);
            }

            db.CbTranss.Remove(aptTrans);
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

        public ActionResult TandaTerima(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CbTrans aptTrans = db.CbTranss.Find(id);
            if (aptTrans == null)
            {
                return HttpNotFound();
            }

            var NamaCustomer = (from e in db.ArCustomers
                                where e.CustomerID == aptTrans.PersonID
                                select e).First().CustomerName;

            ViewBag.NamaCustomer = NamaCustomer;

            return View(aptTrans);
        }
    }
}
