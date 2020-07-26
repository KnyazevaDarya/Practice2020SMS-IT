using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Surf_blog.Models.DBModels
{
    public class User
    {
         [Key]
         public int Id { get; set; }

         [Display (Name = "Псевдоним")]
         [Required (ErrorMessage = "Ошибка в псевдониме"), MinLength(3), MaxLength(20)]

         public string Nickname { get; set; }

         [Display (Name = "Почта")]
         [Required (ErrorMessage = "Указание электронной почты обязательно")]
         [EmailAddress (ErrorMessage = "Неверно указан адрес электронной почты")]

         public string Email { get; set; }

         [Display (Name = "Пароль")]
         [Required (ErrorMessage = "Ошибка при вводе пароля"), MinLength(6), MaxLength(20)]
        
         public string Password { get; set; }

         [Display (Name ="Фамилия")]

         public string LastName { get; set; }

         [Display (Name ="Имя")]

         public string Name { get; set; }

         [Display (Name ="Контактная информация")]

         public string ContactInfo { get; set; }

         [Display (Name ="О себе")]

         public string About { get; set; }

         [Display (Name ="Достижения")]

         public string Progress { get; set; }

         [Display (Name ="Выберите фото")]

         public Guid Photo { get; set; }

         [Display (Name = "Подтвердите пароль")]
         [NotMapped]

         public string PasswordConfirm { get; set; }
    }
}