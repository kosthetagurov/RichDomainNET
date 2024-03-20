using RichDomainNET.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Data
{
    public class Person : EfRichDomainModel<ApplicationDbContext>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
