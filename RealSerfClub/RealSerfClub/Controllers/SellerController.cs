using Surf_blog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surf_blog.Controllers
{
    public class SellerController : Controller
    {
        SurfDBContext dBContext = new SurfDBContext();
        // GET: Seller
        public ActionResult Index()
        {
            var user = dBContext.Users.FirstOrDefault();

            return View(user);
        }
    }
}