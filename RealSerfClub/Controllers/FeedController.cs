using Surf_blog.DAL;
using Surf_blog.Helpers;
using Surf_blog.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surf_blog.Controllers
{
    public class FeedController : Controller
    {
        private SurfDBContext dBContext = new SurfDBContext();
        // GET: Feed
        public ActionResult Index()
        {
            var posts = dBContext.Posts.OrderByDescending(c=>c.Id).ToList();
            ViewBag.Posts = posts;

            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post model, HttpPostedFileBase imageData)
        {
            if (imageData == null && model.Text == null)
            {
                ModelState.AddModelError(string.Empty, "Не загружено изображение или отсутствует текст");
                var posts1 = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = posts1;
                return View("Index", model);
            }

            model.PublishDate = DateTime.Now;

            if (imageData != null)
            {
                model.Photo = ImageSaveHelper.SaveImage(imageData);
            }

            var userId = Convert.ToInt32(Session["UserId"]);
            var userInDb = dBContext.Users.FirstOrDefault(c => c.Id == userId);
            model.Author = userInDb;

            dBContext.Posts.Add(model);
            dBContext.SaveChanges();
            var posts = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;
            return View("Index");
        }
    }
}