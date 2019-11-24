using EntVisionLibraries.Common.Enums;
using EntVisionLibraries.Common.Utilities.Interfaces;
using SmartLogistic.Domain.MapAggregate.Interfaces;
using SmartLogistic.Domain.TransportRequestAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.MapAggregate.Services
{
    public class MapManagementService : IMapManagementService
    {        
        public TransportRequest GetGeocoding(string address)
        {
            var geocodingResponse = new HttpRequestUtlitiy<TransportRequest>().Request(HttpRequestType.GET, $"http://localhost:59810/api/TransportManagement/TrackJob?code=T01");
            return geocodingResponse;
        }

        public Map GetGeocoding(string lat, string lng)
        {
            return new Map();
        }
    }
}
