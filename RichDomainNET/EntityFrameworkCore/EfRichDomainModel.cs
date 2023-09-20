using Microsoft.EntityFrameworkCore;

using RichDomainNET.Abstractions;

namespace RichDomainNET.EntityFrameworkCore
{
    public class EfRichDomainModel<TContext> : RichDomainModel where TContext : DbContext, new()
    {
        public virtual TContext CreateDbContext(DbContextOptions options, Func<DbContextOptions, TContext> func)
        {
            return func(options);
        }

        public virtual TContext CreateDbContext(Func<TContext> func)
        {
            return func();
        }

        public virtual TContext CreateDbContext(Func<string, TContext> func)
        {
            return func(Context.Connection.ConnectionString);
        }

        public virtual TContext CreateDbContext()
        {
            return new();
        }
    }
}
