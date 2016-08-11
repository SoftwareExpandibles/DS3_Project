using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Data.Models;
using Data;
using Services;
using EntityState = System.Data.EntityState;

namespace Rangamo.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        // GET: Products
        public HomeController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            ViewBag.ProductList = db.Products.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}