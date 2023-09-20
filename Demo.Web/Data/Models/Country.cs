using RichDomainNET.EntityFrameworkCore;

namespace Demo.Web.Data.Models
{
    public class Country : EfRichDomainModel<ApplicationDbContext>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Region> Regions { get; set; }

        public Region AddRegion(Region region)
        {
            using var dbContext = CreateDbContext((cs) =>
            {
                return new ApplicationDbContext(new ApplicationDbContextOptionsDefaults(cs).GetOptions());
            });

            region.CountryId = this.Id;
            dbContext.Regions.Add(region);
            dbContext.SaveChanges();

            return region;
        }
    }
}
