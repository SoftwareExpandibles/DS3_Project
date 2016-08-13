using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Rangamo.Controllers
{
    public class CustomerController : Controller
    {
        
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: /Customer/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
     

        public ActionResult Detail()
        {
            var m = db.Users.ToList().Find(x =>x.UserName.Equals(User.Identity.Name));
            //var m = db.Customers.ToList().Find(x => x.Username.Equals(User.Identity.Name));
            if(m.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(m);
        }



        public ActionResult Details1()
        {
            return View(db.Users.ToList());
        }
	}
}