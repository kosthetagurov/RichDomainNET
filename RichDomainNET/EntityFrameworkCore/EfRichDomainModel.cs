﻿using Microsoft.EntityFrameworkCore;

using RichDomainNET.Abstractions;

namespace RichDomainNET.EntityFrameworkCore
{
    public class EfRichDomainModel<TContext> : RichDomainModel where TContext : DbContext, new()
    {
        public virtual TContext CreateDbContext(DbContextOptions options, Func<DbContextOptions, TContext> func)
        {
            return func(options);
        }

        public virtual TContext CreateDbContext(Func<TContext> factoryMethod)
        {
            return factoryMethod();
        }

        public virtual TContext CreateDbContext(Func<string, TContext> factoryMethod)
        {
            return factoryMethod(RichDomainModelContext.ConnectionString);
        }

        public virtual TContext CreateDbContext()
        {
            return new();
        }
    }
}
