using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Surf_blog.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Псевдоним"), MaxLength(20)]
        [Required(ErrorMessage = "Ошибка в псевдониме")]
        public string Nickname { get; set; }

        [Display(Name = "Пароль"), MaxLength(20)]
        [Required(ErrorMessage = "Ошибка в пароле")]
        public string Password { get; set; }

        [Display(Name = "Запомнить пароль")]
        public bool RememberMe { get; set; }
    }
}