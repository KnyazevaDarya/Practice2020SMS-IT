using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RealSerfClub.Helpers;
using Surf_blog.DAL;
using Surf_blog.Models.ViewModels;

namespace Surf_blog.Controllers
{
    public class HomeController : Controller
    {
        SurfDBContext dBContext = new SurfDBContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userInDb = dBContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname && c.Password == model.Password);
                if (userInDb != null)
                {
                    FormsAuthentication.SetAuthCookie(userInDb.Nickname, model.RememberMe);
                    Session["UserId"] = userInDb.Id.ToString();
                    Session["Nickname"] = userInDb.Nickname.ToString();
                    //Session["Photo"] = userInDb.Photo.ToString();
                    Session["Photo"] = ImageUrlHelper.GetUrl(userInDb.Photo);

                    return RedirectToAction("Index", "Feed");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Неверный псевдоним или пароль");
                }
            }
            return View("Index", model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Request.Cookies.Clear();
            return RedirectToAction("Index");
        }
    }
}