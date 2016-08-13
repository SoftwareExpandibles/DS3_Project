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
using BusinessLogic;

namespace Rangamo.Controllers
{
    public class HomeController : Controller
    {
        readonly CatalogHead ch = new CatalogHead();
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
        public ActionResult AcceptedRestock()
        {
            ViewBag.View = _rangamoRepository.GetAllDailyReOrderCounters();
            return View();
        }
        public ActionResult ProcessedOrders()
        {
            ViewBag.View = _rangamoRepository.GetAllDailyOrderCounters();
            return View();
        }
        public ActionResult MonthlyReOrders()
        {
            ViewBag.View = _rangamoRepository.GetAllMonthlyReOrderCounters();
            return View();
        }
        public ActionResult MonthlyOrders()
        {
            ViewBag.View = _rangamoRepository.GetAllMonthlyOrderCounters();
            return View();
        }
    }
}