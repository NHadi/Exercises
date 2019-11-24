using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLogistic.Domain.MapAggregate
{
    public class Geometry
    {
        public Geometry(Location location)
        {
            Location = location;
        }
        public Location Location { get; set; }
        public string LocationType { get; set; }
        public Viewport Viewport { get; set; }

    }
}