using EntVisionLibraries.Common;
using EntVisionLibraries.Common.Domain;
using Maps.Domain.MapsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate
{
    public class Warehouse : Entity<Guid>
    {
        public Warehouse()
        {
            // required by EF
        }

        public Warehouse(string name, string address, Map location)
        {
            Name = name;
            Address = address;
            Location = location;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public Map Location { get; set; }

        public void SetLocation(string lat, string lng, string title = null , string content = null)
         => Location = new Map().SetLocation (lat, lng, title, content);
        

    }
}
