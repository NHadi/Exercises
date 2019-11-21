using Maps.WebApplication.Models.MapDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.WebApplication.Models.WarehouseDTOs
{
    public class WarehouseResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public MapResponse Location { get; set; }
    }
}