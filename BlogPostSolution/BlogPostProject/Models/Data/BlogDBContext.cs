using Microsoft.EntityFrameworkCore;

namespace BlogPostProject.Models.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}