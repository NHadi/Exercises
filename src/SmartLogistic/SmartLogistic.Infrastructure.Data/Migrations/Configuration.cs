namespace SmartLogistic.Infrastructure.Data.Migrations
{
    using SmartLogistic.Domain.TransportRequestAggregate;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartLogistic.Infrastructure.Data.SmartLogisticContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SmartLogistic.Infrastructure.Data.SmartLogisticContext context)
        {
            #region TransportRequest

            if (!context.JobStatus.Any())
            {
                var defaultJobStatus = new List<JobStatus>
            {
                new JobStatus("Pending"),
                new JobStatus("Assigned"),
                new JobStatus("Routed ")
            };
                context.JobStatus.AddRange(defaultJobStatus);
            }

            if (!context.VehicleArea.Any())
            {
                var defaultVehicleArea = new List<VehicleArea>
                {
                    new VehicleArea("Air", "Air Shipment"),
                    new VehicleArea("Rail", "Rail Shipment"),
                    new VehicleArea("Freight", "Freight Shipment"),
                    new VehicleArea("Ocean", "Ocean Shipment"),
                };
                context.VehicleArea.AddRange(defaultVehicleArea);
            }

            if (!context.DeliveryTime.Any())
            {
                var defaultDeliveryTime = new List<DeliveryTime>
                {
                    new DeliveryTime("Morning"),
                    new DeliveryTime("Afternoon"),
                    new DeliveryTime("Night ")
                };
                context.DeliveryTime.AddRange(defaultDeliveryTime);
            }


            
            #endregion

            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
