using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.API
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }
        public int TotalRows { get; }

        public ApiOkResponse(object result, int totalRows = 0, string message = null)
            : base(200, message)
        {
            Result = result;
            TotalRows = totalRows;
        }
    }
}
