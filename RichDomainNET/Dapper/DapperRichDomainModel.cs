using RichDomainNET.Abstractions;

using System.Data;

namespace RichDomainNET.Dapper
{
    public class DapperRichDomainModel : RichDomainModel
    {
        public IDbConnection GetConnection(Func<string, IDbConnection> func)
        {
            return func(Context.Connection.ConnectionString);
        }
    }
}
