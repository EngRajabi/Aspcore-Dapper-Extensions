using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace AspcoreDapperExtensions
{
    public class DapperSqlConnection : IDapperSqlConnection
    {
        private readonly string _connectionString;
        private SqlConnection _dbConnection;

        public DapperSqlConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_dbConnection == null)
                    _dbConnection = new SqlConnection(_connectionString);

                return _dbConnection;
            }
        }

        public async Task OpenConnection(CancellationToken cancellationToken)
        {
            await _dbConnection.OpenAsync(cancellationToken);
        }

        public async Task CloseConnection(CancellationToken cancellationToken)
        {
            _dbConnection.Close();
        }

        public void Dispose()
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();
             
            _dbConnection?.Dispose();
        }
    }
}