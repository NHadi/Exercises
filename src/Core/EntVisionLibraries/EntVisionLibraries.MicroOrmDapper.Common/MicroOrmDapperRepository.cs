using Dapper;
using EntVisionLibraries.Common.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.MicroOrmDapper.Common
{
    public abstract class MicroOrmDapperRepository<TEntity> : IMicroOrmRepository<TEntity> 
        where TEntity: class
    {        
        private readonly IDbConnection _connection;

        public MicroOrmDapperRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TEntity> Query(string query = null, object param = null)
        {

            using (_connection)
            {
                _connection.Open();
                return _connection.Query<TEntity>(query, param);
            }
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(string query = null, object param = null)
        {
            using (_connection)
            {
                _connection.Open();
                return await _connection.QueryAsync<TEntity>(query, param);
            }
        }

        public void Execute(string query = null, object param = null)
        {

            using (_connection)
            {
                _connection.Open();
                _connection.Execute(query, param);
            }
        }

        public async Task ExecuteAsync(string query = null, object param = null)
        {
            using (_connection)
            {
                _connection.Open();
                await _connection.ExecuteAsync(query, param);
            }
        }
       
    }
}
