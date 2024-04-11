using Microsoft.EntityFrameworkCore;

namespace DbOpeationsWithEFCore.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currencies>().HasData(
                new Currencies() { Id=1,Title="INR"},
                new Currencies() { Id = 2, Title = "Dollar" },
                new Currencies() { Id = 3, Title = "Euro" },
                new Currencies() { Id = 4, Title = "Dinnar" });
            modelBuilder.Entity<Languages>().HasData(
               new Languages() { Id = 1, Title = "Hindi",Description="Indian Hindi" },
               new Languages() { Id = 2, Title = "English",Description="UK English" },
               new Languages() { Id = 3, Title = "Punjabi",Description="Punjab's language" },
               new Languages() { Id = 4, Title = "Urdu",Description="Meerut's urdu" });
        }
        public DbSet<Book> tbl_Books { get; set; }
        public DbSet<Languages> tbl_Languages { get; set; }
        public DbSet<BookPrices> tbl_Book_Prices { get; set; }
        public DbSet<Currencies> tbl_Currencies { get; set; }
    }
}
