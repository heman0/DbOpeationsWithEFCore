# Database Opeations with Entity Framework Core
## Initial Configuations:
  1.Install the necessary packages like:
    -Microsoft.EntityFrameworkCore
    -Microsoft.EntityFrameworkCore.SqlServer
    -Microsoft.EntityFrameworkCore.Tools
    -Microsoft.EntityFrameworkCore.Design
  2.Create a custom DbContextClass which inherits the DbContext class just like:
      `using Microsoft.EntityFrameworkCore;
      namespace DbOpeationsWithEFCore.Data
      {
        public class AppDbContext:DbContext
        {
          public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
          {
          }
        }
      }`
  3. Add Connection Sting in appsettings.json file, like:
  `"ConnectionStrings": {
  "connectionString": "Server=.;Database=EFCoreDB;Integrated     Security=true;TrustServerCertificate=true;"
  }`
  4.Register this class in Program.cs file like:
    `builder.Services.AddDbContext<AppDbContext>(options =>
    {         
   options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
  });`
