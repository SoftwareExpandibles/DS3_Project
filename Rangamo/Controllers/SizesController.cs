using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Models;
using Models;
using Services;

namespace Rangamo.Controllers
{
    public class SizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;

        public SizesController()
        {
            this._rangamoRepository=new RangamoRepository(db=new ApplicationDbContext());
        }

        // GET: Sizes
        public ActionResult Index()
        {
            var size = _rangamoRepository.GetAllSizes();
            return View(size.ToList());
        }

        // GET: Sizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // GET: Sizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sizeId,ActualSize")] Size size)
        {
            if (ModelState.IsValid)
            {
                _rangamoRepository.CreateSize(size);
                _rangamoRepository.Save();
                return RedirectToAction("Index");
            }

            return View(size);
        }

        // GET: Sizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sizeId,ActualSize")] Size size)
        {
            if (ModelState.IsValid)
            {
               _rangamoRepository.UpdateSize(size);
                _rangamoRepository.Save();
                return RedirectToAction("Index");
            }
            return View(size);
        }

        // GET: Sizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // POST: Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _rangamoRepository.DeleteSize(id);
            _rangamoRepository.Save();
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
