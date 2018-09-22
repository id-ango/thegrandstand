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
    public class SetupUnitController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupUnit
        public ActionResult Index(int? pageNumber)
        {
            List<AptUnit> TipeGl = new List<AptUnit>
            {
                 new AptUnit { UnitNo = "0501", CategorieID = 3, Lantai =5, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0502", CategorieID = 4, Lantai =5, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0503", CategorieID = 9, Lantai =5, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0505", CategorieID = 5, Lantai =5, StatusID = 1, Inhouse = 688361624, PriceKPR=749197005},
 new AptUnit { UnitNo = "0506", CategorieID = 5, Lantai =5, StatusID = 1, Inhouse = 688361624, PriceKPR=749197005},
 new AptUnit { UnitNo = "0507", CategorieID = 9, Lantai =5, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0508", CategorieID = 4, Lantai =5, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0509", CategorieID = 3, Lantai =5, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0701", CategorieID = 4, Lantai =7, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0702", CategorieID = 3, Lantai =7, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0703", CategorieID = 2, Lantai =7, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0705", CategorieID = 2, Lantai =7, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0706", CategorieID = 2, Lantai =7, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0707", CategorieID = 1, Lantai =7, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "0708", CategorieID = 10, Lantai =7, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "0709", CategorieID = 6, Lantai =7, StatusID = 1, Inhouse = 743235551, PriceKPR=849366555},
 new AptUnit { UnitNo = "0710", CategorieID = 8, Lantai =7, StatusID = 1, Inhouse = 530882536, PriceKPR=606690396},
 new AptUnit { UnitNo = "0711", CategorieID = 7, Lantai =7, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "0712", CategorieID = 7, Lantai =7, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "0715", CategorieID = 10, Lantai =7, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "0716", CategorieID = 1, Lantai =7, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "0717", CategorieID = 2, Lantai =7, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0718", CategorieID = 2, Lantai =7, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0719", CategorieID = 2, Lantai =7, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0720", CategorieID = 3, Lantai =7, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0721", CategorieID = 4, Lantai =7, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0723", CategorieID = 9, Lantai =7, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0725", CategorieID = 5, Lantai =7, StatusID = 1, Inhouse = 688361624, PriceKPR=786656855},
 new AptUnit { UnitNo = "0726", CategorieID = 5, Lantai =7, StatusID = 1, Inhouse = 688361624, PriceKPR=786656855},
 new AptUnit { UnitNo = "0727", CategorieID = 9, Lantai =7, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0801", CategorieID = 4, Lantai =8, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0802", CategorieID = 3, Lantai =8, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0803", CategorieID = 2, Lantai =8, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0805", CategorieID = 2, Lantai =8, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0806", CategorieID = 2, Lantai =8, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0807", CategorieID = 1, Lantai =8, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "0808", CategorieID = 10, Lantai =8, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "0809", CategorieID = 6, Lantai =8, StatusID = 1, Inhouse = 743235551, PriceKPR=849366555},
 new AptUnit { UnitNo = "0810", CategorieID = 8, Lantai =8, StatusID = 1, Inhouse = 530882536, PriceKPR=606690396},
 new AptUnit { UnitNo = "0811", CategorieID = 7, Lantai =8, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "0812", CategorieID = 7, Lantai =8, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "0815", CategorieID = 10, Lantai =8, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "0816", CategorieID = 1, Lantai =8, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "0817", CategorieID = 2, Lantai =8, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0818", CategorieID = 2, Lantai =8, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0819", CategorieID = 2, Lantai =8, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0820", CategorieID = 3, Lantai =8, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0821", CategorieID = 4, Lantai =8, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0823", CategorieID = 9, Lantai =8, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0825", CategorieID = 5, Lantai =8, StatusID = 1, Inhouse = 688361624, PriceKPR=786656855},
 new AptUnit { UnitNo = "0826", CategorieID = 5, Lantai =8, StatusID = 1, Inhouse = 655582499, PriceKPR=749197005},
 new AptUnit { UnitNo = "0827", CategorieID = 9, Lantai =8, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0901", CategorieID = 4, Lantai =9, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0902", CategorieID = 3, Lantai =9, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0903", CategorieID = 2, Lantai =9, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0905", CategorieID = 2, Lantai =9, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0906", CategorieID = 2, Lantai =9, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0907", CategorieID = 1, Lantai =9, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "0908", CategorieID = 10, Lantai =9, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "0909", CategorieID = 6, Lantai =9, StatusID = 1, Inhouse = 743235551, PriceKPR=849366555},
 new AptUnit { UnitNo = "0910", CategorieID = 8, Lantai =9, StatusID = 1, Inhouse = 530882536, PriceKPR=606690396},
 new AptUnit { UnitNo = "0911", CategorieID = 7, Lantai =9, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "0912", CategorieID = 7, Lantai =9, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "0915", CategorieID = 10, Lantai =9, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "0916", CategorieID = 1, Lantai =9, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "0917", CategorieID = 2, Lantai =9, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0918", CategorieID = 2, Lantai =9, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0919", CategorieID = 2, Lantai =9, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "0920", CategorieID = 3, Lantai =9, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "0921", CategorieID = 4, Lantai =9, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "0923", CategorieID = 9, Lantai =9, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "0925", CategorieID = 5, Lantai =9, StatusID = 1, Inhouse = 655582499, PriceKPR=749197005},
 new AptUnit { UnitNo = "0926", CategorieID = 5, Lantai =9, StatusID = 1, Inhouse = 655582499, PriceKPR=749197005},
 new AptUnit { UnitNo = "0927", CategorieID = 9, Lantai =9, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "1001", CategorieID = 4, Lantai =10, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "1002", CategorieID = 3, Lantai =10, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "1003", CategorieID = 2, Lantai =10, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1005", CategorieID = 2, Lantai =10, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1006", CategorieID = 2, Lantai =10, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1007", CategorieID = 1, Lantai =10, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "1008", CategorieID = 10, Lantai =10, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "1009", CategorieID = 6, Lantai =10, StatusID = 1, Inhouse = 743235551, PriceKPR=849366555},
 new AptUnit { UnitNo = "1010", CategorieID = 8, Lantai =10, StatusID = 1, Inhouse = 530882536, PriceKPR=606690396},
 new AptUnit { UnitNo = "1011", CategorieID = 7, Lantai =10, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "1012", CategorieID = 7, Lantai =10, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "1015", CategorieID = 10, Lantai =10, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "1016", CategorieID = 1, Lantai =10, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "1017", CategorieID = 2, Lantai =10, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1018", CategorieID = 2, Lantai =10, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1019", CategorieID = 2, Lantai =10, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1020", CategorieID = 3, Lantai =10, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "1021", CategorieID = 4, Lantai =10, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "1023", CategorieID = 9, Lantai =10, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "1025", CategorieID = 5, Lantai =10, StatusID = 1, Inhouse = 655582499, PriceKPR=749197005},
 new AptUnit { UnitNo = "1026", CategorieID = 5, Lantai =10, StatusID = 1, Inhouse = 688361624, PriceKPR=786656855},
 new AptUnit { UnitNo = "1027", CategorieID = 9, Lantai =10, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "1101", CategorieID = 4, Lantai =11, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "1102", CategorieID = 3, Lantai =11, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "1103", CategorieID = 2, Lantai =11, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1105", CategorieID = 2, Lantai =11, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1106", CategorieID = 2, Lantai =11, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1107", CategorieID = 1, Lantai =11, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "1108", CategorieID = 10, Lantai =11, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "1109", CategorieID = 6, Lantai =11, StatusID = 1, Inhouse = 743235551, PriceKPR=849366555},
 new AptUnit { UnitNo = "1110", CategorieID = 8, Lantai =11, StatusID = 1, Inhouse = 530882536, PriceKPR=606690396},
 new AptUnit { UnitNo = "1111", CategorieID = 7, Lantai =11, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "1112", CategorieID = 7, Lantai =11, StatusID = 1, Inhouse = 411666809, PriceKPR=470451149},
 new AptUnit { UnitNo = "1115", CategorieID = 10, Lantai =11, StatusID = 1, Inhouse = 1617598744, PriceKPR=1848585245},
 new AptUnit { UnitNo = "1116", CategorieID = 1, Lantai =11, StatusID = 1, Inhouse = 666725544, PriceKPR=761931232},
 new AptUnit { UnitNo = "1117", CategorieID = 2, Lantai =11, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1118", CategorieID = 2, Lantai =11, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1119", CategorieID = 2, Lantai =11, StatusID = 1, Inhouse = 443864638, PriceKPR=507246698},
 new AptUnit { UnitNo = "1120", CategorieID = 3, Lantai =11, StatusID = 1, Inhouse = 520008781, PriceKPR=594263913},
 new AptUnit { UnitNo = "1121", CategorieID = 4, Lantai =11, StatusID = 1, Inhouse = 508865736, PriceKPR=581529687},
 new AptUnit { UnitNo = "1123", CategorieID = 9, Lantai =11, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "1125", CategorieID = 5, Lantai =11, StatusID = 1, Inhouse = 655582499, PriceKPR=749197005},
 new AptUnit { UnitNo = "1126", CategorieID = 5, Lantai =11, StatusID = 1, Inhouse = 688361624, PriceKPR=786656855},
 new AptUnit { UnitNo = "1127", CategorieID = 9, Lantai =11, StatusID = 1, Inhouse = 735440990, PriceKPR=840458963},
 new AptUnit { UnitNo = "1201", CategorieID = 13, Lantai =12, StatusID = 1, Inhouse = 1778736465, PriceKPR=2032732775},
 new AptUnit { UnitNo = "1203", CategorieID = 14, Lantai =12, StatusID = 1, Inhouse = 691803432, PriceKPR=790590140},
 new AptUnit { UnitNo = "1205", CategorieID = 1, Lantai =12, StatusID = 1, Inhouse = 691803432, PriceKPR=790590140},
 new AptUnit { UnitNo = "1206", CategorieID = 1, Lantai =12, StatusID = 1, Inhouse = 1761938324, PriceKPR=2013535928},
 new AptUnit { UnitNo = "1207", CategorieID = 1, Lantai =12, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1208", CategorieID = 10, Lantai =12, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1209", CategorieID = 6, Lantai =12, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1210", CategorieID = 11, Lantai =12, StatusID = 1, Inhouse = 1625686738, PriceKPR=1857828171},
 new AptUnit { UnitNo = "1211", CategorieID = 10, Lantai =12, StatusID = 1, Inhouse = 744717576, PriceKPR=851060207},
 new AptUnit { UnitNo = "1212", CategorieID = 1, Lantai =12, StatusID = 1, Inhouse = 1656016714, PriceKPR=1802370614},
 new AptUnit { UnitNo = "1215", CategorieID = 12, Lantai =12, StatusID = 1, Inhouse = 1625686738, PriceKPR=1857828171},
 new AptUnit { UnitNo = "1202A", CategorieID = 5, Lantai =12, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1202B", CategorieID = 5, Lantai =12, StatusID = 1, Inhouse = 1338251884, PriceKPR=1529348793},
 new AptUnit { UnitNo = "1501", CategorieID = 13, Lantai =15, StatusID = 1, Inhouse = 1778736465, PriceKPR=2032732775},
 new AptUnit { UnitNo = "1503", CategorieID = 14, Lantai =15, StatusID = 1, Inhouse = 691803432, PriceKPR=790590140},
 new AptUnit { UnitNo = "1505", CategorieID = 1, Lantai =15, StatusID = 1, Inhouse = 691803432, PriceKPR=790590140},
 new AptUnit { UnitNo = "1506", CategorieID = 1, Lantai =15, StatusID = 1, Inhouse = 1761938324, PriceKPR=2013535928},
 new AptUnit { UnitNo = "1507", CategorieID = 1, Lantai =15, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1508", CategorieID = 10, Lantai =15, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1509", CategorieID = 6, Lantai =15, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1510", CategorieID = 11, Lantai =15, StatusID = 1, Inhouse = 1625686738, PriceKPR=1857828171},
 new AptUnit { UnitNo = "1511", CategorieID = 10, Lantai =15, StatusID = 1, Inhouse = 744717576, PriceKPR=851060207},
 new AptUnit { UnitNo = "1512", CategorieID = 1, Lantai =15, StatusID = 1, Inhouse = 1656016669, PriceKPR=1802370614},
 new AptUnit { UnitNo = "1515", CategorieID = 12, Lantai =15, StatusID = 1, Inhouse = 1625686738, PriceKPR=1857828171},
 new AptUnit { UnitNo = "1502A", CategorieID = 5, Lantai =15, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1502B", CategorieID = 5, Lantai =15, StatusID = 1, Inhouse = 1339583478, PriceKPR=1530870533},
 new AptUnit { UnitNo = "1601", CategorieID = 13, Lantai =16, StatusID = 1, Inhouse = 1778736465, PriceKPR=2032732775},
 new AptUnit { UnitNo = "1603", CategorieID = 14, Lantai =16, StatusID = 1, Inhouse = 691803432, PriceKPR=790590140},
 new AptUnit { UnitNo = "1605", CategorieID = 1, Lantai =16, StatusID = 1, Inhouse = 691803432, PriceKPR=790590140},
 new AptUnit { UnitNo = "1606", CategorieID = 1, Lantai =16, StatusID = 1, Inhouse = 1761938324, PriceKPR=2013535928},
 new AptUnit { UnitNo = "1607", CategorieID = 1, Lantai =16, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1608", CategorieID = 10, Lantai =16, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1609", CategorieID = 6, Lantai =16, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1610", CategorieID = 11, Lantai =16, StatusID = 1, Inhouse = 1625686738, PriceKPR=1857828171},
 new AptUnit { UnitNo = "1611", CategorieID = 10, Lantai =16, StatusID = 1, Inhouse = 744717576, PriceKPR=851060207},
 new AptUnit { UnitNo = "1612", CategorieID = 1, Lantai =16, StatusID = 1, Inhouse = 1577158775, PriceKPR=1802370614},
 new AptUnit { UnitNo = "1615", CategorieID = 12, Lantai =16, StatusID = 1, Inhouse = 1625686738, PriceKPR=1857828171},
 new AptUnit { UnitNo = "1602A", CategorieID = 5, Lantai =16, StatusID = 1, Inhouse = 670059172, PriceKPR=765740888},
 new AptUnit { UnitNo = "1602B", CategorieID = 5, Lantai =16, StatusID = 1, Inhouse = 1338251884, PriceKPR=1529348793},
 new AptUnit { UnitNo = "1701", CategorieID = 13, Lantai =17, StatusID = 1, Inhouse = 1780506352, PriceKPR=2034755395},
 new AptUnit { UnitNo = "1703", CategorieID = 14, Lantai =17, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "1705", CategorieID = 1, Lantai =17, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "1706", CategorieID = 1, Lantai =17, StatusID = 1, Inhouse = 1763691497, PriceKPR=2015539447},
 new AptUnit { UnitNo = "1707", CategorieID = 1, Lantai =17, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1708", CategorieID = 10, Lantai =17, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1709", CategorieID = 6, Lantai =17, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1710", CategorieID = 11, Lantai =17, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "1711", CategorieID = 10, Lantai =17, StatusID = 1, Inhouse = 745458588, PriceKPR=851907033},
 new AptUnit { UnitNo = "1712", CategorieID = 1, Lantai =17, StatusID = 1, Inhouse = 1578728088, PriceKPR=1804164017},
 new AptUnit { UnitNo = "1715", CategorieID = 12, Lantai =17, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "1702A", CategorieID = 5, Lantai =17, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1702B", CategorieID = 5, Lantai =17, StatusID = 1, Inhouse = 1339583478, PriceKPR=1530870533},
 new AptUnit { UnitNo = "1801", CategorieID = 13, Lantai =18, StatusID = 1, Inhouse = 1780506352, PriceKPR=2034755395},
 new AptUnit { UnitNo = "1803", CategorieID = 14, Lantai =18, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "1805", CategorieID = 1, Lantai =18, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "1806", CategorieID = 1, Lantai =18, StatusID = 1, Inhouse = 1763691497, PriceKPR=2015539447},
 new AptUnit { UnitNo = "1807", CategorieID = 1, Lantai =18, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1808", CategorieID = 10, Lantai =18, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1809", CategorieID = 6, Lantai =18, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1810", CategorieID = 11, Lantai =18, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "1811", CategorieID = 10, Lantai =18, StatusID = 1, Inhouse = 745458588, PriceKPR=851907033},
 new AptUnit { UnitNo = "1812", CategorieID = 1, Lantai =18, StatusID = 1, Inhouse = 1578728088, PriceKPR=1804164017},
 new AptUnit { UnitNo = "1815", CategorieID = 12, Lantai =18, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "1802A", CategorieID = 5, Lantai =18, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1802B", CategorieID = 5, Lantai =18, StatusID = 1, Inhouse = 1339583478, PriceKPR=1530870533},
 new AptUnit { UnitNo = "1901", CategorieID = 13, Lantai =19, StatusID = 1, Inhouse = 1780506352, PriceKPR=2034755395},
 new AptUnit { UnitNo = "1903", CategorieID = 14, Lantai =19, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "1905", CategorieID = 1, Lantai =19, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "1906", CategorieID = 1, Lantai =19, StatusID = 1, Inhouse = 1763691497, PriceKPR=2015539447},
 new AptUnit { UnitNo = "1907", CategorieID = 1, Lantai =19, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1908", CategorieID = 10, Lantai =19, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1909", CategorieID = 6, Lantai =19, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1910", CategorieID = 11, Lantai =19, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "1911", CategorieID = 10, Lantai =19, StatusID = 1, Inhouse = 745458588, PriceKPR=851907033},
 new AptUnit { UnitNo = "1912", CategorieID = 1, Lantai =19, StatusID = 1, Inhouse = 1578728088, PriceKPR=1804164017},
 new AptUnit { UnitNo = "1915", CategorieID = 12, Lantai =19, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "1902A", CategorieID = 5, Lantai =19, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "1902B", CategorieID = 5, Lantai =19, StatusID = 1, Inhouse = 1339583478, PriceKPR=1530870533},
 new AptUnit { UnitNo = "2001", CategorieID = 13, Lantai =20, StatusID = 1, Inhouse = 1780506352, PriceKPR=2034755395},
 new AptUnit { UnitNo = "2003", CategorieID = 14, Lantai =20, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "2005", CategorieID = 1, Lantai =20, StatusID = 1, Inhouse = 692491794, PriceKPR=791376797},
 new AptUnit { UnitNo = "2006", CategorieID = 1, Lantai =20, StatusID = 1, Inhouse = 1763691497, PriceKPR=2015539447},
 new AptUnit { UnitNo = "2007", CategorieID = 1, Lantai =20, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "2008", CategorieID = 10, Lantai =20, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "2009", CategorieID = 6, Lantai =20, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "2010", CategorieID = 11, Lantai =20, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "2011", CategorieID = 10, Lantai =20, StatusID = 1, Inhouse = 745458588, PriceKPR=851907033},
 new AptUnit { UnitNo = "2012", CategorieID = 1, Lantai =20, StatusID = 1, Inhouse = 1578728088, PriceKPR=1804164017},
 new AptUnit { UnitNo = "2015", CategorieID = 12, Lantai =20, StatusID = 1, Inhouse = 1627304336, PriceKPR=1859676756},
 new AptUnit { UnitNo = "2002A", CategorieID = 5, Lantai =20, StatusID = 1, Inhouse = 670725898, PriceKPR=766502819},
 new AptUnit { UnitNo = "2002B", CategorieID = 5, Lantai =20, StatusID = 1, Inhouse = 1339583478, PriceKPR=1530870533},
 new AptUnit { UnitNo = "2101", CategorieID = 13, Lantai =21, StatusID = 1, Inhouse = 1782276239, PriceKPR=2036778015},
 new AptUnit { UnitNo = "2103", CategorieID = 14, Lantai =21, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2105", CategorieID = 1, Lantai =21, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2106", CategorieID = 1, Lantai =21, StatusID = 1, Inhouse = 1765444669, PriceKPR=2017542965},
 new AptUnit { UnitNo = "2107", CategorieID = 1, Lantai =21, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2108", CategorieID = 10, Lantai =21, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2109", CategorieID = 6, Lantai =21, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2110", CategorieID = 11, Lantai =21, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2111", CategorieID = 10, Lantai =21, StatusID = 1, Inhouse = 746199601, PriceKPR=852753859},
 new AptUnit { UnitNo = "2112", CategorieID = 1, Lantai =21, StatusID = 1, Inhouse = 1580297400, PriceKPR=1805957421},
 new AptUnit { UnitNo = "2115", CategorieID = 12, Lantai =21, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2102A", CategorieID = 5, Lantai =21, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2102B", CategorieID = 5, Lantai =21, StatusID = 1, Inhouse = 1340915072, PriceKPR=1532392273},
 new AptUnit { UnitNo = "2201", CategorieID = 13, Lantai =22, StatusID = 1, Inhouse = 1782276239, PriceKPR=2036778015},
 new AptUnit { UnitNo = "2203", CategorieID = 14, Lantai =22, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2205", CategorieID = 1, Lantai =22, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2206", CategorieID = 1, Lantai =22, StatusID = 1, Inhouse = 1765444669, PriceKPR=2017542965},
 new AptUnit { UnitNo = "2207", CategorieID = 1, Lantai =22, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2208", CategorieID = 10, Lantai =22, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2209", CategorieID = 6, Lantai =22, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2210", CategorieID = 11, Lantai =22, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2211", CategorieID = 10, Lantai =22, StatusID = 1, Inhouse = 746199601, PriceKPR=852753859},
 new AptUnit { UnitNo = "2212", CategorieID = 1, Lantai =22, StatusID = 1, Inhouse = 1580297400, PriceKPR=1805957421},
 new AptUnit { UnitNo = "2215", CategorieID = 12, Lantai =22, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2202A", CategorieID = 5, Lantai =22, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2202B", CategorieID = 5, Lantai =22, StatusID = 1, Inhouse = 1340915072, PriceKPR=1532392273},
 new AptUnit { UnitNo = "2301", CategorieID = 13, Lantai =23, StatusID = 1, Inhouse = 1782276239, PriceKPR=2036778015},
 new AptUnit { UnitNo = "2303", CategorieID = 14, Lantai =23, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2305", CategorieID = 1, Lantai =23, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2306", CategorieID = 1, Lantai =23, StatusID = 1, Inhouse = 1765444669, PriceKPR=2017542965},
 new AptUnit { UnitNo = "2307", CategorieID = 1, Lantai =23, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2308", CategorieID = 10, Lantai =23, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2309", CategorieID = 6, Lantai =23, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2310", CategorieID = 11, Lantai =23, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2311", CategorieID = 10, Lantai =23, StatusID = 1, Inhouse = 746199601, PriceKPR=852753859},
 new AptUnit { UnitNo = "2312", CategorieID = 1, Lantai =23, StatusID = 1, Inhouse = 1580297400, PriceKPR=1805957421},
 new AptUnit { UnitNo = "2315", CategorieID = 12, Lantai =23, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2302A", CategorieID = 5, Lantai =23, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2302B", CategorieID = 5, Lantai =23, StatusID = 1, Inhouse = 1340915072, PriceKPR=1532392273},
 new AptUnit { UnitNo = "2501", CategorieID = 13, Lantai =25, StatusID = 1, Inhouse = 1782276239, PriceKPR=2036778015},
 new AptUnit { UnitNo = "2503", CategorieID = 14, Lantai =25, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2505", CategorieID = 1, Lantai =25, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2506", CategorieID = 1, Lantai =25, StatusID = 1, Inhouse = 1765444669, PriceKPR=2017542965},
 new AptUnit { UnitNo = "2507", CategorieID = 1, Lantai =25, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2508", CategorieID = 10, Lantai =25, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2509", CategorieID = 6, Lantai =25, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2510", CategorieID = 11, Lantai =25, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2511", CategorieID = 10, Lantai =25, StatusID = 1, Inhouse = 746199601, PriceKPR=852753859},
 new AptUnit { UnitNo = "2512", CategorieID = 1, Lantai =25, StatusID = 1, Inhouse = 1580297400, PriceKPR=1805957421},
 new AptUnit { UnitNo = "2515", CategorieID = 12, Lantai =25, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2502A", CategorieID = 5, Lantai =25, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2502B", CategorieID = 5, Lantai =25, StatusID = 1, Inhouse = 1340915072, PriceKPR=1532392273},
 new AptUnit { UnitNo = "2601", CategorieID = 13, Lantai =26, StatusID = 1, Inhouse = 1782276239, PriceKPR=2036778015},
 new AptUnit { UnitNo = "2603", CategorieID = 14, Lantai =26, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2605", CategorieID = 1, Lantai =26, StatusID = 1, Inhouse = 693180155, PriceKPR=792163453},
 new AptUnit { UnitNo = "2606", CategorieID = 1, Lantai =26, StatusID = 1, Inhouse = 1765444669, PriceKPR=2017542965},
 new AptUnit { UnitNo = "2607", CategorieID = 1, Lantai =26, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2608", CategorieID = 10, Lantai =26, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2609", CategorieID = 6, Lantai =26, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2610", CategorieID = 11, Lantai =26, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2611", CategorieID = 10, Lantai =26, StatusID = 1, Inhouse = 746199601, PriceKPR=852753859},
 new AptUnit { UnitNo = "2612", CategorieID = 1, Lantai =26, StatusID = 1, Inhouse = 1580297400, PriceKPR=1805957421},
 new AptUnit { UnitNo = "2615", CategorieID = 12, Lantai =26, StatusID = 1, Inhouse = 1628921935, PriceKPR=1861525342},
 new AptUnit { UnitNo = "2602A", CategorieID = 5, Lantai =26, StatusID = 1, Inhouse = 671392623, PriceKPR=767264750},
 new AptUnit { UnitNo = "2602B", CategorieID = 5, Lantai =26, StatusID = 1, Inhouse = 1340915072, PriceKPR=1532392273},
 new AptUnit { UnitNo = "2701", CategorieID = 1, Lantai =27, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2702", CategorieID = 10, Lantai =27, StatusID = 1, Inhouse = 1632157133, PriceKPR=1865222512},
 new AptUnit { UnitNo = "2703", CategorieID = 6, Lantai =27, StatusID = 1, Inhouse = 748422638, PriceKPR=855294337},
 new AptUnit { UnitNo = "2705", CategorieID = 11, Lantai =27, StatusID = 1, Inhouse = 1662607825, PriceKPR=1900021440},
 new AptUnit { UnitNo = "2706", CategorieID = 15, Lantai =27, StatusID = 1, Inhouse = 2316126540, PriceKPR=2646859960},
 new AptUnit { UnitNo = "2707", CategorieID = 1, Lantai =27, StatusID = 1, Inhouse = 673392800, PriceKPR=769550544},
 new AptUnit { UnitNo = "2708", CategorieID = 16, Lantai =27, StatusID = 1, Inhouse = 2449172643, PriceKPR=2798904505},
 new AptUnit { UnitNo = "2710", CategorieID = 14, Lantai =27, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "2711", CategorieID = 1, Lantai =27, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "2712", CategorieID = 1, Lantai =27, StatusID = 1, Inhouse = 1768951014, PriceKPR=2021550002},
 new AptUnit { UnitNo = "2709A", CategorieID = 5, Lantai =27, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2709B", CategorieID = 5, Lantai =27, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2801", CategorieID = 1, Lantai =28, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2802", CategorieID = 10, Lantai =28, StatusID = 1, Inhouse = 1632157133, PriceKPR=1865222512},
 new AptUnit { UnitNo = "2803", CategorieID = 6, Lantai =28, StatusID = 1, Inhouse = 748422638, PriceKPR=855294337},
 new AptUnit { UnitNo = "2805", CategorieID = 11, Lantai =28, StatusID = 1, Inhouse = 1583436024, PriceKPR=1809544228},
 new AptUnit { UnitNo = "2806", CategorieID = 15, Lantai =28, StatusID = 1, Inhouse = 2316126540, PriceKPR=2646859960},
 new AptUnit { UnitNo = "2807", CategorieID = 1, Lantai =28, StatusID = 1, Inhouse = 673392800, PriceKPR=769550544},
 new AptUnit { UnitNo = "2808", CategorieID = 16, Lantai =28, StatusID = 1, Inhouse = 2449172643, PriceKPR=2798904505},
 new AptUnit { UnitNo = "2810", CategorieID = 14, Lantai =28, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "2811", CategorieID = 1, Lantai =28, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "2812", CategorieID = 1, Lantai =28, StatusID = 1, Inhouse = 1768951014, PriceKPR=2021550002},
 new AptUnit { UnitNo = "2809A", CategorieID = 5, Lantai =28, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2809B", CategorieID = 5, Lantai =28, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2901", CategorieID = 1, Lantai =29, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2902", CategorieID = 10, Lantai =29, StatusID = 1, Inhouse = 1632157133, PriceKPR=1865222512},
 new AptUnit { UnitNo = "2903", CategorieID = 6, Lantai =29, StatusID = 1, Inhouse = 748422638, PriceKPR=855294337},
 new AptUnit { UnitNo = "2905", CategorieID = 11, Lantai =29, StatusID = 1, Inhouse = 1583436024, PriceKPR=1809544228},
 new AptUnit { UnitNo = "2906", CategorieID = 15, Lantai =29, StatusID = 1, Inhouse = 2316126540, PriceKPR=2646859960},
 new AptUnit { UnitNo = "2907", CategorieID = 1, Lantai =29, StatusID = 1, Inhouse = 673392800, PriceKPR=769550544},
 new AptUnit { UnitNo = "2908", CategorieID = 16, Lantai =29, StatusID = 1, Inhouse = 2449172643, PriceKPR=2798904505},
 new AptUnit { UnitNo = "2910", CategorieID = 14, Lantai =29, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "2911", CategorieID = 1, Lantai =29, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "2912", CategorieID = 1, Lantai =29, StatusID = 1, Inhouse = 1768951014, PriceKPR=2021550002},
 new AptUnit { UnitNo = "2909A", CategorieID = 5, Lantai =29, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "2909B", CategorieID = 5, Lantai =29, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "3001", CategorieID = 1, Lantai =30, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "3002", CategorieID = 10, Lantai =30, StatusID = 1, Inhouse = 1632157133, PriceKPR=1865222512},
 new AptUnit { UnitNo = "3003", CategorieID = 6, Lantai =30, StatusID = 1, Inhouse = 748422638, PriceKPR=855294337},
 new AptUnit { UnitNo = "3005", CategorieID = 11, Lantai =30, StatusID = 1, Inhouse = 1583436024, PriceKPR=1809544228},
 new AptUnit { UnitNo = "3006", CategorieID = 15, Lantai =30, StatusID = 1, Inhouse = 2316126540, PriceKPR=2646859960},
 new AptUnit { UnitNo = "3007", CategorieID = 1, Lantai =30, StatusID = 1, Inhouse = 673392800, PriceKPR=769550544},
 new AptUnit { UnitNo = "3008", CategorieID = 16, Lantai =30, StatusID = 1, Inhouse = 2449172643, PriceKPR=2798904505},
 new AptUnit { UnitNo = "3010", CategorieID = 14, Lantai =30, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "3011", CategorieID = 1, Lantai =30, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "3012", CategorieID = 1, Lantai =30, StatusID = 1, Inhouse = 1768951014, PriceKPR=2021550002},
 new AptUnit { UnitNo = "3009A", CategorieID = 5, Lantai =30, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "3009B", CategorieID = 5, Lantai =30, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "3101", CategorieID = 1, Lantai =31, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "3102", CategorieID = 10, Lantai =31, StatusID = 1, Inhouse = 1632157133, PriceKPR=1865222512},
 new AptUnit { UnitNo = "3103", CategorieID = 6, Lantai =31, StatusID = 1, Inhouse = 748422638, PriceKPR=855294337},
 new AptUnit { UnitNo = "3105", CategorieID = 11, Lantai =31, StatusID = 1, Inhouse = 1583436024, PriceKPR=1809544228},
 new AptUnit { UnitNo = "3106", CategorieID = 15, Lantai =31, StatusID = 1, Inhouse = 2316126540, PriceKPR=2646859960},
 new AptUnit { UnitNo = "3107", CategorieID = 1, Lantai =31, StatusID = 1, Inhouse = 673392800, PriceKPR=769550544},
 new AptUnit { UnitNo = "3108", CategorieID = 16, Lantai =31, StatusID = 1, Inhouse = 2449172643, PriceKPR=2798904505},
 new AptUnit { UnitNo = "3110", CategorieID = 14, Lantai =31, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "3111", CategorieID = 1, Lantai =31, StatusID = 1, Inhouse = 694556879, PriceKPR=793736767},
 new AptUnit { UnitNo = "3112", CategorieID = 1, Lantai =31, StatusID = 1, Inhouse = 1768951014, PriceKPR=2021550002},
 new AptUnit { UnitNo = "3109A", CategorieID = 5, Lantai =31, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613},
 new AptUnit { UnitNo = "3109B", CategorieID = 5, Lantai =31, StatusID = 1, Inhouse = 672726074, PriceKPR=768788613}

            };


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
