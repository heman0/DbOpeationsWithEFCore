using Microsoft.EntityFrameworkCore;

namespace DbOpeationsWithEFCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            

        }
        public DbSet<Book> tbl_Books { get; set; }
        public DbSet<Languages> tbl_Languages { get; set; }
    }
}
