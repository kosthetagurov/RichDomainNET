using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RichDomainNET.Abstractions
{
    public abstract class RichDomainModel : IRichDomainModel
    {
        [NotMapped]
        [JsonIgnore]
        public RichDomainModelContext RichDomainModelContext { get; private set; }
        [NotMapped]
        internal object EntityId { get; private set; }

        internal void SetContext(IDbConnection connection, object entityId)
        {
            EntityId = entityId;
            RichDomainModelContext = new RichDomainModelContext(connection.ConnectionString);
        }
    }
}
