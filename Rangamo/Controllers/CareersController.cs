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

namespace Rangamo.Controllers
{
    public class CareersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Careers
        public ActionResult Index(string title)
        {
            var careers = from c in db.Jobs
                         select c;

            if (!String.IsNullOrEmpty(title))
            {
                careers = careers.Where(j => j.jobTitle.Contains(title));
            }

            return View(careers.ToList()); 

        }

        // GET: Career/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

    }
}