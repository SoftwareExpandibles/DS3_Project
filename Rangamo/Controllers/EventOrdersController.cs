using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using Models;
using Data;
using Services;
using System.IO;

namespace Rangamo.Controllers
{
    public class EventOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        public EventOrdersController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        // GET: EventOrders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id, string email)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);

            if (order == null)
            {
                return HttpNotFound();
            }
           // ViewBag.Images = db.OrderImages.ToList().FindAll(x => x.email == email /*&& x.Orders.orderID == id*/);
            return View(order);
        }


        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                EventOrder order = new EventOrder()
                {
                    description = model.description,
                    email = HttpContext.User.Identity.Name,
                    eventType = model.eventType,
                    replied = false,
                    deadline = model.deadline,
                    title = model.title
                };
                db.EventOrders.Add(order);

                foreach (var img in model.image)
                {
                    byte[] imageByte = null;
                    BinaryReader reader = new BinaryReader(img.InputStream);
                    imageByte = reader.ReadBytes((int)img.ContentLength);
                    OrderImage oi = new OrderImage();
                    oi.email = HttpContext.User.Identity.Name;
                    oi.image = imageByte;
                    db.OrderImages.Add(oi);
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // GET: Orders/Edit/5
        public ActionResult Reply(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            EmailReply er = new Models.EmailReply()
            {
                emailTo = order.email,
                orderId = order.orderID,
                text = ""
            };

            return View(er);
        }
        public string SendEmailz(Order ord, double amt, string txt, string emailTo)
        {
            SmtpClient client = new SmtpClient();
            string feedback = "Email Failed ";
            var m = new MailMessage()
            {
                Subject = "Test email",
                IsBodyHtml = true
            };
            if (amt > 0)
            {
                m.Body = txt + " " + "<br/ >" + "<br /> " + "Payment Amount will a be worth :" + amt.ToString("R0.00");
            }
            if (amt == 0)
            {
                m.Body = txt.ToString();
            }
            m.From = new MailAddress("21225710@dut4life.ac.za", "");
            m.To.Add(new MailAddress(emailTo));
            SmtpClient smtp = new SmtpClient()
            {
                Host = "mfd.dut.ac.za",
                Port = 25,
                Credentials = new NetworkCredential("21225710@dut4life.ac.za", "Dut930610"),
                EnableSsl = true
            };

            try
            {
                smtp.Send(m);
                feedback = "Email sent To " + new MailAddress("21225710@dut4life.ac.za");
            }
            catch (Exception ex)
            {
                feedback = "Message not sent" + ex.Message;
            }
            return feedback;
        }
        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reply([Bind(Include = "text,Amount,emailTo,orderId")]EmailReply er)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.EmailReplies.Add(er);
                    db.SaveChanges();
                    var result = db.EventOrders.Find(er.orderId);
                    result.replied = true;
                    db.Entry(result).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Content(SendEmailz(result, er.Amount, er.text, er.emailTo));
                }
            }
            catch (Exception e)
            {

                return Content(e.Message);
            }
            return View(er);
        }
        //public ActionResult Reply(EmailReply er)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.EmailReplies.Add(er);
        //        Order order = db.Orders.Find(er.orderId);
        //        order.replied = true;
        //        db.SaveChanges();
        //        //Code for sending an email here
        //        string message = "Mail fail to send";
        //        //try
        //        //{
        //        //    SmtpClient client = new SmtpClient("mfd.dut.ac.za",443);
        //        //    //client.Host = "localhost";
        //        //    //client.Port = 25;
        //        //    //client.Credentials = new NetworkCredential("", "");

        //        //    //client.EnableSsl = true;
        //        //    client.Credentials = new NetworkCredential("21225710@dut4life.ac.za", "Dut930610");
        //        //    //client.Host = "mfd.dut.ac.za";
        //        //    //client.Port =25 ;

        //        //    MailMessage mail = new MailMessage();
        //        //    mail.From = new MailAddress("21225710@dut4life.ac.za");
        //        //    mail.To.Add(new MailAddress(er.emailTo));
        //        //    mail.Body = "this is the text";
        //        //    mail.Subject = "email gone";
        //        //    mail.IsBodyHtml = true;

        //        //    message = "E-Mail has been sent";
        //        //    client.Send(mail);
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    message = ex.Message;
        //        //}
        //        //use er.emailTo as the

        //        //SmtpClient client = new SmtpClient();
        ////        string feedback = "";
        ////        var m = new MailMessage()
        ////        {
        ////            Subject = "Test email",
        ////            Body = "just to test it",
        ////            IsBodyHtml = true
        ////        };

        ////        m.From = new MailAddress("21225710@dut4life.ac.za", "");
        ////        m.To.Add(new MailAddress(er.emailTo));
        ////        SmtpClient smtp = new SmtpClient()
        ////        {
        ////            Host = "mfd.dut.ac.za",
        ////            Port = 25,
        ////            Credentials = new NetworkCredential("21225710@dut4life.ac.za", "Dut930610"),
        ////            EnableSsl = true
        ////        };

        ////        try
        ////        {
        ////            smtp.Send(m);
        ////            feedback = "Email sent T " + new MailAddress("21225710@dut4life.ac.za");
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            feedback = "Message not sent" + ex.Message;
        ////        }

        ////        ViewBag.Msg = message;
        ////        foreach(var x in db.OrderImages.Where(q=>q.email==er.emailTo))
        ////        {
        ////            Gallery g = new Models.Gallery();
        ////            g.image = x.image;
        ////            db.Galleries.Add(g);                    
        ////        }
        ////       db.SaveChanges();
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(er);
        ////}
        //        try
        //        {
        //            // Create the email object first, then add the properties.
        //            var myMessage = new SendGridMessage();
        //            // Add the message properties.
        //            myMessage.From = new MailAddress("21225710@dut4life.ac.za", "Application Name");
        //            // Add multiple addresses to the To field.
        //            List<String> recipients = new List<String>
        //    {
        //        @"<"+er.emailTo+">"
        //    };
        //            myMessage.AddTo(recipients);

        //            //Add the Subject, HTML and Text bodies
        //            // Subject
        //            string subject = "Application Recieved";

        //            // HTML Body
        //            string html = "<table style=\"border: none; font-family: verdana, tahoma, sans-serif;\">" +
        //                          "<tr> " +
        //                              "<td> <h3>Hello,</h3> <p>" + er.text + "</p>" +
        //                              "<p></p>" +
        //                              "<p>Regards,<br/><br/> Rangamo</p> </td> </tr> </table>";

        //            myMessage.Subject = subject;
        //            myMessage.Html = html;
        //            // Create a Web transport, using API Key
        //            var transportWeb = new Web("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");
        //            // Send the email.
        //            transportWeb.DeliverAsync(myMessage);
        //        }
        //        catch (Exception ex) { }

        //        ViewBag.Msg = message;
        //        foreach (var x in db.OrderImages.Where(q => q.email == er.emailTo))
        //        {
        //            Gallery g = new Models.Gallery();
        //            g.image = x.image;
        //            db.Galleries.Add(g);
        //        }
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(er);
        //}

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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