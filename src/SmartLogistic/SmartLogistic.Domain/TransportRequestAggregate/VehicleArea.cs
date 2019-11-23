using EntVisionLibraries.Common.Domain;
using System;

namespace SmartLogistic.Domain.TransportRequestAggregate
{
    public class VehicleArea : Entity<Guid>
    {
        public VehicleArea(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}