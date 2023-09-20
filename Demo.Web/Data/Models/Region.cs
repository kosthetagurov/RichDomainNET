using RichDomainNET.EntityFrameworkCore;

using System.Diagnostics.Metrics;

namespace Demo.Web.Data.Models
{
    public class Region : EfRichDomainModel<ApplicationDbContext>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }

        public City AddCity(City city)
        {
            using var dbContext = CreateDbContext((cs) =>
            {
                return new ApplicationDbContext(new ApplicationDbContextOptionsDefaults(cs).GetOptions());
            });

            city.RegionId = this.Id;
            dbContext.Cities.Add(city);
            dbContext.SaveChanges();

            return city;
        }
    }
}
