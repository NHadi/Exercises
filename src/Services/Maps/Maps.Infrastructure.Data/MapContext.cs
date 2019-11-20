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
    public class MapContext : DbContext
    {
        public MapContext() : base("MapContext")
        {

        }

        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<MapDirection> MapDirection { get; set; }
        public virtual DbSet<MapDirectionStep> MapDirectionStep { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
    }
}
