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
        public string ConnectionString { get; set; }

        public RichDomainModelContext(string connectionString)
        {            
            ConnectionString = connectionString;
        }
    }
}
