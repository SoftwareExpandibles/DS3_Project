using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using  Data;
using Data.Models;
using Models;
using  Services;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Rangamo.Controllers
{
    public class CartController : Controller
    {
        private IRangamoRepository _rangamoRepository;
        ApplicationDbContext db = new ApplicationDbContext();

         public CartController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
         public byte[] GetImageFromDataBase(int id)
         {
             byte[] cover;
             var repo =_rangamoRepository.GetAllProducts().ToList();
             var q = from temp in repo where temp.ProductId == id select temp.Photo;
             cover = q.First();
             return cover;
         }

         public ActionResult RetrieveImage(int id)
         {
             byte[] cover = GetImageFromDataBase(id);
             if (cover != null)
             {
                 return File(cover, "image/jpg");
             }
             else
             {
                 return null;
             }
         }
        //[Authorize]
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var product = _rangamoRepository.GetAllProducts();
            return new RazorPDF.PdfResult(product,"Index");
        }
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Buy(int id)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
           List<Product> pp=_rangamoRepository.GetAllProducts().ToList();
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExisting(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                if (index == -1)
                {
                    cart.Add(new Item { ItemId = (cart.Count + 1), Product =pp.Find(P=>P.ProductId==id), Quantity = 1 });
                }
            }

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { ItemId = 1, Product=pp.Find(P=>P.ProductId==id), Quantity = 1 });
                Session["cart"] = cart;
            }
            
            return View("cart");
        }
        public ActionResult CheckOut()
        {
            if (Session["cart"] != null)
            {
                List<Item> cart = (List<Item>)Session["cart"];
                try
                {
                    Order ooo = new Order();
                    ooo.CartItems = cart;
                    ooo.OrderDate = DateTime.Now;
                    ooo.OrderID = _rangamoRepository.GetAllOrders().Count() + 1;
                    ooo.AdditionalCost = 0;
                    ooo.Username = User.Identity.Name;
                    foreach (Item decs in cart)
                    {
                        ooo.SubTotal += decs.Quantity * decs.Product.Price;
                    }
                    ooo.Vat = ooo.SubTotal * (Convert.ToDecimal(0.14));
                    ooo.Total = ooo.Vat + ooo.SubTotal;
                    List<Order> results = _rangamoRepository.GetAllOrders().ToList().FindAll(p => p.OrderTitle.Contains(ooo.Username + "_OrderNo"));
                    if (results.Count==0)
                    {
                        ooo.OrderTitle=ooo.Username+"_OrderNo"+1;
                    }
                    if (results.Count>0)
                    {
                        ooo.OrderTitle=ooo.Username+"_OrderNo"+(results.Count()+1).ToString();
                    }
                    _rangamoRepository.CreateOrder(ooo);
                    _rangamoRepository.Save();
                    Session["order"] = ooo;
                    return View("CheckOut");
                }
                catch (Exception e)
                {

                    return Content(e.Message);
                }
            }
            return Content("Failed" + "<br/>" + "You Failed");
        }
        public ActionResult Shipping()
        {
            if (Session["order"] != null)
            {
                Order ooo = (Order)Session["order"];
              Order currentOrder=_rangamoRepository.ReadOrder(ooo.OrderID);
              return View();
            }
            return Content("Unsuccessful order does not exist");
            
        }
        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = BisExisting(id);
            cart.RemoveAt(index);
            if (cart.Count == 0)
            {
                cart = null;
            }
            Session["cart"] = cart;
            return View("cart");
        }
        public int BisExisting(int id)
        {
            List<Item> cart =(List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId == id)
                    return i;
            return -1;
        }
       
        
        
}
}
        //public ActionResult Successful()
        //{
        //    int syaOrders = 0;
        //    foreach (Order orders in _rangamoRepository.GetAllOrders())
        //    {
        //        if (orders.OrderTitle.Contains("Sya"))
        //        {
        //            syaOrders += 1;
        //        }
        //    }
        //    ViewBag.LatestOrder = _rangamoRepository.GetAllOrders().ToString().Contains("Sya" + syaOrders.ToString());
        //    return View();
        //    if(ViewBag.LatestOrder!=null)
        //    {
        //        OrderStatus ac = new OrderStatus();
        //        Order thisOrder = ViewBag.LatestOrder;
        //        ac.OrderID = thisOrder.OrderID;
        //    }
        //}
        //public ActionResult Shipping()
        //{

        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CheckOut([Bind(Include = "DeliveryTitle,PickUpDate,Status")] DeliveryOption deliveryoption)
        //{
        //    decimal sum=0;
        //    int EndOfMonth = 0;
        //    deliveryoption.DeliveryTitle = "Pick Up Onsite";
        //    if (ModelState.IsValid)
        //    {
        //        if (deliveryoption.Status == true)
        //        {
        //            List<Item> carty = (List<Item>)this.Session["cart"];
        //            if (deliveryoption.PickUpDate.Month == DateTime.Now.Month)
        //            {
        //                decimal subsum = 0;
        //                subsum += (deliveryoption.PickUpDate.Day - DateTime.Now.Date.Day) * carty[0].Product.Price;
        //                //shouldnt be  here
        //                if (subsum < 0)
        //                {
        //                    subsum *= -1;
        //                    sum = 0;
        //                }
        //                //same day
        //                if (subsum == 0)
        //                {
        //                    sum += 350;
        //                }
        //                //not same date
        //                if (subsum > 0)
        //                {
        //                    //3 days R300
        //                    if (deliveryoption.PickUpDate.Day - DateTime.Now.Date.Day > 1 && deliveryoption.PickUpDate.Day - DateTime.Now.Date.Day < 5)
        //                    {
        //                        sum += 300;
        //                    }
        //                    //5 days R260
        //                    if (deliveryoption.PickUpDate.Day - DateTime.Now.Date.Day > 4 && deliveryoption.PickUpDate.Day - DateTime.Now.Date.Day < 7)
        //                    {
        //                        sum += 260;
        //                    }
        //                    //7 days R200
        //                    if (deliveryoption.PickUpDate.Day - DateTime.Now.Date.Day >= 7)
        //                    {
        //                        sum += 200;
        //                    }
        //                }

        //            }
        //            if (deliveryoption.PickUpDate.Month > DateTime.Now.Month)
        //            {
        //                switch (DateTime.Now.Month)
        //                {
        //                    case 1:
        //                        EndOfMonth += 31;
        //                        break;
        //                    case 2:
        //                        EndOfMonth += 28;
        //                        break;
        //                    case 3:
        //                        EndOfMonth += 31;
        //                        break;
        //                    case 4:
        //                        EndOfMonth += 30;
        //                        break;
        //                    case 5:
        //                        EndOfMonth += 31;
        //                        break;
        //                    case 6:
        //                        EndOfMonth += 30;
        //                        break;
        //                    case 7:
        //                        EndOfMonth += 31;
        //                        break;
        //                    case 8:
        //                        EndOfMonth += 31;
        //                        break;
        //                    case 9:
        //                        EndOfMonth += 30;
        //                        break;
        //                    case 10:
        //                        EndOfMonth += 31;
        //                        break;
        //                    case 11:
        //                        EndOfMonth += 30;
        //                        break;
        //                    case 12:
        //                        EndOfMonth += 31;
        //                        break;
        //                    default:
        //                        break;
        //                }
        //                sum += ((EndOfMonth - DateTime.Now.Date.Day) + deliveryoption.PickUpDate.Day) * carty[0].Product.Price;
        //                //3 days R300
        //                if ((EndOfMonth - DateTime.Now.Date.Day) + deliveryoption.PickUpDate.Day > 1 && (EndOfMonth - DateTime.Now.Date.Day) + deliveryoption.PickUpDate.Day < 5)
        //                {
        //                    sum += 300;
        //                }
        //                //5 days R260
        //                if ((EndOfMonth - DateTime.Now.Date.Day) + deliveryoption.PickUpDate.Day > 4 && (EndOfMonth - DateTime.Now.Date.Day) + deliveryoption.PickUpDate.Day < 7)
        //                {
        //                    sum += 260;
        //                }
        //                //7 days R200
        //                if ((EndOfMonth - DateTime.Now.Date.Day) + deliveryoption.PickUpDate.Day >= 7)
        //                {
        //                    sum += 200;
        //                }
        //            }
        //            Session["deliveryCharges"] = sum;
        //            deliveryoption.DeliveryTitle = "Deliver To Your Address";
        //            Session["deliveryOption"] = deliveryoption;
        //            return RedirectToAction("CaptureAddress");
        //        }
        //        else
        //        {
        //            Session["deliveryOption"] = deliveryoption;
        //            return RedirectToAction("GenerateOrderLayout");
        //        }


        //    }

        //    return View("error");
        //}
        //public ActionResult CaptureAddress()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    Order newOrder = new Order();
        //    OrderDetail od = new OrderDetail();
        //    DeliveryOption ed = (DeliveryOption)Session["deliveryOption"];
        //    List<Item> carty = (List<Item>)this.Session["cart"];
        //    if (carty != null)
        //    {
        //        newOrder.OrderDate = DateTime.Now;
        //        newOrder.OrderId = (db.Orders.Count()) + 1;
        //        newOrder.UserName = User.Identity.Name;
        //        od.OrderId = newOrder.OrderId;
        //        od.Items = carty;
        //        decimal delcharge = (decimal)Session["deliveryCharges"];
        //        decimal sum = 0;
        //        if ((od.Items.Count) > 0)
        //        {
        //            foreach (Item nm in od.Items)
        //            {
        //                sum += nm.Product.Price * nm.Quantity;
        //            }
        //        }
        //        newOrder.Total = sum+delcharge;
        //    }
        //    Session["order"] = newOrder;
        //    Session["orderDetails"] = od;
        //    return View("CaptureAddress");
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CaptureAddress([Bind(Include="Country,State,City,Address,PostalCode")]Order order)
        //{
        //     ApplicationDbContext db = new ApplicationDbContext();
            
        //    if(ModelState.IsValid)
        //    {

        //        //Order oz = (Order)Session["order"];
        //        //order.OrderId = oz.OrderId;
        //        //order.OrderDate = oz.OrderDate;
        //        //order.OrderDetails = oz.OrderDetails;
        //        //order.Email = oz.Email;
        //        //order.Total = oz.Total;
        //        //order.UserName = oz.UserName;
        //        //order.ApplicationUser = oz.ApplicationUser;
        //            db.Orders.Add(order);
        //            db.SaveChanges();
        //           return RedirectToAction("Complete");

        //    }
        //    return View("CaptureAddress");
        //}
        //public ActionResult GenerateOrderLayout()
        //{
        //    DeliveryOption od = (DeliveryOption)Session["deliveryOption"];
        //    return View();
        //}
        //public ActionResult CheckOut()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    Order newOrder = new Order();
        //    OrderDetail od = new OrderDetail();
        //    string email=(string)Session["email"];
        //    List<Item> carty = (List<Item>)this.Session["cart"];
        //    if (carty != null)
        //    {
        //        newOrder.OrderDate = DateTime.Now;
        //        newOrder.OrderId = (db.Orders.Count()) + 1;
        //        newOrder.UserName = User.Identity.Name;
        //        newOrder.Email = (string)Session["email"];
        //        od.OrderDetailId = (db.OrderDetails.Count()) + 1;
        //        od.OrderId = newOrder.OrderId;
        //        //newOrder.OrderDetails.Add(od);
        //        od.Items = carty;
        //        decimal sum = 0;
        //        if ((od.Items.Count) > 0)
        //        {
        //            foreach (Item nm in od.Items)
        //            {
        //                sum += nm.Product.Price * nm.Quantity;
        //            }
        //        }
        //        newOrder.Total = sum;
        //    }
        //    Session["order"] = newOrder;
        //    Session["orderDetails"] = od;
        //    return View("CheckOut");
        //}
        ////public ActionResult mail()
        ////{
        ////    ApplicationDbContext db = new ApplicationDbContext();
        ////    return View();
        ////}

        ////[HttpPost]
        ////public ActionResult mail(WebApplication2.SendEmail.Models.MailModel objModelMail, HttpPostedFileBase fileUploader)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        string from = "Your Gmail Id"; //example:- sourabh9303@gmail.com
        ////        using (MailMessage mail = new MailMessage(from, objModelMail.To))
        ////        {
        ////            mail.Subject = objModelMail.Subject;
        ////            mail.Body = objModelMail.Body;
        ////            if (fileUploader != null)
        ////            {
        ////                string fileName = Path.GetFileName(fileUploader.FileName);
        ////                mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));
        ////            }
        ////            mail.IsBodyHtml = false;
        ////            SmtpClient smtp = new SmtpClient();
        ////            smtp.Host = "smtp.gmail.com";
        ////            smtp.EnableSsl = true;
        ////            NetworkCredential networkCredential = new NetworkCredential(from, "Your Gmail Password");
        ////            smtp.UseDefaultCredentials = true;
        ////            smtp.Credentials = networkCredential;
        ////            smtp.Port = 587;
        ////            smtp.Send(mail);
        ////            ViewBag.Message = "Sent";
        ////            return View("mail", objModelMail);
        ////        }
        ////    }
        ////    else
        ////    {
        ////        return View();
        ////    }
        ////}

