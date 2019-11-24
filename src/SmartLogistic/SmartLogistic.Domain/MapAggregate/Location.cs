using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLogistic.Domain.MapAggregate
{
    public class Location
    {
        public Location(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}