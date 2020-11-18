using BlogDatabase.Database;
using BlogDatabase.Entities;

namespace BlogDatabase
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var ctx = new BlogContext())
            {
                var blog = new Blog() { Name = "Blog" };

                ctx.Blogs.Add(blog);
                ctx.SaveChanges();
            }
            System.Console.WriteLine("Blog builded.");
            System.Console.ReadLine();
        }
    }
}
