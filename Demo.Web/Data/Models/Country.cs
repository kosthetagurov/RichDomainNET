using RichDomainNET.EntityFrameworkCore;

namespace Demo.Web.Data.Models
{
    public class Country : EfRichDomainModel<ApplicationDbContext>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Region> Regions { get; set; }
    }
}
