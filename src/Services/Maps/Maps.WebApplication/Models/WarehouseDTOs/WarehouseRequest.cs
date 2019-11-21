using Maps.WebApplication.Models.MapDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.WebApplication.Models.WarehouseDTOs
{
    public class WarehouseRequest
    {
        public WarehouseRequest()
        {
            Location = new MapRequest();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public MapRequest Location { get; set; }
    }
}