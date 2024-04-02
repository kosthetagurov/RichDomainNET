using RichDomainNET.EntityFrameworkCore.RichCollections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Collections
{
    public class Products : EfRichDomainModelRepository<ApplicationDbContext, Product>
    {
        public Products(ApplicationDbContext dbContext, Func<Product, bool> filter = null) 
            : base(dbContext, filter)
        {
        }
    }
}
