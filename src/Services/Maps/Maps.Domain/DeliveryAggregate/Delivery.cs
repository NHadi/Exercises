using EntVisionLibraries.Common;
using Maps.Domain.MapsAggregate;
using Maps.Domain.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.DeliveryAggregate
{
    public class Delivery : Entity<Guid>
    {
        public string Name { get; set; }
        public Map From { get; set; }
        public Map To { get; set; }
        public Warehouse Warehouse { get; set; }

        public string Status { get; set; }
    }
}
