using GlobalSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalSoft.Controllers
{
    public class OrdersController : Controller
    {
        GlobalsoftDBContext db = new GlobalsoftDBContext();
        // GET: Orders
        public ActionResult Index()
        {
            List<Customer> OrderAndCustomerList = db.Customer.ToList();
            return View(OrderAndCustomerList);
        }

        public ActionResult SaveOrder(string name, String address, Orders[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (name != null && address != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                Customer model = new Customer();
                model.CustomerId = cutomerId;
                model.Name = name;
                model.Address = address;
                model.OrderDate = DateTime.Now;
                db.Customer.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    Orders O = new Orders();
                    O.OrderId = orderId;
                    O.ProductName = item.ProductName;
                    O.Quantity = item.Quantity;
                    O.Price = item.Price;
                    O.Amount = item.Amount;
                    O.CustomerId = cutomerId;
                    db.Orders.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}