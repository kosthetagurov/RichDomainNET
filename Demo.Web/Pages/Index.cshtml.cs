using Demo.Web.Data;
using Demo.Web.Data.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            var country = new Country()
            {
                Name = "Russia"
            };
            _context.Countries.Add(country);
            _context.SaveChanges();
            
            var region = country.AddRegion(new Region()
            {
                Name = "North Osetia",
            });
            
            var city = region.AddCity(new City()
            {
                Name = "Vladikavkaz"
            });            
        }
    }
}