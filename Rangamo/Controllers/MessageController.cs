using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Rangamo.Models;
using Data.Models;

namespace WebApplication1.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public ActionResult SendMessage(FormCollection form)
        {
           
            messages objMessage = new messages();
            string email = form["email"].ToString();
            string name = form["name"].ToString();
            string message = form["message"].ToString();
            string confirm = "*********** for attempting to send us Message, fill in all the text areas ***********";
            if (name != "Name" || email != "Email" || message != "Message")
            {
                objMessage.Email = email;
                objMessage.userName = name;
                objMessage.message = message;
                objMessage.Message_date = DateTime.Now.Date;
                db.messages.Add(objMessage);
                db.SaveChanges();
                ViewBag.Name = name;
                confirm = "*********** We Received Your Message ***********";
            }
            ViewBag.Confirm = confirm;
            return View();
        }
        // GET: /Message/
        public ActionResult Index()
        {
            return View(db.messages.ToList());
        }

        // GET: /Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messages messages = db.messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // GET: /Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="messageID,userName,message,Email,Message_date")] messages messages)
        {
            if (ModelState.IsValid)
            {
                db.messages.Add(messages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messages);
        }

        // GET: /Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messages messages = db.messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: /Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="messageID,userName,message,Email,Message_date")] messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messages).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messages);
        }

        // GET: /Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            messages messages = db.messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: /Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            messages messages = db.messages.Find(id);
            db.messages.Remove(messages);
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
