using BlogDatabase.BLOG.BLL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogDatabase.BLOG.DAL.EF
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ConnectionStringDto connectionStringDto;

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext(ConnectionStringDto connectionStringDto)
        {
            this.connectionStringDto = connectionStringDto;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionStringDto.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
        }
    }
}
