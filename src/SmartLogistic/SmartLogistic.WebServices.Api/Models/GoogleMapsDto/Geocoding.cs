using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLogistic.WebServices.Api.Models.GoogleMapsDto
{
    public class Geocoding
    {
        public AddressComponent addressComponents { get; set; }
        public string formated_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public PlusCode plusCode { get; set; }
        public List<string> types { get; set; }
    }
}