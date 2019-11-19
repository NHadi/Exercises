using Maps.Domain.DeliveryAggregate;
using Maps.Domain.MapsAggregate;
using Maps.Domain.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Infrastructure.Data
{
    public class MapDbContext : DbContext
    {
        public MapDbContext() : base("MapContext")
        {

        }

        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Map> Map { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
    }
}
