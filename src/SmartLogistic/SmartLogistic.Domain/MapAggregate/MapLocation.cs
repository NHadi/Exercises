using EntVisionLibraries.Common.Domain;
using EntVisionLibraries.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.MapAggregate
{
    public class MapLocation : Entity<Guid>
    {
        public MapLocation()
        {

        }

        public MapLocation(string address, string content, string lat, string lng)
        {
            Address = address;
            Content = content;
            Latitude = lat;
            Longitude = lng;
        }
        public string Address { get; set; }
        public string Content { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
       
    }
}
