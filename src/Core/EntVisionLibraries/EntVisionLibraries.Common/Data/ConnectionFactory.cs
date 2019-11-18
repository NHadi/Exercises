using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection(string connectionString)
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var conn = factory.CreateConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}
