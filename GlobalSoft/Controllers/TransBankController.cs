using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;
using Newtonsoft.Json.Linq;

namespace GlobalSoft.Controllers
{
    public class TransBankController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();
        // GET: TransBank
        public ActionResult Index()
        {
            var aptTranss2 = db.CbTransHs.Include(a =>a.Bank1).Include( a =>a.Bank2);
            
            return View(aptTranss2.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            ViewBag.TransNoID = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            return View();
        }
        [HttpPost]
        public ActionResult Create(string kodeNo)
        {
            // var maxvalue = db.AptTranss.Max(x =>  x.NoRef.Substring(0, 10));

            string thnbln = DateTime.Now.ToString("yyMM");
            var maxvalue = (from e in db.CbTransHs where e.Docno.Substring(0, 7) == kodeNo + thnbln select e).FirstOrDefault();
            string nourut = "000";
            if (maxvalue == null)
            {
                nourut = "000";
            }
            else
            {
                nourut = maxvalue.Docno.Substring(7, 3);
            }

            //  nourut =Convert.ToString(Int32.Parse(nourut) + 1);


            string cAngNo = kodeNo + thnbln + (Int32.Parse(nourut) + 1).ToString("000");
            // var maxvalue = (from e in db.AptTranss where e.NoRef.Substring(0, 7) == "ANG" + cAngNo select e.NoRef.Max()).FirstOrDefault();
            string cNoref = cAngNo;
            ViewBag.NoRef = cNoref;

            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            ViewBag.TransNoID = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            return View();
        }

        public ActionResult SaveOrder(string DocNo, String Keterangan,  CbTransD[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (DocNo != null && Keterangan != null && order != null)
            {
                var GudId = Guid.NewGuid();

                CbTransH model = new CbTransH
                {
                    GuidCb = GudId,
                    Docno = DocNo,
                    Keterangan = Keterangan,
                    Tanggal = DateTime.Now
                };
                db.CbTransHs.Add(model);

                foreach (var item in order)
                {

                    CbTransD O = new CbTransD
                    {
                        TransNoID = 1,
                        Keterangan = item.Keterangan,
                        Terima = item.Terima,
                        Bayar = item.Bayar,
                        GuidCb = GudId,
                        Tanggal = DateTime.Now
                        
                    };
                    db.CbTransDs.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getOrders()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var model = (db.CbTransHs.ToList()
                        .Select(x => new
                        {
                            TranshID = x.TranshID,
                            DocNo = x.Docno,
                            BankName = x.Bank1.BankName,
                            Keterangan = x.Keterangan,
                            Jumlah = x.Saldo,
                            Tanggal = x.Tanggal.ToString("D")
                        })).ToList();

            return Json(new
            {
                draw = draw,
                recordsFiltered = model.Count,
                recordsTotal = model.Count,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult saveOrder(OrderViewModel order)
        {
            var masterId = Guid.NewGuid();
            var orderMaster = new CbTransH()
            {
                GuidCb = masterId,
                Docno = order.CustomerName,
                Keterangan = order.Address,
                Tanggal = DateTime.Now
            };
            db.CbTransHs.Add(orderMaster);
            //Process Order details

            if (order.OrderDetails.Any())
            {
                foreach (var item in order.OrderDetails)
                {
                   // var detailId = Guid.NewGuid();
                    var orderDetails = new CbTransD()
                    {
                       
                        GuidCb = masterId,
                        Terima = decimal.Parse(item.Amount),
                        Keterangan = item.ProductName,
                        Bayar = int.Parse(item.Quantity)
                    };

                    db.CbTransDs.Add(orderDetails);

                }
            }

            try
            {
                if (db.SaveChanges() > 0)
                {
                    return Json(new { error = false, message = "Order saved successfully" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message });
            }

            return Json(new { error = true, message = "An unknown error has occured" });
        }
        public ActionResult getSingleOrder(Guid orderId)
        {
            var model = (from ord in db.CbTransHs
                         where ord.GuidCb == orderId
                         select new OrderViewModel()
                         {
                             MasterId = ord.GuidCb,
                             CustomerName = ord.Docno,
                             Address = ord.Keterangan
                         }).SingleOrDefault();

            if (model != null)
            {
                model.OrderDetails = (from od in db.CbTransDs
                                      where od.GuidCb == model.MasterId
                                      select new OrderDetailsViewModel()
                                      {
                                          DetailId = od.GuidCb,
                                          Amount = od.Terima.ToString(),
                                          ProductName = od.Keterangan,
                                          Quantity = od.Bayar.ToString()
                                      }).ToList();
            }

            return Json(new { result = model }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteOrderItem(Guid id)
        {
            var order = db.CbTransDs.Find(id);
            if (null != order)
            {
                db.CbTransDs.Remove(order);
                db.SaveChanges();
                return Json(new { error = false });
            }
            return Json(new { error = true });
        }
        public ActionResult getSingleOrderDetail(Guid id)
        {
            var orderDetail = (from od in db.CbTransDs
                               where od.GuidCb == id
                               select new OrderDetailsViewModel()
                               {
                                   DetailId = od.GuidCb,
                                   Amount = od.Terima.ToString(),
                                   ProductName = od.Keterangan,
                                   Quantity = od.Bayar.ToString()
                               }).SingleOrDefault();

            return Json(new { result = orderDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult updateOrder(Guid orderId)
        {
            return null;
        }
    }
}


