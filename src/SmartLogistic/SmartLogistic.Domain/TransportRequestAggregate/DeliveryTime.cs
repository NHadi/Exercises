using EntVisionLibraries.Common.Domain;
using System;

namespace SmartLogistic.Domain.TransportRequestAggregate
{
    public class DeliveryTime : Entity<Guid>
    {
        public DeliveryTime(string name)
        {
            Name = name;
        }
        public string Name { get; set; }        
    }
}