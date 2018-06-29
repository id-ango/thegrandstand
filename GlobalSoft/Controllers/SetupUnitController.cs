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
    public class SetupUnitController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupUnit
        public ActionResult Index()
        {
            List<AptUnit> TipeGl = new List<AptUnit>();
            TipeGl.Add(new AptUnit { UnitNo = "0501", CategorieID = 3, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0502", CategorieID = 4, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0503", CategorieID = 9, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0505", CategorieID = 5, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0506", CategorieID = 5, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0507", CategorieID = 9, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0508", CategorieID = 4, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0509", CategorieID = 3, Lantai = 5, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0701", CategorieID = 4, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0702", CategorieID = 3, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0703", CategorieID = 2, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0705", CategorieID = 2, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0706", CategorieID = 2, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0707", CategorieID = 1, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0708", CategorieID = 10, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0709", CategorieID = 6, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0710", CategorieID = 8, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0711", CategorieID = 7, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0712", CategorieID = 7, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0715", CategorieID = 10, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0716", CategorieID = 1, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0717", CategorieID = 2, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0718", CategorieID = 2, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0719", CategorieID = 2, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0720", CategorieID = 3, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0721", CategorieID = 4, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0723", CategorieID = 9, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0725", CategorieID = 5, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0726", CategorieID = 5, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0727", CategorieID = 9, Lantai = 7, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0801", CategorieID = 4, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0802", CategorieID = 3, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0803", CategorieID = 2, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0805", CategorieID = 2, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0806", CategorieID = 2, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0807", CategorieID = 1, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0808", CategorieID = 10, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0809", CategorieID = 6, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0810", CategorieID = 8, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0811", CategorieID = 7, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0812", CategorieID = 7, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0815", CategorieID = 10, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0816", CategorieID = 1, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0817", CategorieID = 2, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0818", CategorieID = 2, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0819", CategorieID = 2, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0820", CategorieID = 3, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0821", CategorieID = 4, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0823", CategorieID = 9, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0825", CategorieID = 5, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0826", CategorieID = 5, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0827", CategorieID = 9, Lantai = 8, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0901", CategorieID = 4, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0902", CategorieID = 3, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0903", CategorieID = 2, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0905", CategorieID = 2, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0906", CategorieID = 2, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0907", CategorieID = 1, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0908", CategorieID = 10, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0909", CategorieID = 6, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0910", CategorieID = 8, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0911", CategorieID = 7, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0912", CategorieID = 7, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0915", CategorieID = 10, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0916", CategorieID = 1, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0917", CategorieID = 2, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0918", CategorieID = 2, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0919", CategorieID = 2, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0920", CategorieID = 3, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0921", CategorieID = 4, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0923", CategorieID = 9, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0925", CategorieID = 5, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0926", CategorieID = 5, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "0927", CategorieID = 9, Lantai = 9, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1001", CategorieID = 4, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1002", CategorieID = 3, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1003", CategorieID = 2, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1005", CategorieID = 2, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1006", CategorieID = 2, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1007", CategorieID = 1, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1008", CategorieID = 10, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1009", CategorieID = 6, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1010", CategorieID = 8, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1011", CategorieID = 7, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1012", CategorieID = 7, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1015", CategorieID = 10, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1016", CategorieID = 1, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1017", CategorieID = 2, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1018", CategorieID = 2, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1019", CategorieID = 2, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1020", CategorieID = 3, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1021", CategorieID = 4, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1023", CategorieID = 9, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1025", CategorieID = 5, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1026", CategorieID = 5, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1027", CategorieID = 9, Lantai = 10, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1101", CategorieID = 15, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1102", CategorieID = 18, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1103", CategorieID = 16, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1105", CategorieID = 1, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1106", CategorieID = 1, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1107", CategorieID = 1, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1108", CategorieID = 10, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1109", CategorieID = 6, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1110", CategorieID = 12, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1111", CategorieID = 10, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1112", CategorieID = 1, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1115", CategorieID = 14, Lantai = 11, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1201", CategorieID = 15, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1202", CategorieID = 18, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1203", CategorieID = 16, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1205", CategorieID = 1, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1206", CategorieID = 1, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1207", CategorieID = 1, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1208", CategorieID = 10, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1209", CategorieID = 6, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1210", CategorieID = 12, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1211", CategorieID = 10, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1212", CategorieID = 1, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1215", CategorieID = 14, Lantai = 12, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1501", CategorieID = 15, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1502", CategorieID = 18, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1503", CategorieID = 16, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1505", CategorieID = 1, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1506", CategorieID = 1, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1507", CategorieID = 1, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1508", CategorieID = 10, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1509", CategorieID = 6, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1510", CategorieID = 12, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1511", CategorieID = 10, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1512", CategorieID = 1, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1515", CategorieID = 14, Lantai = 15, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1601", CategorieID = 15, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1602", CategorieID = 18, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1603", CategorieID = 16, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1605", CategorieID = 1, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1606", CategorieID = 1, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1607", CategorieID = 1, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1608", CategorieID = 10, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1609", CategorieID = 6, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1610", CategorieID = 12, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1611", CategorieID = 10, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1612", CategorieID = 1, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1615", CategorieID = 14, Lantai = 16, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1701", CategorieID = 15, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1702", CategorieID = 18, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1703", CategorieID = 16, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1705", CategorieID = 1, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1706", CategorieID = 1, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1707", CategorieID = 1, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1708", CategorieID = 10, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1709", CategorieID = 6, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1710", CategorieID = 12, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1711", CategorieID = 10, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1712", CategorieID = 1, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1715", CategorieID = 14, Lantai = 17, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1801", CategorieID = 15, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1802", CategorieID = 18, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1803", CategorieID = 16, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1805", CategorieID = 1, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1806", CategorieID = 1, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1807", CategorieID = 1, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1808", CategorieID = 10, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1809", CategorieID = 6, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1810", CategorieID = 12, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1811", CategorieID = 10, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1812", CategorieID = 1, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1815", CategorieID = 14, Lantai = 18, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1901", CategorieID = 15, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1902", CategorieID = 18, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1903", CategorieID = 16, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1905", CategorieID = 1, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1906", CategorieID = 1, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1907", CategorieID = 1, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1908", CategorieID = 10, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1909", CategorieID = 6, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1910", CategorieID = 12, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1911", CategorieID = 10, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1912", CategorieID = 1, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "1915", CategorieID = 14, Lantai = 19, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2001", CategorieID = 15, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2002", CategorieID = 18, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2003", CategorieID = 16, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2005", CategorieID = 1, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2006", CategorieID = 1, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2007", CategorieID = 1, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2008", CategorieID = 10, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2009", CategorieID = 6, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2010", CategorieID = 12, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2011", CategorieID = 10, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2012", CategorieID = 1, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2015", CategorieID = 14, Lantai = 20, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2101", CategorieID = 15, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2102", CategorieID = 18, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2103", CategorieID = 16, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2105", CategorieID = 1, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2106", CategorieID = 1, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2107", CategorieID = 1, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2108", CategorieID = 10, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2109", CategorieID = 6, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2110", CategorieID = 12, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2111", CategorieID = 10, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2112", CategorieID = 1, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2115", CategorieID = 14, Lantai = 21, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2201", CategorieID = 15, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2202", CategorieID = 18, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2203", CategorieID = 16, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2205", CategorieID = 1, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2206", CategorieID = 1, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2207", CategorieID = 1, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2208", CategorieID = 10, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2209", CategorieID = 6, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2210", CategorieID = 12, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2211", CategorieID = 10, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2212", CategorieID = 1, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2215", CategorieID = 14, Lantai = 22, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2301", CategorieID = 15, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2302", CategorieID = 18, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2303", CategorieID = 16, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2305", CategorieID = 1, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2306", CategorieID = 1, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2307", CategorieID = 1, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2308", CategorieID = 10, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2309", CategorieID = 6, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2310", CategorieID = 12, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2311", CategorieID = 10, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2312", CategorieID = 1, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2315", CategorieID = 14, Lantai = 23, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2501", CategorieID = 15, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2502", CategorieID = 18, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2503", CategorieID = 16, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2505", CategorieID = 1, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2506", CategorieID = 1, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2507", CategorieID = 1, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2508", CategorieID = 10, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2509", CategorieID = 6, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2510", CategorieID = 12, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2511", CategorieID = 10, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2512", CategorieID = 1, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2515", CategorieID = 14, Lantai = 25, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2601", CategorieID = 15, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2602", CategorieID = 18, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2603", CategorieID = 16, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2605", CategorieID = 1, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2606", CategorieID = 1, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2607", CategorieID = 1, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2608", CategorieID = 10, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2609", CategorieID = 6, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2610", CategorieID = 12, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2611", CategorieID = 10, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2612", CategorieID = 1, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2615", CategorieID = 14, Lantai = 26, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2701", CategorieID = 1, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2702", CategorieID = 11, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2703", CategorieID = 6, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2705", CategorieID = 13, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2706", CategorieID = 19, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2707", CategorieID = 1, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2708", CategorieID = 20, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2709", CategorieID = 18, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2710", CategorieID = 17, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2711", CategorieID = 1, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2712", CategorieID = 1, Lantai = 27, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2801", CategorieID = 1, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2802", CategorieID = 11, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2803", CategorieID = 6, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2805", CategorieID = 13, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2806", CategorieID = 19, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2807", CategorieID = 1, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2808", CategorieID = 20, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2809", CategorieID = 18, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2810", CategorieID = 17, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2811", CategorieID = 1, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2812", CategorieID = 1, Lantai = 28, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2901", CategorieID = 1, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2902", CategorieID = 11, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2903", CategorieID = 6, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2905", CategorieID = 13, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2906", CategorieID = 19, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2907", CategorieID = 1, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2908", CategorieID = 20, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2909", CategorieID = 18, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2910", CategorieID = 17, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2911", CategorieID = 1, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "2912", CategorieID = 1, Lantai = 29, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3001", CategorieID = 1, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3002", CategorieID = 11, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3003", CategorieID = 6, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3005", CategorieID = 13, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3006", CategorieID = 19, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3007", CategorieID = 1, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3008", CategorieID = 20, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3009", CategorieID = 18, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3010", CategorieID = 17, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3011", CategorieID = 1, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3012", CategorieID = 1, Lantai = 30, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3101", CategorieID = 1, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3102", CategorieID = 11, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3103", CategorieID = 6, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3105", CategorieID = 13, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3106", CategorieID = 19, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3107", CategorieID = 1, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3108", CategorieID = 20, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3109", CategorieID = 18, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3110", CategorieID = 17, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3111", CategorieID = 1, Lantai = 31, StatusID = 1 });
            TipeGl.Add(new AptUnit { UnitNo = "3112", CategorieID = 1, Lantai = 31, StatusID = 1 });


            var cekNull = (from e in db.AptUnits select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.AptUnits.Add(values);
                    db.SaveChanges();
                }


            }


            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            return View(aptUnits.ToList());
        }

        // GET: SetupUnit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptUnit aptUnit = db.AptUnits.Find(id);
            if (aptUnit == null)
            {
                return HttpNotFound();
            }
            return View(aptUnit);
        }

        // GET: SetupUnit/Create
        public ActionResult Create()
        {
            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie");
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status");
            return View();
        }

        // POST: SetupUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitID,UnitNo,Lantai,CategorieID,StatusID,Inhouse,PriceKPR,StatOld")] AptUnit aptUnit)
        {
            
            if (ModelState.IsValid)
            {
               
                aptUnit.StatOld = aptUnit.StatusID;

                db.AptUnits.Add(aptUnit);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie", aptUnit.CategorieID);
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status", aptUnit.StatusID);
            return View(aptUnit);
        }

        // GET: SetupUnit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptUnit aptUnit = db.AptUnits.Find(id);
            if (aptUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie", aptUnit.CategorieID);
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status", aptUnit.StatusID);
            return View(aptUnit);
        }

        // POST: SetupUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitID,UnitNo,Lantai,CategorieID,StatusID,Inhouse,PriceKPR,StatOld")] AptUnit aptUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategorieID = new SelectList(db.AptCategories, "CategorieID", "Categorie", aptUnit.CategorieID);
            ViewBag.StatusID = new SelectList(db.AptStatuses, "StatusID", "Status", aptUnit.StatusID);
            return View(aptUnit);
        }

        // GET: SetupUnit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptUnit aptUnit = db.AptUnits.Find(id);
            if (aptUnit == null)
            {
                return HttpNotFound();
            }
            return View(aptUnit);
        }

        // POST: SetupUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptUnit aptUnit = db.AptUnits.Find(id);
            db.AptUnits.Remove(aptUnit);
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
