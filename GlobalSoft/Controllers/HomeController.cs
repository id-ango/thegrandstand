using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;


namespace GlobalSoft.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
           

            return View();
        }
        [Authorize(Roles ="Admin,Editor")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Skup()
        {

            return View();
        }
        public ActionResult TandaTerima()
        {

            return View();
        }

    }
}