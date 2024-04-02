using Newtonsoft.Json;

using System.ComponentModel.DataAnnotations.Schema;

namespace RichDomainNET.Abstractions
{
    [NotMapped]
    public abstract class RichViewModel
    {
        [JsonIgnore]
        [NotMapped]
        protected RichDomainModelContext RichDomainModelContext { get; private set; }

        [JsonIgnore]
        public object EntityId { get; private set; }        

        internal void SetContext(RichDomainModelContext richDomainModelContext, object entityId)
        {
            EntityId = entityId;
            RichDomainModelContext = richDomainModelContext;
        }

        public abstract void Initialize();
    }
}
