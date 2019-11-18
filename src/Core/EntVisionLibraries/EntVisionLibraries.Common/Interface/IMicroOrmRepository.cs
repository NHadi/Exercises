using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.Interface
{
    public interface IMicroOrmRepository<TEntity>  where TEntity: class
    {
        IEnumerable<TEntity> Query(string query = null, object param = null);
        Task<IEnumerable<TEntity>> QueryAsync(string query = null, object param = null);
        void Execute(string query = null, object param = null);
        Task ExecuteAsync(string query = null, object param = null);
    }
}
