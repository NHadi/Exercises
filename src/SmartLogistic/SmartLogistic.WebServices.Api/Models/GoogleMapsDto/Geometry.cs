using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLogistic.WebServices.Api.Models.GoogleMapsDto
{
    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }

    }
}