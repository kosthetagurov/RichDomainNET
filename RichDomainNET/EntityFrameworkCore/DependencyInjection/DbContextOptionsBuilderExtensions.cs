using Microsoft.EntityFrameworkCore;

using RichDomainNET.EntityFrameworkCore.Interceptors;

namespace RichDomainNET.EntityFrameworkCore.DependencyInjection
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder AddMateriazationInterceptor(this DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new MaterializationInterceptor());
            return optionsBuilder;
        }
    }
}
