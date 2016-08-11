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

namespace Rangamo.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        public SuppliersController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());

        }
        // GET: Suppliers
        public ActionResult Index()
        {
            return View(_rangamoRepository.GetSuppliers());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,Phone,Email,Address,Location,postalCode")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _rangamoRepository.CreateSupplier(supplier);
                _rangamoRepository.Save();
                //db.Suppliers.Add(supplier);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,Phone,Email,Address,Location,postalCode")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _rangamoRepository.UpdateSupplier(supplier);
                _rangamoRepository.Save();
                //db.Entry(supplier).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            _rangamoRepository.DeleteSupplier(id);
            _rangamoRepository.Save();
            //db.Suppliers.Remove(supplier);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _rangamoRepository.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
