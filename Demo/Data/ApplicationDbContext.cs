using Microsoft.EntityFrameworkCore;

using RichDomainNET.EntityFrameworkCore.DependencyInjection;

namespace Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(GetOptions(Constants.ConnectionString))
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }        

        #region 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Person>()
                .HasData(
                    new Person { Id = new Random().Next(0, 9999), Age = 21, Name = "John" },
                    new Person { Id = new Random().Next(0, 9999), Age = 24, Name = "Kate" }
                 );

            modelBuilder
                .Entity<Product>()
                .HasData(
                    new Product { Id = Guid.NewGuid(), Name = "Table", Price = 1000.0 },
                    new Product { Id = Guid.NewGuid(), Name = "Bed", Price = 1500.0 }
                );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.AddMateriazationInterceptor();
            optionsBuilder.AddCreateEntityInterceptor();
            base.OnConfiguring(optionsBuilder);
        }

        public static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        #endregion        
    }
}
