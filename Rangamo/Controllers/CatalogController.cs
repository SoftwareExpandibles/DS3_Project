using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;
using  Data.Models;
using  Data;
using  Services;

namespace Rangamo.Controllers
{
    public class CatalogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        public CatalogController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            ViewBag.Productlist = _rangamoRepository.GetAllProducts();
            return View();
        }
        public ActionResult Catagories()
        {
            return View(db.Genres.ToList());
        }
        public ActionResult Search(string gen)
        {
            // Retrieve Genre and its Associated Items from database
            var genre = db.Genres.Include("Product")
                .Single(g => g.Catagory == gen);

            return View(gen);
        }
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
	}
}