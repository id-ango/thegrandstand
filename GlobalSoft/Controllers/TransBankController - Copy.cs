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
           
            ViewBag.BankID = new SelectList(db.CbBanks, "BankID", "BankName");
            ViewBag.TransNoID = new SelectList(db.AptTrsNoes, "TransNoID", "TransNo");
            List<CbTransH> OrderAndDetailList = db.CbTransHs.ToList();
            return View(OrderAndDetailList);
        }

        
        public ActionResult getBuktiOrder(string kodeNo)
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
            

            return Json(new { result = cNoref });
        }


        public ActionResult SaveOrder(string docno, String keterangan, CbTransD[] order)
        {
            string result = "Error! Order Is Not Complete!";
            if (docno != null && keterangan != null && order != null)
            {
                var cutomerId = Guid.NewGuid();
                CbTransH model = new CbTransH();
                model.GuidCb = cutomerId;
                model.Docno = docno;
                model.Keterangan = keterangan;
                model.Tanggal = DateTime.Now;
                db.CbTransHs.Add(model);

                foreach (var item in order)
                {
                    var orderId = Guid.NewGuid();
                    CbTransD O = new CbTransD();
                    O.GuidCb = cutomerId;
                    O.GuidDb = orderId;
                    O.TransNoID = 1;
                    O.Terima = item.Terima;
                    O.Bayar = item.Bayar;
                    O.Keterangan = item.Keterangan;
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
                            masterId = x.GuidCb,
                            Docno = x.Docno,
                            Deskripsi = x.Keterangan,
                            Bank =  db.CbBanks.Where( y => y.BankID == x.BankID).Select(y => y.BankName).FirstOrDefault()  ,
                            Tanggal = x.Tanggal.ToString(),
                            Jumlah = x.Saldo
                        })).ToList();

//            Bank = (x.Bank1.BankName == null) ? "kosong" : x.Bank1.BankName,

            return Json(new
            {
                draw = draw,
                recordsFiltered = model.Count,
                recordsTotal = model.Count,
                data = model
            }, JsonRequestBehavior.AllowGet);
        }

        //        public ActionResult SaveOrder(string DocNo, String Deskripsi, CbTransD[] order)
        //        public ActionResult saveOrder(OrderViewModel order)
        //                Docno = order.DocNo,
        //               Keterangan = order.Deskripsi,
        //               Tanggal =  DateTime.Parse(order.Tanggal),
        //               BankID = int.Parse(order.Bank)
//        public ActionResult saveOrder(string DocNo, string Deskripsi, string Tanggal, String Bank, OrderDetailsViewModel[] order)

//        [HttpPost]
        public ActionResult saveOrder(OrderViewModel order)
        {
            var masterId = Guid.NewGuid();
            var orderMaster = new CbTransH()
            {
                GuidCb = masterId,
                Docno = order.DocNo,
                Keterangan = order.Deskripsi,
                Tanggal = DateTime.Parse(order.Tanggal),
                BankID = int.Parse(order.Bank)

            };
            db.CbTransHs.Add(orderMaster);
            //Process Order details
            
            if (order.OrderDetails.Any())
            {
                var ty = order.OrderDetails.Count();

                

                foreach (var item in order.OrderDetails)
                {
                    var detailId = Guid.NewGuid();
                    var orderDetails = new CbTransD()
                    {
                        GuidDb = detailId,
                        GuidCb = masterId,
                        TransNoID = 1,
                        Terima = decimal.Parse(item.Terima),
                        Keterangan = item.Keterangan,
                        Bayar = decimal.Parse(item.Bayar)
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
                return Json(new { error = true, message = "Ada Yang salah" });
//                return Json(new { error = true, message = ex.Message });
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
                             DocNo = ord.Docno,
                             Tanggal = ord.Tanggal.ToString(),
                             Deskripsi = ord.Keterangan,
                             Bank = Convert.ToString(ord.BankID),
                             Jumlah = ord.Saldo.ToString()
                         }).SingleOrDefault();

            if (model != null)
            {
                model.OrderDetails = (from od in db.CbTransDs
                                      where od.GuidCb == model.MasterId
                                      select new OrderDetailsViewModel()
                                      {
                                          DetailId = od.GuidCb,
                                          Terima = od.Terima.ToString(),
                                          Keterangan = od.Keterangan,
                                          Source = Convert.ToString(od.TransNoID),
                                          Bayar = od.Bayar.ToString()
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
                                   Source = Convert.ToString(od.TransNoID),
                                   Terima = od.Terima.ToString(),
                                   Keterangan = od.Keterangan,
                                   Bayar = od.Bayar.ToString()
                               }).SingleOrDefault();

            return Json(new { result = orderDetail }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult updateOrder(Guid orderId)
        {
            return null;
        }
    }
}


