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
        public Geocoding GetGeocoding(string address)
        {
            //var geocodingResponse = new HttpRequestUtlitiy<Geocoding>()
            //    .Request(HttpRequestType.GET, $"https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=YOUR_API_KEY");


            var geometry = new Geometry(new Location(37.4267861, -122.0806032));
            var result = new Geocoding(geometry);
            

            return result;
        }

        public Geocoding GetGeocoding(double lat, double lng)
        {
            //var geocodingResponse = new HttpRequestUtlitiy<Geocoding>()
            //    .Request(HttpRequestType.GET, $"https://maps.googleapis.com/maps/api/geocode/json?latlng=40.714224,-73.961452&key=YOUR_API_KEY");

            var geometry = new Geometry(new Location(37.4267861, -122.0806032));
            var result = new Geocoding(geometry);

            return result;
        }
    }
}
