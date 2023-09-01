using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace RichDomainNET.Abstractions
{
    public class RichDomainModel : IRichDomainModel
    {
        [NotMapped]
        public RichDomainModelContext Context { get; private set; }

        internal void SetContext(IDbConnection connection)
        {
            Context = new RichDomainModelContext(connection);
        }
    }
}
