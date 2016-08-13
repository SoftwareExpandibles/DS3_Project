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
using BusinessLogic;

namespace Rangamo.Controllers
{
    public class CatalogController : Controller
    {
        //readonly CatalogHead ch = new CatalogHead();
        private ApplicationDbContext db = new ApplicationDbContext();
        private IRangamoRepository _rangamoRepository;
        public CatalogController()
        {
            this._rangamoRepository = new RangamoRepository(new ApplicationDbContext());
        }
        public byte[] GetImageFromDataBase(int id)
        {
            byte[] cover;
            var repo = _rangamoRepository.GetAllProducts().ToList();
            var q = from temp in repo where temp.ProductId == id select temp.Photo;
            cover = q.First();
            return cover;
        }

        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }
        public ActionResult Index()
        {
            //ViewBag.Productlist = _rangamoRepository.GetAllProducts().ToList();
            List<Product> pro = new List<Product>();
            InventoriesController inv = new InventoriesController();
            foreach (Product item in _rangamoRepository.GetAllProducts())
            {
                var result = inv.pop().Find(p => p.ProductId == item.ProductId);
                if (result!=null)
                {
                    if (result.StockOnHand>25)
                    {
                        pro.Add(item);    
                    }
                    
                }
            }
            ViewBag.Productlist = pro;
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