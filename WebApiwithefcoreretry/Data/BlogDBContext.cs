using Microsoft.EntityFrameworkCore;
using WebApiwithefcoreretry.Entity;

namespace WebApiwithefcoreretry.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }

        public DbSet<Blog>  Blogs { get; set; }
    }
}
