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

            TipeGl.Add(new ArCustomer { ShortName = "A0001", CustomerName = "ANITA LUCIA KENDARTO", Ktp = "357824690968002", Alamat = "KUTISARI SELATAN", AlamatSekarang = "KUTISARI SELATAN", Email = "", Phone = "", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "A0002", CustomerName = "AGUS SUYANTO", Ktp = "3519011005760007", Alamat = "DESA KEDONDONG RT 09/ RW 03 MADIUN", AlamatSekarang = "DESA KEDONDONG RT 09/ RW 03 MADIUN", Email = "", Phone = "081235535576", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "A0005", CustomerName = "ANNI", Ktp = "3578215310480001", Alamat = "DARMO PERMAI UTARA 12, RT 002, RW 007, KEL. PRADAH KALI KENDAL, KEC. DUKUH PAKIS", AlamatSekarang = "ARMO PERMAI UTARA 12, RT 002, RW 007, KEL. PRADAH KALI KENDAL, KEC. DUKUH PAKIS", Email = "B3NNY281179@YAHOO.COM", Phone = "08121721719", Npwp = "24.909.657.9-618.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "A0007", CustomerName = "AL AMIN IBNU FAJAR", Ktp = "357815061293002", Alamat = "POGOT PALM REGENCY BLOK C/8-9 RT.006 / 008, TANAH KALI KEDINDING KENHERAN", AlamatSekarang = "SIDOTOPO WETAN I DALAM NO.47", Email = "ALAMINIBNU @YAHOO.COM", Phone = "081332008983", Npwp = "16.975.005.6 - 619.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "B0001", CustomerName = "BARA LAZUARDI, DRS", Ktp = "3578241703390001", Alamat = "SIMPANG DARMO PERMAI UTARA 1/07", AlamatSekarang = "SIMPANG DARMO PERMAI UTARA 1/07", Email = "", Phone = "     081553773234", Npwp = "47.691.209.2-615.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "B0002", CustomerName = "BUDI DARMAWAN", Ktp = "3578100712880001", Alamat = "KALIKEPITING 125-D/8", AlamatSekarang = "MOJOARUM IV/3A", Email = "HEAVEN071288@GMAIL.COM", Phone = "081231347770", Npwp = "460578503619000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "B0003", CustomerName = "BUNGA AYU PRIMANANDA", Ktp = "3578066404950005", Alamat = "PAKIS TIRTO SARI 10-A/2", AlamatSekarang = "PAKIS TIRTO SARI 10-A/2", Email = "", Phone = "081703318921", Npwp = "93.113.554.6-614.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "B0004", CustomerName = "BILLY DANUHARJA", Ktp = "3515181001980003", Alamat = "JL. JERUK VI/27 PCI", AlamatSekarang = "JL. RUNGKUT MAPAN BARAT III/BB 20 SBY", Email = "BILLYDANUHARJA.BD@GMAIL.COM", Phone = "081331030931", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "C0001", CustomerName = "CHRISSIA SUANTO", Ktp = "3578134312860005", Alamat = "DARMO BARU BARAT 7/68 RT 005/002 SONO KWIJENAN SUKOMANUNGGAL ", AlamatSekarang = "DARMO BARU BARAT 7/68", Email = "georgetan76 @yahoo.com", Phone = "082131711257", Npwp = "", KodePos = "60189" });
            TipeGl.Add(new ArCustomer { ShortName = "C0002", CustomerName = "CYNTHIA M TOMASOA", Ktp = "357820480570000", Alamat = "GRIYA BABATAN MUKTI 4-53/76-37", AlamatSekarang = "GRIYA BABATAN MUKTI 4-53/76-37", Email = "", Phone = "081233900276", Npwp = "80.879.127.7-618.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "C0003", CustomerName = "CHRISTOPHER WILLIAM SAPUTRA", Ktp = "3577031411960001", Alamat = "TRUNOJOYO NO 53 MADIUN", AlamatSekarang = "TRUNOJOYO NO 53 MADIUN", Email = "", Phone = "082218845497", Npwp = "83.274.195.3.621.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "D0001", CustomerName = "DEVY BUDYANTO", Ktp = "3578020311560002", Alamat = "MARGOREJO INDAH C-713 KEL. MARGOREJO KEC. WONOCOLO KOTA SURABAYA", AlamatSekarang = "MARGOREJO INDAH C-713 KEL. MARGOREJO KEC. WONOCOLO KOTA SURABAYA", Email = "", Phone = "", Npwp = "06.711.597.2-609.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "D0003", CustomerName = "DENNY SETIAWAN S / DWIE RATNA WINARSIH", Ktp = "3578271506860004/35782766", Alamat = "TANJUNG SARI BARU 8-QQ7 / MANUKAN TAMA BLOK 33-H/ 17", AlamatSekarang = "TANJUNG SARI BARU 8-QQ7 / MANUKAN TAMA BLOK 33-H/ 17", Email = "", Phone = "08113346783    /    0811322405", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "D0007", CustomerName = "DR. LANNY NOVIANTI", Ktp = "3674026311620005", Alamat = "GRB. ANGGREK LOKA BLOK A-4/30 RT.003/007 PAKU JAYA, SERPONG UTARA", AlamatSekarang = "GRB.ANGGREK LOKA BLOK A-4/30 RT.003/007 PAKU JAYA, SERPONG UTARA", Email = "LANNYN23 @gmail.com", Phone = "08161389518", Npwp = "59.448.881.9-411.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "D0008", CustomerName = "DARWAN J", Ktp = "3578261603790001", Alamat = "DHARMAHUSADA INDAH TIMUR L-72", AlamatSekarang = "DHARMAHUSADA INDAH TIMUR L-72", Email = "", Phone = "08165420108/081939120156", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "E0001", CustomerName = "ELIZA KURNIAWATI YUWONO", Ktp = "3578065603880002", Alamat = "JL.P.SUDIRMAN NO 68 TULUNGAGUNG", AlamatSekarang = "MAYJEN SUNGKONO I TULUNG AGUNG (APT.BUDI MULYA )", Email = "ELIZAKY88@GMAIL.COM", Phone = "08175088163", Npwp = "81.577.081.3-629.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "E0002", CustomerName = "ENGE CHRISTINA", Ktp = "3578276104800002", Alamat = "RAYA SUKOMANUNGGAL JAYA YL 10", AlamatSekarang = "RAYA SUKOMANUNGGAL JAYA YL 10", Email = "", Phone = "08998668888", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "E0003", CustomerName = "ENDANG PURWANTI", Ktp = "3515104807720003", Alamat = "MANGGA IV/H-119", AlamatSekarang = "MANGGA IV/ H-19", Email = "DANIEL.ALBERT73@GMAIL.COM", Phone = "08123204454/08883215121", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "E0004", CustomerName = "ENDIEK NUSWANTORO", Ktp = "3578162003820010", Alamat = "AMPEL KEMBANG 28, RT 003, RW 002, KEL. AMPEL, KEC. SEMAMPIR", AlamatSekarang = "AMPEL KEMBANG 28, RT 003, RW 002, KEL. AMPEL, KEC. SEMAMPIR", Email = "", Phone = "08123067444 / 085655352043", Npwp = "09.758.684.6-616.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "E0005", CustomerName = "ELLYJINA ZUBAIDAH", Ktp = "3578206610700002", Alamat = "JAJAR TUNGGAL UTARA BLOK D/19", AlamatSekarang = "JL. GAYUNG KEBONSARI PERUM GRAHA INDAH H-6", Email = "elly.leNs@gmail.com", Phone = "08155073606 / 089502667900", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "F0001", CustomerName = "FRANSISCA RATNA RAHARDJO", Ktp = "3578106711930002", Alamat = "RAYA DARMO PERMAI 3 NO 10,SURABAYA", AlamatSekarang = "RAYA DARMO PERMAI 3 NO 10,SURABAYA", Email = "vangrahardjo@gmail.com", Phone = "08170717262/081230303329", Npwp = "", KodePos = "60187" });
            TipeGl.Add(new ArCustomer { ShortName = "F0002", CustomerName = "FIBULA DIFINCI HALIM", Ktp = "3578255411920001", Alamat = "RUNGKUT MAPAN BARAT III/ BB 20", AlamatSekarang = "RUKAN FRENCH WALK BLOK C NO 45 JAKARTA UTARA (MOI)", Email = "VIVISNELIEM@GMAIL.COM", Phone = "082232400027", Npwp = "54.149.235.1-036.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "F0003", CustomerName = "FITRIASTUTIK KUMALA SARI", Ktp = "3513146602870001", Alamat = "GUNUNG ANYAR EMAS SELATAN IV BLOK C2/12, RT 005, RW 008, KEL. GUNUNG ANYAR TAMBAK, KEC. GUNUNG ANYAR", AlamatSekarang = "GUNUNG ANYAR EMAS SELATAN IV BLOK C2/12, RT 005, RW 008, KEL. GUNUNG ANYAR TAMBAK, KEC. GUNUNG ANYAR", Email = "FITRIASTUTIK.KUMALASARI@GMAIL.COM", Phone = "08123263289", Npwp = "18.514.364.1-607.000", KodePos = "60000" });
            TipeGl.Add(new ArCustomer { ShortName = "G0001", CustomerName = "GIDEON SATRIA NUGRAHA", Ktp = "3204091101920002", Alamat = "SUKAMENAK INDAH BLOK N-18 MARGAHAYU, BANDUNG", AlamatSekarang = "SUKAMENAK INDAH BLOK N-18 MARGAHAYU, BANDUNG", Email = "GIDEON.SATRIA@YAHOO.COM", Phone = "082126165605", Npwp = "76.566.621.9-445.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "G0002", CustomerName = " YUSIK ARIANTO", Ktp = "3571021905670004", Alamat = "NGADISIMO GG I /6 KEDIRI", AlamatSekarang = "NGADISIMO GG I /6 KEDIRI", Email = "", Phone = "0816567007", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "G0003", CustomerName = "GUNTUR PRATAMA WIJAYANTO", Ktp = "3578141803900004", Alamat = "KEPUTRAN KEJAMBON II/86", AlamatSekarang = "MELON UTARA II/ 30 PONDOK TJANDRA", Email = "GUNTUR.HUANG90@GMAIL.COM", Phone = "087774742800", Npwp = "80.894.823.6-611.000", KodePos = "6125" });
            TipeGl.Add(new ArCustomer { ShortName = "G0004", CustomerName = "GOESMAN JAYA", Ktp = "000", Alamat = "TAMBAK POKAK 29", AlamatSekarang = "TAMBAK POKAK 29", Email = "goesmanjaya@yahoo.com", Phone = "085231163547", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "H0001", CustomerName = "HEPPY", Ktp = "3171020301780003", Alamat = "WONOREJO PERMAI II BLOK AA-28 SURABAYA", AlamatSekarang = "WONOREJO PERMAI II BLOK AA-28 SURABAYA", Email = "HEPPYCH@YAHOO.COM", Phone = "081318381699", Npwp = "78.708.923.4-215.000", KodePos = "60296" });
            TipeGl.Add(new ArCustomer { ShortName = "H0002", CustomerName = "HERRY SUSASTRIA", Ktp = "3573010404670007", Alamat = "JL. TAMAN SULFAT XIII/25", AlamatSekarang = "JL. TAMAN SULFAT XIII/25", Email = "MAYASUSATRIA@YAHOO.COM", Phone = "", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "H0004", CustomerName = "HARRY IDWAN HADIMAN", Ktp = "3273061212690015", Alamat = "JL. ABDURAHMAN SALEH NO.8 RT.08 / RW.03 BANDUNG", AlamatSekarang = "JL.ABDURAHMAN SALEH NO.8 RT.08 / RW.03 BANDUNG", Email = "", Phone = "081314974581", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "H0005", CustomerName = "HADIJANTO TJOKROWIDJOJO", Ktp = "357807030680003", Alamat = "UNDAAN KULON 41,SURABAYA", AlamatSekarang = "GRAHA FAMILY N-127", Email = "hadiyanto80@hotmail.com", Phone = "082233440808", Npwp = "09.756.168.2-611.000", KodePos = "60228" });
            TipeGl.Add(new ArCustomer { ShortName = "H0006", CustomerName = "HARKY O.J. MESAKH", Ktp = "3578181210970001", Alamat = "WISMA LIDAH KULON BLOK B/91A RT.001/RW.004 LIDAH KULON, LAKAR SANTRI", AlamatSekarang = "JL.BUKIT TELAGA GOLF TA 6/27 NEWTON HILL", Email = "harkyobed @gmail.com", Phone = "081357625343", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "H0007", CustomerName = "HERMANSYAH SETIADI", Ktp = "3578262505670003", Alamat = "KALIJUDAN ASRI INDAH 58-A", AlamatSekarang = "KALIJUDAN ASRI INDAH 58-A", Email = "", Phone = "081357027399", Npwp = "08.610.1755-619.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "I0001", CustomerName = "IDA TJEMPAKA JUWONO", Ktp = "3515086502640003", Alamat = "JL. KBP M DURIAT 56 - SIDOARJO", AlamatSekarang = "JL. KBP M DURIAT 56 - SIDOARJO", Email = "", Phone = "", Npwp = "14.250.698.9-977", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "I0002", CustomerName = "IR. AHMAD SULAEMAN", Ktp = "3578022403670004", Alamat = "MARGOREJO INDAH BLOK B-113, RT 002, RW 008, KEL. MARGOREJO, KEC. WONOCOLO", AlamatSekarang = "MARGOREJO INDAH BLOK B-113, RT 002, RW 008, KEL. MARGOREJO, KEC. WONOCOLO", Email = "AHMAD.SULAEMAN@YMAIL.COM", Phone = "08128044039", Npwp = "09.811.447.3-609.000", KodePos = "60238" });
            TipeGl.Add(new ArCustomer { ShortName = "I0003", CustomerName = "IVONNE TAN", Ktp = "3578265305640001", Alamat = "MULYOSARI PRIMA 1/12 MB-8 RT.001, RW.007 KALISARI , MULYOREJO", AlamatSekarang = "MULYOSARI PRIMA 1/12 MB-8 RT.001 RW.007 KALISARI MULYOREJO", Email = "", Phone = "08113540620", Npwp = "18.754.526.4-619.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "I0004", CustomerName = "IVONNE TAN", Ktp = "3578265305640001", Alamat = "MULYOSARI PRIMA 1/12 MB-8 RT.001, RW.007 KALISARI , MULYOREJO", AlamatSekarang = "MULYOSARI PRIMA 1/12 MB-8 RT.001 RW.007 KALISARI MULYOREJO", Email = "", Phone = "08113540620", Npwp = "18.754.526.4-619.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "J0001", CustomerName = "JULIUS RUSNAJAYA", Ktp = "3273202107860004", Alamat = "JL MOJOARUM 2 NO 28 SURABAYA", AlamatSekarang = "JL MOJOARUM 2 NO 28 SURABAYA", Email = "BLUE12@HOTMAIL.COM", Phone = "", Npwp = "34.176.080.9-301.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "J0002", CustomerName = "JAUW TAUW LING", Ktp = "3578071207620002", Alamat = "GONDOSULI NO 7 SURABAYA", AlamatSekarang = "GONDOSULI NO 7 SURABAYA", Email = "", Phone = "08123020287", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "J0003", CustomerName = "JEFFRILIN KANGIN", Ktp = "357827907920001", Alamat = "KUPANG BARU 2/14", AlamatSekarang = "VILLA BALCIT REGENCY III PE 9 NO 6", Email = "JEFFRILIN.KANGIN@OUTLOOK.COM", Phone = "", Npwp = "45.979.638.9-604.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "J0004", CustomerName = "JUSUF WIDJAJA", Ktp = "3515182802710007", Alamat = "KETINTANG BARU SELATAN IX/60", AlamatSekarang = "KETINTANG BARU SELATAN IX/60", Email = "jusufwidjaja88@gmail.com", Phone = "081234516748", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "K0001", CustomerName = "KEVIN STEVANO", Ktp = "3578212710900003", Alamat = "DUKUH KUPANG 17/42-A SURABAYA", AlamatSekarang = "DUKUH KUPANG 17/42-A SURABAYA", Email = "kevinstevano271090 @gmail.com", Phone = "", Npwp = "45.465.867.5-618.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "K0002", CustomerName = "KO GITO KUSNANTO", Ktp = "3578212806570001", Alamat = "DARMO PERMAI SELATAN II/56 SURABAYA", AlamatSekarang = "DARMO PERMAI SELATAN II/56 SURABAYA", Email = "", Phone = "0811322433/085102186858", Npwp = "80.746.994.5-618.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "K0003", CustomerName = "KUSUMA BUDIMAN ONGKODIHARDJO", Ktp = "3578072210490001", Alamat = "KEBANGSREN 1/14", AlamatSekarang = "TAMAN PUSPA RAYA C3-23", Email = "", Phone = "08981741579", Npwp = "04.194.587.4-611.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0001", CustomerName = "LEON ANDRUS SUSENIO", Ktp = "3578030808860002", Alamat = "KALI KEPITING JAYA 7/4", AlamatSekarang = "KALI KEPITING 7/4", Email = "LEONANDRUSS@GMAIL.COM", Phone = "", Npwp = "81.458.824.0-615.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0002", CustomerName = "LIDIAWATI", Ktp = "3578215206660002", Alamat = "SIMP. DARMO PERMAI SELATAN 3/5", AlamatSekarang = "SIMP. DARMO PERMAI SELATAN 3/5", Email = "", Phone = "", Npwp = "07.868.423.0-618.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0003", CustomerName = "LIANTO ATMODJO .DRS", Ktp = "3578313101670001", Alamat = "SIMPANG DARMO PERMAI SELATAN 14/26", AlamatSekarang = "SIMPANG DARMO PERMAI SELATAN 14/26", Email = "LIANTOATMODJO@GMAIL.COM", Phone = "08123113155", Npwp = "59.772.003.6-604.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0004", CustomerName = "LIM TJING HAUW/HENNY INDA L. H.", Ktp = "3578144111670003", Alamat = "TANDES LOR GANG II/78, RT 003, RW 006, KEL. TANDES, KEC. TANDES", AlamatSekarang = "TANDES LOR GANG II/78, RT 003, RW 006, KEL. TANDES, KEC. TANDES", Email = "", Phone = "085102404508", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0006", CustomerName = "LISA KARINA HANDOYO", Ktp = "3578125806900003", Alamat = "PENGAMPON 8/18, RT 008, RW 010, KEL. BONGKARAN, KEC. PABEAN CANTIAN", AlamatSekarang = "SATELIT INDAH I BLOK AN-1D", Email = "", Phone = "085230634665", Npwp = "71.737.106.6-618.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0008", CustomerName = "LUSIANA WIDJAJA", Ktp = "3578146104670003", Alamat = "DARMO INDAH SARI AA / 03", AlamatSekarang = "RAYA DARMO PERMAI 3 (PUNCAK PERMAI TA 768)", Email = "lusianawidjaja7 @gmail.com", Phone = "087853721388", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "L0009", CustomerName = "LANG AGUS ADHI LANATA", Ktp = "3578262708860003", Alamat = "D.HUSADA INDAH TIMUR 6/6 L-69 RT 004/ RW 009 KEL. MULYOREJO KEC. MULYOREJO", AlamatSekarang = "D.HUSADA INDAH TIMUR 6/6 L-69 RT 004/ RW 009 KEL. MULYOREJO KEC. MULYOREJO", Email = "chitra_christina88@yahoo.co.id", Phone = "083839777689", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "M0001", CustomerName = "MARCELINE LIVIA HEDYNATA", Ktp = "3374034407940003", Alamat = "CILIWUNG RAYA 15 SEMARANG", AlamatSekarang = "CILIWUNG RAYA NO 15 SEMARANG", Email = "michellelivia_94yahoo.com", Phone = "085225323456", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "M0002", CustomerName = "MIKHO HENRIDARMAWAN", Ktp = "3578310904860002", Alamat = "SIMPANG DARMO PERMAI SELATAN 15/201, SAMBI KEREP", AlamatSekarang = "SIMPANG DARMO PERMAI SELATAN 15/201, SAMBI KEREP", Email = "", Phone = "082234572229", Npwp = "", KodePos = "60216" });
            TipeGl.Add(new ArCustomer { ShortName = "M0004", CustomerName = "MUSTAKIM", Ktp = "3275120507690009", Alamat = "VILLA BESAKIH H 8/3, PURI GADING, RT 005, RW 013", AlamatSekarang = "KEPU BARAT NO. 2, KEMAYORAN, JAKARTA PUSAT", Email = "", Phone = "081210757556", Npwp = "84.377.218.7-447.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "N0001", CustomerName = "NOVI KURNIAWATI", Ktp = "3578135811870003", Alamat = "DEMAK SELATAN 4/27", AlamatSekarang = "DEMAK SELATAN 4/27", Email = "datapabrik2016@gmail.com", Phone = "081311113015", Npwp = "54.391.364.4.614.000", KodePos = "60173" });
            TipeGl.Add(new ArCustomer { ShortName = "O0002", CustomerName = "OEI WENDY SUTRISNO", Ktp = "3578271410900002", Alamat = "DARMO BARU BARAT 6/5, RT 004, RW 002, KEL. SONO KWIJENAN, KEC. SUKOMANUNGGAL", AlamatSekarang = "DARMO BARU BARAT 6/5, RT 004, RW 002, KEL. SONO KWIJENAN, KEC. SUKOMANUNGGAL", Email = "", Phone = "087777788568", Npwp = "70.278.869.6-604.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "P0001", CustomerName = "PT KARUNIA MULTIVEST INDOMAKMUR", Ktp = "", Alamat = "TANJUNGSARI BARU VIII QQ NO 7", AlamatSekarang = "TANJUNGSARI BARU VIII QQ NO 7", Email = "", Phone = "", Npwp = "75.234.462.1-604.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "P0003", CustomerName = "PT. DEANOVA MITRA MANDIRI", Ktp = "-", Alamat = "JL. GRIYA METROPOLITAN BLOK F-2 NO. 1 RT. 005 RW. 024 PEKAYON JAYA, BEKASI SELATAN/ KOTAMADYA BEKASI", AlamatSekarang = "JL.RAYA JATIASIH 399, BEKASI", Email = "", Phone = "", Npwp = "02.541.796.5-432.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0001", CustomerName = "RIDWAN  TJANDRA", Ktp = "3578101405800012", Alamat = "PLOSO TIMUR 4/67 SURABAYA", AlamatSekarang = "PLOSO TIMUR 4/67 SURABAYA", Email = "suryakencana1980@gmail.com", Phone = "", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0002", CustomerName = "ROBERT TANSIL", Ktp = "3578272104590002", Alamat = "PUNCAK PERMAI 1/9 DESA TANJUNGSARI KEC SUKOMANUNGGAL", AlamatSekarang = "BASUKI RACHMAT 45-47", Email = "jelysunjoto@yahoo.com", Phone = "031-5461991/0816501188", Npwp = "", KodePos = "60271" });
            TipeGl.Add(new ArCustomer { ShortName = "R0003", CustomerName = "RICHARD HARRIS YOEWONO", Ktp = "3515182812920009", Alamat = "JLN JERUK VI/ 27 PC 1", AlamatSekarang = "RUNGKUT MAPAN BARAT III/ BB 20", Email = "", Phone = "082159891234", Npwp = "80.890.916.2-643.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0005", CustomerName = "R.E. EKO BONDAN KURNIAWAN", Ktp = "3578250710670001", Alamat = "JL WIGUNA TIMUR XI/16", AlamatSekarang = "JL. WIGUNA TIMUR XI/16", Email = "X_BONDAN007@YAHOO.CO.ID", Phone = "08123584087", Npwp = "59.766.297.2-615.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0006", CustomerName = "RESTI NUR FARIDA", Ktp = "", Alamat = "DS DUDDUK SAMPEYAN RT 1 RW 1", AlamatSekarang = "JL JAWA INDAH II / 59 GKB GERSIK", Email = "RESTIFARIDA@YAHOO.COM", Phone = "081226541435 / 085732121408", Npwp = "82.943.720.1-612.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0007", CustomerName = "RAHAYU HARDIYANTI", Ktp = "3515085307630008", Alamat = "PURI INDAH BLOK C-02, RT 027, RW 008, KEL. SUKO, KEC. SIDOARJO", AlamatSekarang = "PURI INDAH BLOK C-02, RT 027, RW 008, KEL. SUKO, KEC. SIDOARJO", Email = "", Phone = "08175037111 / 0818755662", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0011", CustomerName = "RONY NEHEMIA PRAYOGO", Ktp = "3510070301910002", Alamat = "DUSUN KAMPUNG BARU RT.003 RW.002 KEL.JAJAG KEC.GAMBIRAN BANYUWANGI", AlamatSekarang = "NGAGEL WASANA VII/23", Email = "", Phone = "081249347551", Npwp = "71.700.501.1-627.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "R0013", CustomerName = "RENY HAMDANI", Ktp = "7472024905920001", Alamat = "JL. YOS SUDARSO NO 5", AlamatSekarang = "JL. YOS SUDARSO NO.5", Email = "RENI_9194@YAHOO.COM", Phone = "085342217777", Npwp = "74.273.272.0-816.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0001", CustomerName = "SIGIT HERDIANTO ST", Ktp = "3578230811830001", Alamat = "KEBONSARI IV/18 SURABAYA", AlamatSekarang = "KEBONSARI IV/18 SURABAYA", Email = "SIGITHERD @YAHOO.CO.ID", Phone = "", Npwp = "58.740.671.1-609.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0002", CustomerName = "SARI DEWI", Ktp = "3578084709780003", Alamat = "Wonorejo Sari 5/30 w-37 Surabaya", AlamatSekarang = "Wonorejo Sari 5/30 w-37 Surabaya", Email = "saridewijoo@yahoo.co.id", Phone = "081330797156", Npwp = "71.531.363.1-606.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0003", CustomerName = "SUJIANTO CHANDRA", Ktp = "3172023110771003", Alamat = "JL CILIK RIWUT KM 35 RT/RW 002/001 BUKIT TUNGGAL - PALANGKARAYA", AlamatSekarang = "JL CILIK RIWUT KM 35 RT/RW 002/001 BUKIT TUNGGAL - PALANGKARAYA", Email = "", Phone = "08121635777", Npwp = "82.019.889.3-711.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0004", CustomerName = "SUYANI", Ktp = "3578216705800002", Alamat = "NGESONG DUKUH KUPANG 1/25", AlamatSekarang = "NGESONG DUKUH KUPANG 1/25", Email = "YANI_TERRA@YAHOO.COM", Phone = "*081231502424", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0005", CustomerName = "SILVIA PUSPITA SETIAWATI", Ktp = "3571034803870002", Alamat = "JL LETJEND SUTOYO 67", AlamatSekarang = "JL LETJEND SUTOYO 67", Email = "", Phone = "081252097499", Npwp = "", KodePos = "64131" });
            TipeGl.Add(new ArCustomer { ShortName = "S0006", CustomerName = "STEPHEN EVERARDO KOESWANTO", Ktp = "3577031409950003", Alamat = "JL MANGGA NO 31 MADIUN", AlamatSekarang = "JL MANGGA NO 31 MADIUN", Email = "", Phone = "081330466771", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0007", CustomerName = "SRI INDRA MULYONO, SH", Ktp = "3515170207690002", Alamat = "GRIYA CANDRA MAS BLOK IH 09", AlamatSekarang = "GRIYA CANDRA MAS BLOK IH 09", Email = "DANUBRATA9090@GMAIL.COM", Phone = "081232030887", Npwp = "34.403.876.5-617.000", KodePos = "60258" });
            TipeGl.Add(new ArCustomer { ShortName = "S0008", CustomerName = "SUNARYADI AGUS HERNOWO DRS", Ktp = "3275100708660003", Alamat = "GRIYA ASRI CAMAR BLOK A NO 3", AlamatSekarang = "GEDUNG PROYEK PUNCAK CBD JL KRAMAT KALI WIYUNG", Email = "goesnar@gmail.com", Phone = "081357891965", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0009", CustomerName = "SUYANI,Ktp =3578216705800002", Alamat = "NGESONG DUKUH KUPANG I/25, RT 002, RW 006, KEL. DUKUH KUPANG, KEC. DUKUH PAKIS", AlamatSekarang = "NGESONG DUKUH KUPANG I/25", Email = "", Phone = "081231502424", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "S0010", CustomerName = "SUGENG HARIJANTO", Ktp = "3578312908700001", Alamat = "", AlamatSekarang = "JL. RAYA LONTAR 41Q/23", Email = "sugeng101070@yahoo.co.id", Phone = "08885216880", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0001", CustomerName = "TITUS TESA KATIANDA", Ktp = "3578182803930001", Alamat = "WISATA BUKIT MAS BLOK C3 NO-03 SURABAYA", AlamatSekarang = "WISATA BUKIT MAS BLOK C3 NO-03 SURABAYA", Email = "titustesa93 @gmail.com", Phone = "081216183344", Npwp = "82.550.008.5-604.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0002", CustomerName = "TRISNO HADINOTO", Ktp = "3578262001790002", Alamat = "WISMA PERMAI TENGAH 6/7", AlamatSekarang = "", Email = "", Phone = "", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0003", CustomerName = "THE GRAND STAND", Ktp = "3578262001790002", Alamat = "WISMA PERMAI TENGAH 6/7", AlamatSekarang = "WISMA PERMAI TENGAH 6/7", Email = "", Phone = "", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0004", CustomerName = "TAN GIOK HWA", Ktp = "", Alamat = "RAYA TANDES 30A", AlamatSekarang = "JL TAMAN PUSPA RAYA C-23", Email = "", Phone = "08981741579", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0005", CustomerName = "TETTY MARIA A.MD", Ktp = "357816810680002", Alamat = "ASEM JAJAR W/16 SURABAYA", AlamatSekarang = "ASEM JAJAR W/16 SURABAYA", Email = "", Phone = "085853461968", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0008", CustomerName = "TOMMY KODRATDJAYA", Ktp = "3578152303790001", Alamat = "PANTAI MENTARI BLOK DD-3/22, KENJERAN", AlamatSekarang = "PANTAI MENTARI BLOK DD-3/22, KENJERAN", Email = "TOMMY_KODRATDJAYA@YAHOO.COM", Phone = "081331879036", Npwp = "07.860.412.1-605.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "T0010", CustomerName = "TEGUH CIPTA WARDANA", Ktp = "3515182508730003", Alamat = "JAMBU VIII/59 PCI, RT 014, RW 005, KEL. TAMBAK SUMUR, KEC. WARU, KAB. SIDOARJO", AlamatSekarang = "PALEM TIMUR NO. 94, PONDOK TJANDRA", Email = "WARDANANEW@GMAIL.COM", Phone = "081233833585", Npwp = "68.523.170.6-643.000", KodePos = "61256" });
            TipeGl.Add(new ArCustomer { ShortName = "W0001", CustomerName = "WILIANTO", Ktp = "3578062912730005", Alamat = "BANYU URIP KIDUL 5/75, RT 002, RW 009, KEL. BANYU URIP, KEC. SAWAHAN", AlamatSekarang = "BANYU URIP KIDUL 5/75, RT 002, RW 009, KEL. BANYU URIP, KEC. SAWAHAN", Email = "", Phone = "08510019195 / 082230026944", Npwp = "24.898.898.2-643.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "Y0001", CustomerName = "Mr. Park Yeal Woo", Ktp = "CIGAA17531", Alamat = "Penanggungan RT 19 RW 4 Manduromanggunggajah Ngoro kab Mojokerto Jatim", AlamatSekarang = "Penanggungan RT 19 Rw 4 Manduromanggunggajah Ngoro kab mojokerto Jatim", Email = "", Phone = "", Npwp = "25.847.171.3-602.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "Y0002", CustomerName = "YOHANA YUTAWATI YUWONO", Ktp = "3578066005630007", Alamat = "PETEMON 1/7", AlamatSekarang = "RAYA DARMO PERMAI TIMUR 4/18 BLOK BC 5-6", Email = "ELIZAKY88@GMAIL.COM", Phone = "082231200084", Npwp = "09.752.525.7-614.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "Y0003", CustomerName = "YOSUA MARTIANSIA", Ktp = "3515082303970002", Alamat = "JL DR.CIPTO MANGKUSUMO - SDA", AlamatSekarang = "JL DR.CIPTO MANGKUSUMO - SDA", Email = "ELLENRATNA@HOTMAIL.COM", Phone = "081232125010", Npwp = "06.460.313.7-617.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "Y0004", CustomerName = "YOEL SETIA PERMAI", Ktp = "3578062007920002", Alamat = "KUPANG GUNUNG TIMUR 4/1", AlamatSekarang = "PASAR KUPANG F1(TOKO EMAS KRESNA )", Email = "YOELSETIAPERMAI@GMAIL.COM", Phone = "081236752682", Npwp = "76.872.309.0-614.000", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "Y0005", CustomerName = "YOHANES MARIO VIANNEY", Ktp = "3578021610910002", Alamat = "JL. SIDOSERMO VI NO.23 RT.003 / RW.003 SIDOSERMO, WONOCOLO", AlamatSekarang = "JL.SIDOSERMO VI NO.23 RT.003 / RW.003 SIDOSERMO, WONOCOLO", Email = "", Phone = "081234001958", Npwp = "", KodePos = "" });
            TipeGl.Add(new ArCustomer { ShortName = "Z0001", CustomerName = "ZAMRONI", Ktp = "3524050508690003", Alamat = "TESAN RT013 RW006 TRITUNGGAL ,BABAT", AlamatSekarang = "DARMO BARU TIMUR V/24 SURABAYA", Email = "zamronironi80 @yahoo.co.id", Phone = "081339305098", Npwp = "", KodePos = "60189" });


            var cekNull = (from e in db.ArCustomers select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.ArCustomers.Add(values);
                    db.SaveChanges();
                }


            }


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
