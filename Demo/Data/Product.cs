using Dapper;

using RichDomainNET.Dapper;

using System.Data.SqlClient;

namespace Demo.Data
{
    public class Product : DapperRichDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public void Update()
        {
            using var connection = GetConnection(cs =>
            {
                return new SqlConnection(cs);
            });

            connection.Execute($"update Products set Name = '{Name}', Price = '{Price}' where Id = '{Id}'");
        }

        // ... Implement your domain logic inside domain object
    }
}
