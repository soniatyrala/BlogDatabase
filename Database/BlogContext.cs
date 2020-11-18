using BlogDatabase.Entities;
using System.Data.Entity;


namespace BlogDatabase.Database
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogDB") => System.Data.Entity.Database.SetInitializer<BlogContext>(new CreateDatabaseIfNotExists<BlogContext>());

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
