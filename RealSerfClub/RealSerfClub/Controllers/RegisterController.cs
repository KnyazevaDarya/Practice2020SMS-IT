using Surf_blog.Helpers;
using Surf_blog.DAL;
using Surf_blog.Helpers;
using Surf_blog.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Surf_blog.Controllers
{
    public class RegisterController : Controller
    {
        SurfDBContext dBContext = new SurfDBContext();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(User model, HttpPostedFileBase imageData)
        {
            if (ModelState.IsValid)
            {
                //регистрация
                if(model.Password != model.PasswordConfirm)
                {
                    ModelState.AddModelError(string.Empty, "Введенные пароли не совпадают!");
                    return View("Index", model);
                }

                var userInDb = dBContext.Users.FirstOrDefault(c => c.Nickname == model.Nickname);
                if (userInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Пользователь с таким псевдонимом уже существует!");
                    return View("Index", model);
                }

                var userEmailInDb = dBContext.Users.FirstOrDefault(c => c.Email == model.Email);
                if (userEmailInDb != null)
                {
                    ModelState.AddModelError(string.Empty, "Данный адрес электронной почты уже использован!");
                    return View("Index", model);
                }


                if (imageData != null)
                {
                    if (!ImageFormatHelper.IsJpg(imageData))
                    {

                        ModelState.AddModelError(string.Empty, "Загруженное изображение не картинка формата JPG");
                        return View("Index", model);
                    }

                    model.Photo = ImageSaveHelper.SaveImage(imageData);
                }

                dBContext.Users.Add(model);
                dBContext.SaveChanges();

                FormsAuthentication.SetAuthCookie(model.Nickname, false);
                Session["UserId"] = model.Id.ToString();
                Session["Nickname"] = model.Nickname;
               // Session["Photo"] = userInDb.Photo.ToString();
                 Session["Photo"] = ImageUrlHelper.GetUrl(model.Photo);

                return RedirectToAction("Index", "Feed");

                }

            return View("Index", model);
        }
    }
}
