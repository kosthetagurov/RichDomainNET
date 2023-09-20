using Microsoft.EntityFrameworkCore;

using RichDomainNET.EntityFrameworkCore.Interceptors;

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
            var builder = SqlServerDbContextOptionsExtensions.UseSqlServer<ApplicationDbContext>(new DbContextOptionsBuilder<ApplicationDbContext>(), _connectionString);
            return builder.Options;
        }
    }
}
