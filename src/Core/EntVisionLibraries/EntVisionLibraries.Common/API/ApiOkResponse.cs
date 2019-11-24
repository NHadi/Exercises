using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.API
{
    public class ApiOkResponse : ApiResponse
    {
        public object Results { get; }
        public int TotalRows { get; }

        public ApiOkResponse(object results, int totalRows = 0, string message = null)
            : base(200, message)
        {
            Results = results;
            TotalRows = totalRows;
        }
    }
}
