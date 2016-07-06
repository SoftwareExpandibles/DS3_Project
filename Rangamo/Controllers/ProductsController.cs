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
using EntityState = System.Data.EntityState;

namespace Rangamo.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        // GET: Products
        public ProductsController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        // GET: Products
        public ActionResult Index()
        {
           // var products = db.Products.Include(p => p.Genre).Include(p => p.Size);
            var product = _rangamoRepository.GetAllProducts();
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.genreId = new SelectList(db.Genres, "genreID", "Catagory");
            ViewBag.sizeId = new SelectList(db.Sizes, "sizeId", "ActualSize");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string ImgName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath = Server.MapPath("~/Content/Images/" + ImgName);
                file.SaveAs(physicalPath);
                product.Photo = ImgName;
                //int a = db.Inventory.Count();
                //int b = a + 1;
                //Inventory inv = new Inventory();
                //inv.inventoryId = b;
                //inv.StockOnHand = 25;
                //inv.ReOrderQuantity = 5;
                //db.Inventory.Add(inv);
                //db.SaveChanges();
                //product.inventoryId = b;
                try //(ModelState.IsValid)
                {
                   _rangamoRepository.CreateProduct(product);
                    _rangamoRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    ViewBag.err = "error " + e.Message;
                    return View(product);
                }
            }
            ViewBag.genreId = new SelectList(_rangamoRepository.GetAllGenres(), "genreId", "Category", product.genreId);
           
            ViewBag.sizeId = new SelectList(_rangamoRepository.GetAllSizes(), "sizeId", "ActualSize", product.sizeId);
            return View(product);
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.genreId = new SelectList(db.Genres, "genreID", "Catagory", product.genreId);
            ViewBag.sizeId = new SelectList(db.Sizes, "sizeId", "ActualSize", product.sizeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Photo,Price,genreId,Color,sizeId,Created")] Product product)
        {
            if (ModelState.IsValid)
            {
                _rangamoRepository.UpdateProduct(product);
                _rangamoRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.genreId = new SelectList(db.Genres, "genreID", "Catagory", product.genreId);
            ViewBag.sizeId = new SelectList(db.Sizes, "sizeId", "ActualSize", product.sizeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
           _rangamoRepository.DeleteProduct(id);
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
