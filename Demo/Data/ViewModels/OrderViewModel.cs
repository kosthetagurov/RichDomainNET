using RichDomainNET.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.ViewModels
{
    [NotMapped]
    public class OrderViewModel : RichViewModel
    {
        public string Username { get; private set; }
        public string ProductNames { get; private set; }
        public double TotalPrice { get; private set; }

        public override void Initialize()
        {            
            var context = new ApplicationDbContext(RichDomainModelContext.ConnectionString);

            var order = context.Orders.Include(x => x.Products).FirstOrDefault(x => x.Id == int.Parse(EntityId.ToString()));
            var user = context.People.FirstOrDefault(x => x.Id == order.PersonId);

            Username = user.Name;

            var products = order.Products;
            ProductNames = string.Join(", ", products.Select(x => x.Name));
            TotalPrice = products.Sum(x => x.Price);
        }
    }
}
