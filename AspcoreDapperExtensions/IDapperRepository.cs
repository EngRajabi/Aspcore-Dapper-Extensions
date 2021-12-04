using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspcoreDapperExtensions
{
    public interface IDapperRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> Get(int Id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
