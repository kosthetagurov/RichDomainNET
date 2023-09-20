using Demo.Data;
using Microsoft.EntityFrameworkCore;
using RichDomainNET.Dapper;
using System.Data.SqlClient;

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
            //DapperDemo();

            Console.ReadKey();
        }

        static void EfCoreDemo(ApplicationDbContext context)
        {
            Console.WriteLine("Ef Core Demo.");

            var chris = new Person()
            {
                Age = 21,
                Name = "Chris"                
            };

            context.People.Add(chris);
            context.SaveChanges();

            var people = context.People.ToList();

            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");

                person.Age += 10;
                person.Name += " (renamed)";
                person.Update();
            }

            var modifiedPeople = context.People.ToList();
            foreach (var person in modifiedPeople)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            Console.WriteLine();
        }

        static void DapperDemo()
        {
            Console.WriteLine("Dapper Demo.");

            using var connection = new SqlConnection(Constants.ConnectionString);
            var sql = "select * from Products";

            var products = connection.RichQuery<Product>(sql);
            foreach (var item in products)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");
                item.Name += " (renamed)";
                item.Update();
            }

            var modifiedProducts = connection.RichQuery<Product>(sql);
            foreach (var item in modifiedProducts)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}");                
            }

            Console.WriteLine();
        }
    }
}