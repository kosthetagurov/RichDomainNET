using Microsoft.EntityFrameworkCore;

using RichDomainNET.EntityFrameworkCore.DependencyInjection;

namespace Demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base(GetOptions(Constants.ConnectionString))
        { }

        public ApplicationDbContext(string connectionString)
            : base(GetOptions(connectionString))
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }        
        public DbSet<Order> Orders { get; set; }

        #region         

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Orders);
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
