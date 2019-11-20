using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.Domain
{
    public class EntityValidationFailure
    {
        //
        // Summary:
        //     The name of the property.
        public string PropertyName { get; set; }
        //
        // Summary:
        //     The error message
        public string ErrorMessage { get; set; }
    }
}
