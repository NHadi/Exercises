using EntVisionLibraries.EntityFramework.Common.UnitTests;
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
    
    public class TestMapContext
    {
        public TestMapContext()
        {
            Warehouse = new TestDbSet<Warehouse>();
            Map = new TestDbSet<Map>();
            Delivery = new TestDbSet<Delivery>();
            MapDirection = new TestDbSet<MapDirection>();
            MapDirectionStep = new TestDbSet<MapDirectionStep>();
        }

        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<MapDirection> MapDirection { get; set; }
        public virtual DbSet<MapDirectionStep> MapDirectionStep { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            this.SaveChangesCount++;
            return 1;
        }
    }
}
