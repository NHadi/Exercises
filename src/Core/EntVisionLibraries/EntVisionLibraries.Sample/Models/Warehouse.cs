using EntVisionLibraries.Common;
using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntVisionLibraries.Sample.Models
{
    public class Warehouse : Entity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }        

    }
}