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
    public class ApplicantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Applicants [Admin]
        public ActionResult Index()
        {
            var applicants = db.Applicants.Include(a => a.Jobs);
            return View(applicants.ToList());
        }

        // GET: One Applicant [User]
        [Authorize]
        public ActionResult MyApplication()
        {
            var me = (from a in db.Applicants
                      where a.Username == User.Identity.Name
                      select a).ToList();
            return View(me);
        }

        // GET: Applicants/Details/5 [Admin]
        public ActionResult Details(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // GET: Applicants/Create [User]
        public ActionResult Create()
        {
            ViewBag.jobID = new SelectList(db.Jobs, "jobID", "jobTitle");
            return View();
        }

        // POST: Applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicantID,Username,Title,FirstName,LastName,IdNo,Gender,Email,cell,Address,Province,City,zip,institution,qualification,year,cv,jobID,AppRefNumber,ApplicationDate,dob")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                applicant.ApplicationDate = DateTime.Now;
                applicant.Username = User.Identity.Name;
                applicant.dob = "19" + applicant.IdNo.Substring(0, 2) + "-" + applicant.IdNo.Substring(2, 2) + "-" + applicant.IdNo.Substring(4, 2);
                applicant.AppRefNumber = applicant.FirstName.Substring(0, 1).ToUpper() + applicant.LastName.ToLower() + applicant.IdNo.Substring(0, 6);
                db.Applicants.Add(applicant);
                db.SaveChanges();
                return RedirectToAction("MyApplication");
            }

            ViewBag.jobID = new SelectList(db.Jobs, "jobID", "jobTitle", applicant.jobID);
            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant.Username != User.Identity.Name)
            {
                return HttpNotFound();
            }
            ViewBag.jobID = new SelectList(db.Jobs, "jobID", "jobTitle", applicant.jobID);
            return View(applicant);
        }

        // POST: Applicants/Edit/5 [User]
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicantID,Username,Title,FirstName,LastName,IdNo,Gender,Email,cell,Address,Province,City,zip,institution,qualification,year,cv,jobID,AppRefNumber,ApplicationDate,dob")] Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jobID = new SelectList(db.Jobs, "jobID", "jobTitle", applicant.jobID);
            return View(applicant);
        }

        // GET: Applicants/Delete/5 [Admin]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5 [Admin]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            db.Applicants.Remove(applicant);
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
