using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalSoft.Controllers
{
    public class FungsiController : Controller
    {
       public class fungsi
        {
            public static DateTime HitungAngsuran(DateTime Tanggal, int Cicilan)
            {
                decimal bulan = Tanggal.Month;
                decimal hari = Tanggal.Day;
                decimal tahun = Tanggal.Year;
                decimal totHari = hari;

                decimal dbulan = (bulan + Cicilan);
                decimal totBulan = dbulan % 12;
                decimal totTahun = Math.Floor(dbulan / 12) ;

                if (totBulan == 0)
                {
                    totTahun = (totTahun != 0 ? totTahun - 1 : 0);
                    totBulan = 12;
                }

                bulan = totBulan;
                tahun = tahun + totTahun;

                if (hari == 31)
                {
                    if (bulan == 4 || bulan == 6 || bulan == 9 || bulan == 11)
                    {
                        hari = 30;
                    }
                    if (bulan == 2)
                    {
                        hari = (tahun % 4 == 0 ? 29 : 28);
                    }
                }
                if (hari >= 29 && bulan == 2)
                    hari = ((tahun % 4) == 0 ? 29 : 28);
                DateTime tglakhir = new DateTime((int)tahun, (int)bulan, (int)hari);

                return tglakhir;
            }
        }
       
    }
}