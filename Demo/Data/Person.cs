using RichDomainNET.EntityFrameworkCore;

namespace Demo.Data
{
    public class Person : EfRichDomainModel<ApplicationDbContext>
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public void Update()
        {
            using var context = CreateDbContext();
            context.People.Update(this);
            context.SaveChanges();
        }

        // ... Implement your domain logic inside domain object
    }
}
