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
    public class DashBoardController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: DashBoard
        public ActionResult DsbUnit(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "kategori_desc" : "";
            ViewBag.AddressSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";

            var aptUnits = db.AptUnits.Include(a => a.AptCategorie).Include(a => a.AptStatus);
            if (!String.IsNullOrEmpty(searchString))
            {
                aptUnits = aptUnits.Where(s => s.AptCategorie.Categorie.Contains(searchString)
                || s.AptStatus.Status.Contains(searchString)
                || s.UnitNo.Contains(searchString));
                
            }
            switch (sortOrder)
            {
                case "kategori_desc":
                    aptUnits = aptUnits.OrderByDescending(s => s.AptCategorie.Categorie);
                    break;
                case "status_desc":
                    aptUnits = aptUnits.OrderBy(s => s.AptStatus.Status);
                    break;
                default:
                    aptUnits = aptUnits.OrderBy(s => s.UnitNo);
                    break;
            }


            return View(aptUnits.ToList());


        }

        
    }
}