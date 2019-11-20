using EntVisionLibraries.Common.Domain;
using Maps.Domain.MapsAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.MapsAggregate
{
    public class MapDirectionStep : Entity<Guid>
    {
        public MapDirectionStep()
        {
            Location = new Map();            
        }

        public MapDirectionStep(Map location, DirectionProperties direction)
        {
            Location = location;
            Direction = direction;
        }

        public Map Location { get; set; }
        public DirectionProperties Direction { get; set; }

    }
}
