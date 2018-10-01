using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;
using Newtonsoft.Json.Linq;

namespace GlobalSoft.Controllers
{
    public class FungsiController : Controller
    {


        public class Fungsi
        {
           

            public static DateTime HitungAngsuran(DateTime Tanggal, int Cicilan)
            {
                decimal bulan = Tanggal.Month;
                decimal hari = Tanggal.Day;
                decimal tahun = Tanggal.Year;
                decimal totHari = hari;

                decimal dbulan = (bulan + Cicilan);
                decimal totBulan = dbulan % 12;
                decimal totTahun = Math.Floor(dbulan / 12);

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

            public static string NumberToText(long n)
            {
                if (n < 0)
                    return "Minus " + NumberToText(-n);
                else if (n == 0)
                    return "";
                else if (n <= 19)
                    return new string[] {"Satu", "Dua", "Tiga", "Empat", "Lima", "Enam", "Tujuh", "Delapan",
                                "Sembilan", "Sepuluh", "Sebelas", "Duabelas", "Tigabelas", "Empatbelas", "Limabelas", "Enambelas",
                                "Tujuhbelas", "Delapanbelas", "Sembilanbelas"}[n - 1] + " ";
                else if (n <= 99)
                    return new string[] {"Duapuluh", "Tigapuluh", "Empatpuluh", "Limapuluh", "Enampuluh", "Tujuhpuluh",
                                "Delapanpuluh", "Sembilanpuluh"}[n / 10 - 2] + " " + NumberToText(n % 10);
                else if (n <= 199)
                    return "Seratus " + NumberToText(n % 100);
                else if (n <= 999)
                    return NumberToText(n / 100) + "Ratus " + NumberToText(n % 100);
                else if (n <= 1999)
                    return "Seribu " + NumberToText(n % 1000);
                else if (n <= 999999)
                    return NumberToText(n / 1000) + "Ribu " + NumberToText(n % 1000);
                else if (n <= 1999999)
                    return "Satu Juta " + NumberToText(n % 1000000);
                else if (n <= 999999999)
                    return NumberToText(n / 1000000) + "Juta " + NumberToText(n % 1000000);
                else if (n <= 1999999999)
                    return "Satu Milyard " + NumberToText(n % 1000000000);
                else
                    return NumberToText(n / 1000000000) + "Milyard " + NumberToText(n % 1000000000);
            }

           
        }
    }
}