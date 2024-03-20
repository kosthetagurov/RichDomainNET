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
            // people.RemoveAll();

            Console.WriteLine("People count is " + people.Count());

            people.Insert(
                new Person()
                {
                    Name = "Harry",
                    Age = 16
                },
                new Person()
                {
                    Name = "Jane",
                    Age = 21
                },
                new Person()
                {
                    Name = "John",
                    Age = 25
                }
            );
            Console.WriteLine("People count is " + people.Count());

            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name}, {person.Age}");
            }
            Console.WriteLine(new string('-', 10));

            foreach (var person in people)
            {
                person.Name += " (renamed)";
                person.Update();
                Console.WriteLine($"{person.Name}, {person.Age}");
            }
            Console.WriteLine(new string('-', 10));

            var adultPeople = people.GetAdult();
            foreach (var person in adultPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Age}");
            }
            Console.WriteLine(new string('-', 10));

            Console.WriteLine(people.ToJson());
            Console.WriteLine(new string('-', 10));
        }
    }
}