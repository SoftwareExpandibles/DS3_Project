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
            ViewBag.View=ch.AcceptedReStocks();
            return View();
        }
        public ActionResult ProcessedOrders()
        {
            ViewBag.View = ch.ProcessedOrders();
            return View();
        }
        public ActionResult MonthlyReOrders()
        {
            ViewBag.View = ch.RequestedOrders();
            return View();
        }
        public ActionResult MonthlyOrders()
        {
            ViewBag.View = ch.RequestedRestock();
            return View();
        }
    }
}