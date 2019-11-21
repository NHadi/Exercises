using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.WebApplication.Models.MapDTOs
{
    public class MapRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}