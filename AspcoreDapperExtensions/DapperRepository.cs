using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace AspcoreDapperExtensions
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        private readonly IDapperSqlConnection _dapperProvider;
        protected string TableName = nameof(T);
        protected string TablePk = "Id";

        public DapperRepository(IDapperSqlConnection dapperProvider)
        {
            _dapperProvider = dapperProvider;
        }

        public IDapperSqlConnection DapperProvider => _dapperProvider;

        public virtual async Task<T> Get(int Id)
        {
            var query = $"SELECT * FROM {TableName} WHERE {TablePk} = @Id";
            return await _dapperProvider.Connection.QuerySingleOrDefaultAsync<T>(query, new { Id = Id });
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var query = $"SELECT * FROM {TableName}";
            return await _dapperProvider.Connection.QueryAsync<T>(query);
        }

    }
}