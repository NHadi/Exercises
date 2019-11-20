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
    public interface IMapContext
    {
        DbSet<Warehouse> Warehouse { get; }
        DbSet<Map> Map { get;  }
        DbSet<MapDirection> MapDirection { get; }
        DbSet<MapDirectionStep> MapDirectionStep { get; }
        DbSet<Delivery> Delivery { get; }
        int SaveChanges();
    }
}
