using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate
{
    public class StaticTransportRequest
    {
        public static class JobStatus {
            public static string Pending = "Pending";
            public static string Assigned = "Assigned";
            public static string Routed = "Routed";
        }

        public static class VehicleArea
        {
            public static string Air = "Air";
            public static string Rail = "Rail";
            public static string Freight = "Freight";
            public static string Ocean = "Ocean";
        }

        public static class DeliveryTime
        {
            public static string Morning = "Morning";
            public static string Afternoon = "Afternoon";
            public static string Night = "Night";
        }        
    }
}
