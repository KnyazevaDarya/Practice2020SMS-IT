using Surf_blog.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surf_blog.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            var my = new My_model { Name = "Anny", Age = 12 };
            ViewBag.My = my;

            return View();
        }

        public ActionResult AboutMe()
        {
            var my = new My_model { Name = "Sally", Age = 20 };

            ViewBag.Prices = new[] { 100, 120, 140, 90 };


            return View(my);
        }
    }
}