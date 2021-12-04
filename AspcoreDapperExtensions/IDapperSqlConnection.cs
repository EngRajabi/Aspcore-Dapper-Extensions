using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace AspcoreDapperExtensions
{
    public interface IDapperSqlConnection : IDisposable
    {
        IDbConnection Connection { get; }

        Task OpenConnection(CancellationToken cancellationToken);
        Task CloseConnection(CancellationToken cancellationToken);
    }
}