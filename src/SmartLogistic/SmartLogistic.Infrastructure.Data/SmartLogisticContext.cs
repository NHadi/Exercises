using SmartLogistic.Domain.MapAggregate;
using SmartLogistic.Domain.TransportRequestAggregate;
using System.Data.Entity;

namespace SmartLogistic.Infrastructure.Data
{
    public class SmartLogisticContext :  DbContext
    {
        public SmartLogisticContext() : base("SmartLogisticConection")
        {            
        }
        #region Domain Maps
        public virtual DbSet<MapLocation> MapLocation { get; set; }
        public virtual DbSet<MapDirection> MapDirection { get; set; }
        public virtual DbSet<MapDirectionStep> MapDirectionStep { get; set; }
        #endregion

        #region Domain TransportRequest
        public virtual DbSet<TransportRequest> TransportRequest { get; set; }
        public virtual DbSet<DeliveryTime> DeliveryTime { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleArea> VehicleArea { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        
        #endregion
    }
}
