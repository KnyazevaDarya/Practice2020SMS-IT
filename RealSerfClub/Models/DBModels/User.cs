using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Surf_blog.Models.DBModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string LastName { get; set; }

        public string Name { get; set; }

        public string ContactInfo { get; set; }

        public string About { get; set; }

        public string Progress { get; set; }

        public Guid Photo { get; set; }
    }
}