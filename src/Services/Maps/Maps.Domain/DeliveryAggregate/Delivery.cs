using EntVisionLibraries.Common;
using EntVisionLibraries.Common.Domain;
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
        public Delivery()
        {
            Warehouse = new Warehouse();
            Destination = new Map();
        }

        public Delivery(string name, Warehouse warehouse, Map dest, MapDirection direction, string status)
        {
            Name = name;
            Warehouse = warehouse;
            Destination = dest;
            Direction = direction;
            Status = status;
        }

        public string Name { get; set; }
        public Warehouse Warehouse { get; set; }
        public Map Destination { get; set; }
        public MapDirection Direction { get; set; }
        public string Status { get; set; }
   
        public void SetDirection(string lat, string lng, string title = null, string content = null)
         => Destination = new Map().SetLocation(lat , lng, title, content);        
        
    }
}
