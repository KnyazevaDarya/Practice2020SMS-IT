using Surf_blog.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Surf_blog.DAL
{
    public class SurfDBContext : DbContext
    {
        static SurfDBContext()
        {
            Database.SetInitializer(new SufrDBInitializer());
        }

        public SurfDBContext() : base("Sufr_blog_database")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }
    }
}