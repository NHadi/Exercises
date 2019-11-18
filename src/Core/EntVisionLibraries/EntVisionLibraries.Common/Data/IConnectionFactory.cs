using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.Data
{
    /// <summary>
    /// Provide Conection factory from AppSetting->ConnectionStrings
    /// </summary>
    public interface IConnectionFactory
    {        
        /// <summary>
        /// Get ConnectionString with Name with return of DbConnection
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        IDbConnection GetConnection(string connectionString);
    }
}
