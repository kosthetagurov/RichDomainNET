using RichDomainNET.EntityFrameworkCore.RichCollections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Collections
{
    public class Orders : EfRichDomainModelRepository<ApplicationDbContext, Order>
    {
        public Orders(ApplicationDbContext dbContext, Func<Order, bool> filter = null) 
            : base(dbContext, filter)
        {
        }
    }
}
