using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text.Json.Serialization;

namespace RichDomainNET.Abstractions
{
    public class RichDomainModel : IRichDomainModel
    {
        [JsonIgnore]
        [NotMapped]
        public RichDomainModelContext RichDomainModelContext { get; private set; }

        internal void SetContext(IDbConnection connection)
        {
            RichDomainModelContext = new RichDomainModelContext(connection.ConnectionString);
        }
    }
}
