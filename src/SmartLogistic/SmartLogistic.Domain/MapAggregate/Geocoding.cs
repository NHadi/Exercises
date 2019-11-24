using System.Collections.Generic;

namespace SmartLogistic.Domain.MapAggregate
{
    public class Geocoding
    {
        public Geocoding(Geometry geometry)
        {
            Geometry = geometry;
        }


        public List<AddressComponent> AddressComponents { get; set; }
        public string Formatedaddress { get; set; }
        public Geometry Geometry { get; set; }
        public string PlaceId { get; set; }
        public PlusCode PlusCode { get; set; }
        public List<string> Types { get; set; }

        public void AddAddressComponent(string longName, string shortName)
        {
            AddressComponents.Add(new AddressComponent(longName, shortName));
        }
    }
}