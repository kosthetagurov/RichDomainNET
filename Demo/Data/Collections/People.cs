using RichDomainNET.EntityFrameworkCore.RichCollections;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo.Data.Collections
{
    public class People : EfRichDomainModelRepository<ApplicationDbContext, Person>
    {
        public People(ApplicationDbContext dbContext) 
            : base(dbContext) { }        

        public IEnumerable<Person> GetAdult()
        {           
            return this.Where(x => x.Age > 18);
        }        
    }
}
