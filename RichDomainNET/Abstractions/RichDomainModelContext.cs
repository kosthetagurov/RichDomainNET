using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;

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
