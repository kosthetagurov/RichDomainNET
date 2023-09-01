using Microsoft.EntityFrameworkCore;

using RichDomainNET.Abstractions;

namespace RichDomainNET.EntityFrameworkCore
{
    public class EfRichDomainModel<TContext> : RichDomainModel where TContext : DbContext, new()
    {
        public TContext CreateDbContext(DbContextOptions options, Func<DbContextOptions, TContext> func)
        {
            return func(options);
        }

        public TContext CreateDbContext(Func<TContext> func)
        {
            return func();
        }

        public TContext CreateDbContext()
        {
            return new();
        }
    }
}
