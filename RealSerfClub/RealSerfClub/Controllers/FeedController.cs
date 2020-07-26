using Surf_blog.Helpers;
using Surf_blog.DAL;
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
            if (!ModelState.IsValid)
            {
                var posts1 = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
                ViewBag.Posts = posts1;

                return View("Index", model);
            }


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
                if (!ImageFormatHelper.IsJpg(imageData))
                {

                    ModelState.AddModelError(string.Empty, "Загруженное изображение не картинка формата JPG");
                    var postsdb = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
                    ViewBag.Posts = postsdb;
                    return View("Index", model);
                }

                model.Photo = ImageSaveHelper.SaveImage(imageData);
            }

            var userId = Convert.ToInt32(Session["UserId"]);
            var userInDb = dBContext.Users.FirstOrDefault(c => c.Id == userId);

            if(userInDb == null){
                TempData["errorMessage"] = "Время сессии истекло. Авторизуйетсь повторно!";
                return RedirectToAction("Index", "Home");
            }

            model.Author = userInDb;

            dBContext.Posts.Add(model);
            dBContext.SaveChanges();
            var posts = dBContext.Posts.OrderByDescending(c => c.Id).ToList();
            ViewBag.Posts = posts;
            

            ModelState.Clear();
            return View("Index");
        }
    }
}