using Microsoft.EntityFrameworkCore;

namespace DbOpeationsWithEFCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            

        }
    }
}
