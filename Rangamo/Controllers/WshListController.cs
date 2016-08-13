using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rangamo.Models;
using Models;
using Data.Models;

namespace Rangamo.Controllers
{
    //[Authorize]
    public class WshListController : Controller
    {

        // GET: /Cart/
        public ActionResult Index()
        {
            return View();
        }
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["wishlist"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Add(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (Session["wishlist"] != null)
            {
                List<Item> cart = (List<Item>)Session["wishlist"];
                int index = isExisting(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                if (index == -1)
                {
                    cart.Add(new Item { ItemId = (cart.Count + 1), Product = db.Products.Find(id), Quantity = 1 });
                }
            }

            if (Session["wishlist"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { ItemId = 1, Product = db.Products.Find(id), Quantity = 1 });
                Session["wishlist"] = cart;
            }
            return View("wishlist");
        }
        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["wishlist"];
            int index = BisExisting(id);
            cart.RemoveAt(index);
            if (cart.Count == 0)
            {
                cart = null;
            }
            Session["wishlist"] = cart;
            return View("wishlist");
        }

        private int BisExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["wishlist"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.ProductId == id)
                    return i;
            return -1;
        }
	}
}