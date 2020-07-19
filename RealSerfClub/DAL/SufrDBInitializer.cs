using Surf_blog.Models.DBModels;
using System.Data.Entity;
using System;

namespace Surf_blog.DAL
{
    public class SufrDBInitializer : DropCreateDatabaseAlways<SurfDBContext>
    {
        protected override void Seed(SurfDBContext context)
        {
            var user = new User
            {
                Nickname = "user",
                Password = "123",
                LastName = "Petrov",
                Name = "Ivan",
                Email = "ff@ya.ru",
                About = "Very much"
            };

            var post1 = new Post
            {
                Text = "text1",
                PublishDate = DateTime.Now,
                Author = user
            };

            var post2 = new Post
            {
                Text = "text2",
                PublishDate = DateTime.Now,
                Author = user
            };

            context.Users.Add(user);
            context.Posts.Add(post1);
            context.Posts.Add(post2);
            context.SaveChanges();
        }
    }
}