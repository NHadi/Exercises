using EntVisionLibraries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntVisionLibraries.Sample.Models
{
    public class Delivery : Entity<Guid>
    {
        public string Name { get; set; }
        public Maps From { get; set; }
        public Maps To { get; set; }
        public Warehouse Warehouse { get; set; }
        
        public string Status{ get; set; }
    }
}