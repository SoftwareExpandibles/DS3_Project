using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using BusinessLogic;

namespace Rangamo.Controllers
{
    public class EmailsController : Controller
    {
        // GET: Emails
        public ActionResult EmailUs()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EmailUs(FormCollection form)
        {
            EmailBusiness me = new EmailBusiness();
            string from = form["from"];
            string subj = form["sub"];
            string body = form["body"];
            me.from = new MailAddress(from);
            me.sub = subj;
            me.body = body;
            me.ToAdmin();
            return RedirectToAction("EmailUs");
        }

    }
}