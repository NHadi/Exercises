using EntVisionLibraries.Common.Domain;
using System;

namespace SmartLogistic.Domain.TransportRequestAggregate
{
    public class Vehicle : Entity<Guid>
    {
        public Vehicle()
        {

        }
        public string Name { get; set; }
        public VehicleArea Area { get;  set; }
        public string Description { get; set; }

        public Vehicle(string name, VehicleArea vehicleArea,  string description)
        {
            Name = name;
            Area = vehicleArea;
            Description = description;
        }
    }
}