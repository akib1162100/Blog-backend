using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base (options)
        {
            if (options is null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }
        }
        public DbSet<Blog> Blogs{get;set;}
    }
}