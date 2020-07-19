using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Surf_blog.Models.DBModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Введите текст"), MaxLength(4095)]
        public string Text { get; set; }

        [Display(Name = "Прикрепить изображение")]
        public Guid Photo { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual User Author { get; set; }

    }
}