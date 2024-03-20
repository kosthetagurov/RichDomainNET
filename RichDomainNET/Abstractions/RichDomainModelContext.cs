using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace RichDomainNET.Abstractions
{
    [NotMapped]    
    public sealed class RichDomainModelContext
    {
        [JsonIgnore]
        private readonly Lazy<IDbConnection> _dbConnection;
        [JsonIgnore]
        public IDbConnection Connection => _dbConnection.Value;

        public RichDomainModelContext(IDbConnection connection)
        {
            var connectionString = connection.ConnectionString;

            _dbConnection = new Lazy<IDbConnection>(() =>
            {
                if (connection != null && connection.State == ConnectionState.Closed)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    return connection;
                }
                else
                {
                    throw new Exception("RichDomainModelContext is invalid");
                }                
            });
        }
    }
}
