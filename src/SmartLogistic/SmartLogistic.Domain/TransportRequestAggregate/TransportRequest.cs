using EntVisionLibraries.Common.Domain;
using EntVisionLibraries.Common.Interface;
using Newtonsoft.Json;
using SmartLogistic.Domain.MapAggregate;
using SmartLogistic.Domain.MapAggregate.ValueObjects;
using SmartLogistic.Domain.TransportRequestAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate
{
    public class TransportRequest : Entity<Guid>, IAggregateRoot
    {
        public TransportRequest()
        {
            // required by EF
        }

        public TransportRequest(AddressDetail pickup, AddressDetail delivery)
        {
            Pickup = pickup;
            Delivery = delivery;            
        }

        public string Code { get; set; }        
        public AddressDetail Pickup { get; set; }        
        public AddressDetail Delivery { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string PreferredDeliveryTime { get; set; }
        public string PackingDetails { get; set; }
        public string Vehicle { get; set; }
        public string ScheduledDeliveryTime { get; set; }
        public MapDirection RouteDetail { get; set; }
        public string Status { get; set; }

        public void AssignedVehicle(string vehicle)
         => Vehicle = vehicle;
        //public void AssignedVehicle(string name, VehicleArea vehicleArea, string description)
        // => Vehicle = new Vehicle(name, vehicleArea, description);
        //public void AssignedStatus(JobStatus status)
        // => Status = status;
        public void AssignedStatus(string status)
         => Status = status;
        public void ScheduledDilvery(string time)
            => ScheduledDeliveryTime = time;
        public void AssignedRoute(Map start, Map end, Direction direction, List<MapDirectionStep> steps)
         => RouteDetail = new MapDirection(start, end, direction, steps);
        public void AssignedRoute(MapDirection direction)
         => RouteDetail = direction;
    }
}
