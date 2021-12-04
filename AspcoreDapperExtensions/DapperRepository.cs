using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace AspcoreDapperExtensions
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        protected readonly IDapperSqlConnection DapperProvider;
        protected string TableName = nameof(T);
        protected string TablePk = "Id";

        public DapperRepository(IDapperSqlConnection dapperProvider)
        {
            DapperProvider = dapperProvider;
        }

        public virtual async Task<T> Get(int Id)
        {
            var query = $"SELECT * FROM {TableName} WHERE {TablePk} = @Id";
            return await DapperProvider.Connection.QuerySingleOrDefaultAsync<T>(query, new { Id = Id });
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var query = $"SELECT * FROM {TableName}";
            return await DapperProvider.Connection.QueryAsync<T>(query);
        }
        
    }
}