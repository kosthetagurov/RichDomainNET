using Demo.Data;
using Demo.Data.Collections;

using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine();

            using var context = new ApplicationDbContext();
            context.Database.Migrate();

            EfCoreDemo(context);

            Console.ReadKey();
        }

        static void EfCoreDemo(ApplicationDbContext context)
        {
            var people = new People(context);
            people.RemoveAll();

            var products = new Products(context);
            products.RemoveAll();

            var orders = new Orders(context);
            orders.RemoveAll();            

            people.Insert(                
                new Person
                {
                    Name = "John",
                    Age = 25
                }
            );

            products.Insert(
                new Product
                {
                    Name = "Lays",
                    Price = 100                    
                },
                new Product
                {
                    Name = "M&M`s",
                    Price = 85
                }
            );

            var owner = people.FirstOrDefault();
            orders.Insert(
                new Order
                {
                    PersonId = owner.Id,
                    Person = owner,
                    Products = products.ToList()
                }
            );

            var ordersList = context.Orders.ToList();
            //var ordersViewModels = ordersList.Select(x => x.AsViewModel()).ToList();
        }
    }
}