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
    public class SetupGlAccountsController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupGlAccounts
        public ActionResult Index()
        {
            

            List<GlAccount> TipeGl = new List<GlAccount>();
            TipeGl.Add(new GlAccount { GlAkun = "1101.01", GlAkunName = "Kas Kantor" });
            TipeGl.Add(new GlAccount { GlAkun = "1101.02", GlAkunName = "Kas Proyek" });
            TipeGl.Add(new GlAccount { GlAkun = "1101.03", GlAkunName = "Kas Foodcourt" });
            TipeGl.Add(new GlAccount { GlAkun = "1102.01", GlAkunName = "Bank Central Asia" });
            TipeGl.Add(new GlAccount { GlAkun = "1102.02", GlAkunName = "Bank Tabungan Negara" });
            TipeGl.Add(new GlAccount { GlAkun = "1102.03", GlAkunName = "CIMB " });
            TipeGl.Add(new GlAccount { GlAkun = "1102.04", GlAkunName = "CIMB Payroll " });
            TipeGl.Add(new GlAccount { GlAkun = "1102.05", GlAkunName = "Mandiri Giro" });
            TipeGl.Add(new GlAccount { GlAkun = "1102.06", GlAkunName = "Mandiri Tab" });
            TipeGl.Add(new GlAccount { GlAkun = "1102.07", GlAkunName = "MayBank" });
            TipeGl.Add(new GlAccount { GlAkun = "1102.99", GlAkunName = "Kas/Bank Clearing" });
            TipeGl.Add(new GlAccount { GlAkun = "1103.01", GlAkunName = "Piutang Usaha" });
            TipeGl.Add(new GlAccount { GlAkun = "1104.01", GlAkunName = "Piutang Lain-Lain" });
            TipeGl.Add(new GlAccount { GlAkun = "1104.02", GlAkunName = "Piutang Karyawan" });
            TipeGl.Add(new GlAccount { GlAkun = "1104.03", GlAkunName = "Piutang Pihak Ketiga" });
            TipeGl.Add(new GlAccount { GlAkun = "1104.99", GlAkunName = "Receivable Clearing" });
            TipeGl.Add(new GlAccount { GlAkun = "1105.01", GlAkunName = "Biaya Dibayar Dimuka" });
            TipeGl.Add(new GlAccount { GlAkun = "1105.02", GlAkunName = "Asuransi Dibayar Dimuka" });
            TipeGl.Add(new GlAccount { GlAkun = "1106.01", GlAkunName = "PPN Masukan" });
            TipeGl.Add(new GlAccount { GlAkun = "1106.02", GlAkunName = "Pph 25/29" });
            TipeGl.Add(new GlAccount { GlAkun = "1106.03", GlAkunName = "Pph 21" });
            TipeGl.Add(new GlAccount { GlAkun = "1106.04", GlAkunName = "Pph 23" });
            TipeGl.Add(new GlAccount { GlAkun = "1106.05", GlAkunName = "Pph 4 (2)" });
            TipeGl.Add(new GlAccount { GlAkun = "1107.01", GlAkunName = "Piutang Pemegang Saham" });
            TipeGl.Add(new GlAccount { GlAkun = "1107.02", GlAkunName = "Piutang Hubungan Istimewa" });
            TipeGl.Add(new GlAccount { GlAkun = "1201.01", GlAkunName = "Kompensasi Lahan" });
            TipeGl.Add(new GlAccount { GlAkun = "1201.02", GlAkunName = "Perolehan Tanah" });
            TipeGl.Add(new GlAccount { GlAkun = "1201.03", GlAkunName = "Biaya-Biaya Pengembangan Tanah" });
            TipeGl.Add(new GlAccount { GlAkun = "1201.04", GlAkunName = "Biaya Ganti Rugi Warga" });
            TipeGl.Add(new GlAccount { GlAkun = "1202.01", GlAkunName = "Keamanan/Pengawasan Lingkungan" });
            TipeGl.Add(new GlAccount { GlAkun = "1202.02", GlAkunName = "Pengukuran Lahan dan Test Pile" });
            TipeGl.Add(new GlAccount { GlAkun = "1202.03", GlAkunName = "Biaya Operasional Persediaan Tanah" });
            TipeGl.Add(new GlAccount { GlAkun = "1202.04", GlAkunName = "Contigencies (Lain-Lain)" });
            TipeGl.Add(new GlAccount { GlAkun = "1202.05", GlAkunName = "Persediaan Lain-Lain" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.01", GlAkunName = "Konsultan Perencana (Skematik)" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.02", GlAkunName = "Konsultan Perencana (Detail Design)" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.03", GlAkunName = "Konsultan Mekanikal Dan Elektrikal" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.04", GlAkunName = "Konsultan Sipil" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.05", GlAkunName = "Konsultan Interior" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.06", GlAkunName = "Konsultan Surveyor" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.07", GlAkunName = "Konsultan Pengawas" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.08", GlAkunName = "Konsultan Feasibility Study" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.09", GlAkunName = "License dan Permit (Perijinan)" });
            TipeGl.Add(new GlAccount { GlAkun = "1203.1", GlAkunName = "Notaris" });
            TipeGl.Add(new GlAccount { GlAkun = "1204.01", GlAkunName = "Pondasi" });
            TipeGl.Add(new GlAccount { GlAkun = "1205.01", GlAkunName = "Struktural" });
            TipeGl.Add(new GlAccount { GlAkun = "1206.01", GlAkunName = "Mekanikal" });
            TipeGl.Add(new GlAccount { GlAkun = "1207.01", GlAkunName = "Arsitektural" });
            TipeGl.Add(new GlAccount { GlAkun = "1208.01", GlAkunName = "Perijinan" });
            TipeGl.Add(new GlAccount { GlAkun = "1209.01", GlAkunName = "Tanah" });
            TipeGl.Add(new GlAccount { GlAkun = "1209.02", GlAkunName = "Bangunan" });
            TipeGl.Add(new GlAccount { GlAkun = "1209.03", GlAkunName = "Mesin dan Perlengkapan" });
            TipeGl.Add(new GlAccount { GlAkun = "1209.04", GlAkunName = "Inventaris Kantor" });
            TipeGl.Add(new GlAccount { GlAkun = "1209.05", GlAkunName = "Kendaraan" });
            TipeGl.Add(new GlAccount { GlAkun = "1209.06", GlAkunName = "Aktiva Tetap Lain-Lain" });
            TipeGl.Add(new GlAccount { GlAkun = "1210.01", GlAkunName = "Penyusutan Bangunan" });
            TipeGl.Add(new GlAccount { GlAkun = "1210.02", GlAkunName = "Penyusutan Mesin dan Perlengkapan" });
            TipeGl.Add(new GlAccount { GlAkun = "1210.03", GlAkunName = "Penyusutan Inventaris" });
            TipeGl.Add(new GlAccount { GlAkun = "1210.04", GlAkunName = "Penyusutan Kendaraan" });
            TipeGl.Add(new GlAccount { GlAkun = "1210.05", GlAkunName = "Penyusutan Aktiva Tetap Lainnya" });
            TipeGl.Add(new GlAccount { GlAkun = "2101.01", GlAkunName = "Hutang Usaha" });
            TipeGl.Add(new GlAccount { GlAkun = "2102.01", GlAkunName = "Hutang Lain-Lain" });
            TipeGl.Add(new GlAccount { GlAkun = "2102.02", GlAkunName = "Pemegang Saham" });
            TipeGl.Add(new GlAccount { GlAkun = "2102.03", GlAkunName = "Pihak Ketiga" });
            TipeGl.Add(new GlAccount { GlAkun = "2102.99", GlAkunName = "Payable Clearing" });
            TipeGl.Add(new GlAccount { GlAkun = "2103.01", GlAkunName = "PPN Keluaran" });
            TipeGl.Add(new GlAccount { GlAkun = "2103.02", GlAkunName = "Pph 25/29" });
            TipeGl.Add(new GlAccount { GlAkun = "2103.03", GlAkunName = "Pph 21" });
            TipeGl.Add(new GlAccount { GlAkun = "2103.04", GlAkunName = "Pph 23" });
            TipeGl.Add(new GlAccount { GlAkun = "2103.05", GlAkunName = "Pph 4 (2)" });
            TipeGl.Add(new GlAccount { GlAkun = "2104.01", GlAkunName = "Beban Penjualan" });
            TipeGl.Add(new GlAccount { GlAkun = "2104.02", GlAkunName = "Beban Administrasi dan Umum" });
            TipeGl.Add(new GlAccount { GlAkun = "2105.01", GlAkunName = "Pendapatan Diterima Dimuka" });
            TipeGl.Add(new GlAccount { GlAkun = "2106.01", GlAkunName = "Kewajiban Pasca Kerja" });
            TipeGl.Add(new GlAccount { GlAkun = "3101.01", GlAkunName = "Modal Disetor Chandra Santoso" });
            TipeGl.Add(new GlAccount { GlAkun = "3101.99", GlAkunName = "Balancing Account" });
            TipeGl.Add(new GlAccount { GlAkun = "3201.01", GlAkunName = "Laba (Defisit) Ditahan" });
            TipeGl.Add(new GlAccount { GlAkun = "3201.02", GlAkunName = "Laba (Defisit) Tahun Berjalan" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.01", GlAkunName = "Penjualan Emerald A" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.02", GlAkunName = "Penjualan Emerald B" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.03", GlAkunName = "Penjualan Emerald C" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.04", GlAkunName = "Penjualan Emerald D" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.05", GlAkunName = "Penjualan Emerald E" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.06", GlAkunName = "Penjualan Emerald F" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.07", GlAkunName = "Penjualan Emerald G" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.08", GlAkunName = "Penjualan Emerald H" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.09", GlAkunName = "Penjualan Emerald I" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.10", GlAkunName = "Penjualan Sapphire A" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.11", GlAkunName = "Penjualan Sapphire B" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.12", GlAkunName = "Penjualan Sapphire C" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.13", GlAkunName = "Penjualan Sapphire D" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.14", GlAkunName = "Penjualan Sapphire E" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.15", GlAkunName = "Penjualan Diamond A" });
            TipeGl.Add(new GlAccount { GlAkun = "4101.16", GlAkunName = "Penjualan Diamond B" });
            TipeGl.Add(new GlAccount { GlAkun = "4201.01", GlAkunName = "Bonus - Priority Pass" });
            TipeGl.Add(new GlAccount { GlAkun = "4251.01", GlAkunName = "Pembayaran Diskon" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.01", GlAkunName = "HPP Emerald A" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.02", GlAkunName = "HPP Emerald B" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.03", GlAkunName = "HPP Emerald C" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.04", GlAkunName = "HPP Emerald D" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.05", GlAkunName = "HPP Emerald E" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.06", GlAkunName = "HPP Emerald F" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.07", GlAkunName = "HPP Emerald G" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.08", GlAkunName = "HPP Emerald H" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.09", GlAkunName = "HPP Emerald I" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.10", GlAkunName = "HPP Sapphire A" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.11", GlAkunName = "HPP Sapphire B" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.12", GlAkunName = "HPP Sapphire C" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.13", GlAkunName = "HPP Sapphire D" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.14", GlAkunName = "HPP Sapphire E" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.15", GlAkunName = "HPP Diamond A" });
            TipeGl.Add(new GlAccount { GlAkun = "5101.16", GlAkunName = "HPP Diamond B" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.01", GlAkunName = "MKT-Flyer, Brosur" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.02", GlAkunName = "MKT-Billboard" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.03", GlAkunName = "MKT-Radio-TV" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.04", GlAkunName = "MKT-Koran" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.05", GlAkunName = "MKT-Cash Back" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.06", GlAkunName = "MKT-Hadiah Penjualan" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.07", GlAkunName = "MKT-Komisi Penjualan" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.08", GlAkunName = "MKT-Furnish" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.09", GlAkunName = "MKT-BLT" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.10", GlAkunName = "MKT-Telekomunikasi & Internet" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.11", GlAkunName = "MKT-Listrik" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.12", GlAkunName = "MKT-Air" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.13", GlAkunName = "MKT-Sewa/Pameran/Gathering" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.14", GlAkunName = "MKT-Booth Pameran" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.15", GlAkunName = "MKT-Operasional Pameran" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.16", GlAkunName = "MKT-Topping Off" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.17", GlAkunName = "MKT-Entertainment" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.18", GlAkunName = "MKT-Gaji Staff dan Karyawan" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.19", GlAkunName = "MKT-Konsultan dan Jasa Lainnya" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.20", GlAkunName = "MKT-Perjalanan Dinas dan Transportasi" });
            TipeGl.Add(new GlAccount { GlAkun = "6101.21", GlAkunName = "MKT-Pemasaran Proyek" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.01", GlAkunName = "A&G-Beban Gaji & Tunjangan" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.02", GlAkunName = "A&G-Perjalanan Dinas dan Transportasi" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.03", GlAkunName = "A&G-Perbaikan dan Pemeliharaan" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.04", GlAkunName = "A&G-Sumbangan dan Jamuan" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.05", GlAkunName = "A&G-Biaya Alat Tulis Kantor, Dll" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.06", GlAkunName = "A&G-Biaya Telekomunikasi dan Internet" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.07", GlAkunName = "A&G-Biaya Listrik" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.08", GlAkunName = "A&G-Biaya Air" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.09", GlAkunName = "A&G-Biaya Lain-Lain Kantor" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.10", GlAkunName = "A&G-Biaya Adm & Umum Lainnya" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.11", GlAkunName = "A&G-Makanan & Minuman" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.12", GlAkunName = "A&G-Konsultan dan Jasa Lainnya" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.13", GlAkunName = "A&G-Biaya JAMSOSTEK" });
            TipeGl.Add(new GlAccount { GlAkun = "6201.14", GlAkunName = "A&G-Penyusutan" });
            TipeGl.Add(new GlAccount { GlAkun = "7101.01", GlAkunName = "Penghasilan Bunga" });
            TipeGl.Add(new GlAccount { GlAkun = "7101.02", GlAkunName = "Pendapatan Lain-Lain Non Operasional" });
            TipeGl.Add(new GlAccount { GlAkun = "7101.99", GlAkunName = "Pendapatan Pembulatan" });
            TipeGl.Add(new GlAccount { GlAkun = "8101.01", GlAkunName = "Beban Bunga" });
            TipeGl.Add(new GlAccount { GlAkun = "8101.02", GlAkunName = "Beban Administrasi Bank/Provisi Bank" });
            TipeGl.Add(new GlAccount { GlAkun = "8101.03", GlAkunName = "Beban Lain-Lain Non Operasional" });

            var cekNull = (from e in db.GlAccounts select e).Count();
            if (cekNull == 0)
            {


                foreach (var values in TipeGl)
                {
                    db.GlAccounts.Add(values);
                    db.SaveChanges();
                }


            }

            var glAccounts = db.GlAccounts.ToList();

            var ListAkun = (from e in glAccounts
                           select new TrsnoVM 
                           {
                               GlAkunID  = e.GlAkunID,
                               GlAkun  = e.GlAkun,
                               GlAkunName = e.GlAkunName,
                               TransNoID = e.GlTipeID,
                               TransNo = db.GlTipes.Where(n => n.GlTipeID == e.GlTipeID).Select(n => n.GlTipeName).DefaultIfEmpty("").First()
                           }).ToList();



            return View(ListAkun);
           
        }

        // GET: SetupGlAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlAccount glAccount = db.GlAccounts.Find(id);
            if (glAccount == null)
            {
                return HttpNotFound();
            }
            return View(glAccount);
        }

        // GET: SetupGlAccounts/Create
        public ActionResult Create()
        {
            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName");
            return View();
        }

        // POST: SetupGlAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlAkunID,GlAkun,GlAkun2,GlAkunName,GlTipeID")] GlAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                db.GlAccounts.Add(glAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName", glAccount.GlTipeID);
            return View(glAccount);
        }

        // GET: SetupGlAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlAccount glAccount = db.GlAccounts.Find(id);
            if (glAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName", glAccount.GlTipeID);
            return View(glAccount);
        }

        // POST: SetupGlAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlAkunID,GlAkun,GlAkun2,GlAkunName,GlTipeID")] GlAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GlTipeID = new SelectList(db.GlTipes, "GlTipeID", "GlTipeName", glAccount.GlTipeID);
            return View(glAccount);
        }

        // GET: SetupGlAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlAccount glAccount = db.GlAccounts.Find(id);
            if (glAccount == null)
            {
                return HttpNotFound();
            }
            return View(glAccount);
        }

        // POST: SetupGlAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlAccount glAccount = db.GlAccounts.Find(id);
            db.GlAccounts.Remove(glAccount);
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
