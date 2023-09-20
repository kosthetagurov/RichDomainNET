using Microsoft.EntityFrameworkCore;

namespace Demo.Web.Data
{
    public sealed class ApplicationDbContextOptionsDefaults
    {
        string _connectionString;

        public ApplicationDbContextOptionsDefaults(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void BuilderStrategy(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString);
        }

        public DbContextOptions<ApplicationDbContext> GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), _connectionString).Options as DbContextOptions<ApplicationDbContext>;
        }
    }
}
