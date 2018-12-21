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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GlobalSoft.Controllers
{
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class AptSPesanansController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        public string LoadRecords()
        {
            string filter = RequestQueryString();

            IEnumerable<AptSPesanan> records = db.AptSPesanans.ToList();
             //   .SqlQuery("SELECT * FROM AptSPesanans " + filter);

            var jsonData = JsonConvert.SerializeObject(records);
            return jsonData;
        }

        protected string RequestQueryString(string query = "", string defaultorder = "SPesananID")
        {
            string filter = query;
            var req = Request.Form["request"];
            if (req == null) { return filter; }

            JObject r = JObject.Parse(req);
            int limit = (int)r["limit"];
            int offset = (int)r["offset"];

            JArray search = (JArray)r["search"]; // field + type + operator + value
            if (search != null)
            {
                string SearchLogic = (string)r["searchLogic"];
                foreach (JObject o in search.Children<JObject>())
                {
                    if (filter == query)
                        filter += (query == "" ? "WHERE (" : " AND (") + " (" + SearchFilter(o) + ") ";
                    else
                        filter += SearchLogic + " (" + SearchFilter(o) + ") ";
                }
                filter += ")";
            }

            JArray sort = (JArray)r["sort"];
            filter += SortFilter(sort, defaultorder);

            return filter + " OFFSET " + offset +
              " ROWS FETCH NEXT " + limit + " ROWS ONLY";
        }

        protected string SearchFilter(JObject o)
        {
            string field = (string)o["field"];
            string opt = (string)o["operator"]; //'is', 'between', 'begins with', 'contains', 'ends with'

            string val = (opt != "between" ? (string)o["value"] : "");

            switch (opt)
            {
                case "is":
                    val = FormatDate(val);
                    return (field + " = '" + val + "'");
                case "begins":
                    return (field + " LIKE '" + val + "%'");
                case "contains":
                    return (field + " LIKE '%" + val + "%'");
                case "ends":
                    return (field + " LIKE '%" + val + "'");
                case "before":
                case "less":
                    return (field + " < '" + FormatDate(val) + "'");
                case "after":
                case "more":
                    return (field + " > '" + FormatDate(val) + "'");
                case "between":
                    string d1 = FormatDate((string)o["value"][0]);
                    string d2 = FormatDate((string)o["value"][1]);
                    return (field + " BETWEEN '" + d1 + "' AND '" + d2 + "'");
                default: return "";
            }
        }

        protected string SortFilter(JArray sort, string defaultorder)
        {
            if (sort == null)
                return " ORDER BY " + defaultorder;

            string ssql = "";
            foreach (JObject o in sort.Children<JObject>())
            {
                string field = (string)o["field"];
                string order = (string)o["direction"];
                ssql += (ssql == "" ? " ORDER BY " : ", ");
                ssql += field + (order == "asc" ? " ASC" : " DESC");
            }
            return ssql;
        }

        private string FormatDate(string input)
        {
            DateTime d;
            if (DateTime.TryParseExact(input, "dd-MM-yyyy",
                  CultureInfo.InvariantCulture,
                  DateTimeStyles.None, out d))
            {
                return d.ToString("yyyy-MM-dd");
            }
            return input;
        }

        // GET: AptSPesanans
        public ActionResult Index()
        {
            return View(db.AptSPesanans.ToList());
        }

        // GET: AptSPesanans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            if (aptSPesanan == null)
            {
                return HttpNotFound();
            }
            return View(aptSPesanan);
        }

        // GET: AptSPesanans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AptSPesanans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SPesananID,SPesanan,Tanggal,Duedate,KodeTrans,LPB,Keterangan,KetBayar,Jumlah,Bayar,Sisa,SldSisa,Diskon")] AptSPesanan aptSPesanan)
        {
            if (ModelState.IsValid)
            {
                db.AptSPesanans.Add(aptSPesanan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aptSPesanan);
        }

        // GET: AptSPesanans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            if (aptSPesanan == null)
            {
                return HttpNotFound();
            }
            return View(aptSPesanan);
        }

        // POST: AptSPesanans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SPesananID,SPesanan,Tanggal,Duedate,KodeTrans,LPB,Keterangan,KetBayar,Jumlah,Bayar,Sisa,SldSisa,Diskon")] AptSPesanan aptSPesanan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aptSPesanan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aptSPesanan);
        }

        // GET: AptSPesanans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            if (aptSPesanan == null)
            {
                return HttpNotFound();
            }
            return View(aptSPesanan);
        }

        // POST: AptSPesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AptSPesanan aptSPesanan = db.AptSPesanans.Find(id);
            db.AptSPesanans.Remove(aptSPesanan);
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
