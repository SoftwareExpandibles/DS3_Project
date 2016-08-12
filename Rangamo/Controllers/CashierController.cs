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
    public class CashierController : Controller
    {
        // GET: Cashier
        private ApplicationDbContext db = new ApplicationDbContext();
        public static List<Product> list = new List<Product>();
        public static double total = 0;

        // GET: /Product/
        public ActionResult Index()
        {
            total = 0;
            list.Clear();

            Session["Total"] = total;

            return View(new List<Product>());

           
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? id, double? cash)
        {


            if (id != null && cash == null)
            {
                var search = from c in db.Products.ToList() select c;
                Product p = new Product();
                if (!search.Equals(null))
                {
                    search = search.Where(d => d.ProductId== id);

                    foreach (var s in search)
                    {
                        list.Add(s);
                        total += Convert.ToDouble(s.Price);
                    }

                    Session["Total"] = total;
                }

                else
                {
                    ViewBag.Error = "item Id not found";
                    return View(list);
                }
            }

            if (cash != null && id != null)
            {
                ViewBag.Change = cash - total;
            }

            if (cash < total)
            {
                ViewBag.Change = "";
                ViewBag.Error1 = "Please pay R" + total + " or more.";
            }

            return View(list);


        }

        [HttpPost]
        public ActionResult calc(double cash)
        {
            ViewBag.Change = cash - Convert.ToInt32(Session["Total"].ToString());

            return View();
        }
    }
}