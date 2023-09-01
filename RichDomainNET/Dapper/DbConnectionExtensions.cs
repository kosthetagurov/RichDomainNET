using Dapper;

using System.Data;

namespace RichDomainNET.Dapper
{
    public static class DbConnectionExtensions
    {
        public static IEnumerable<T> RichQuery<T>(this IDbConnection dbConnection, string sql) where T : class
        {
            var data = dbConnection.Query<T>(sql);

            SetRichDomainModelContext(dbConnection, data);

            return data;
        }

        private static IEnumerable<DapperRichDomainModel> SetRichDomainModelContext<T>(IDbConnection dbConnection, IEnumerable<T> input) where T : class
        {
            var output = new List<DapperRichDomainModel>();
            foreach (var item in input)
            {
                if (item is DapperRichDomainModel)
                {
                    var convertedInstance = item as DapperRichDomainModel;
                    convertedInstance.SetContext(dbConnection);
                    output.Add(convertedInstance);
                }
            }

            return output;
        }
    }
}
