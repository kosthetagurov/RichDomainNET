using Dapper;

using Newtonsoft.Json;

using RichDomainNET.Dapper;
using RichDomainNET.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Demo.Data
{
    public class Product : EfRichDomainModel<ApplicationDbContext>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}
