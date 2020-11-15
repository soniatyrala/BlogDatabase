using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BlogDatabase
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<User> Users { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }



    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                var blog = new Blog { Name = "Blog" };
                db.Blogs.Add(blog);
                db.SaveChanges();

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
