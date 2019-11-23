using EntVisionLibraries.Common.Domain;
using EntVisionLibraries.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.MapAggregate
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
       
    }
}
