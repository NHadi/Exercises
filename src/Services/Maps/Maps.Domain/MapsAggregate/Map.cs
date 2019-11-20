using EntVisionLibraries.Common;
using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.MapsAggregate
{
    public class Map : Entity<Guid>
    {
        public Map()
        {

        }

        public Map(string title, string content, string lat, string lng)
        {
            Title = title;
            Content = content;
            Latitude = lat;
            Longitude = lng;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public Map SetLocation(string lat, string lng, string title = null, string content = null)
            => new Map { Id = Guid.NewGuid(), Latitude = lat, Longitude = lng, Title = title, Content = content };
    }
}
