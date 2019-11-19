using EntVisionLibraries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate
{
    public class Warehouse : Entity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }

    }
}
