using System.Data;

namespace RichDomainNET.Abstractions
{
    public sealed class RichDomainModelContext
    {
        public IDbConnection Connection { get; }

        public RichDomainModelContext(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
