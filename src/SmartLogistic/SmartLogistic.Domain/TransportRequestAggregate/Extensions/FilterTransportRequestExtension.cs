using SmartLogistic.Domain.TransportRequestAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate.Extensions
{
    public static class FilterTransportRequestExtension
    {
        public static IEnumerable<TransportRequest> FilterByCriteria(this IEnumerable<TransportRequest> data, FilterTransportType filterCriteria, string keywoard)
        {
            var qry = data.AsQueryable();
            switch (filterCriteria)
            {
                case FilterTransportType.Code:
                    qry = data.FilterByCode(keywoard).AsQueryable();
                    break;
                case FilterTransportType.Status:
                    qry = data.FilterByStatus(keywoard).AsQueryable();
                    break;
                case FilterTransportType.Vehicle:
                    qry = data.FilterByVehicle(keywoard).AsQueryable();
                    break;
                case FilterTransportType.DeliveryTime:
                    qry = data.FilterByDeliveryTime(keywoard).AsQueryable();
                    break;
                case FilterTransportType.PickupAddress:
                    qry = data.FilterByPickupAddress(keywoard).AsQueryable();
                    break;
                default:
                    break;
            }

            return qry;
        }

        public static IEnumerable<TransportRequest> FilterByCode(this IEnumerable<TransportRequest> data, string keyword)
        => data.Where(x => x.Code == keyword);

        public static IEnumerable<TransportRequest> FilterByStatus(this IEnumerable<TransportRequest> data, string keyword)
        => data.Where(x => x.Status == keyword);

        public static IEnumerable<TransportRequest> FilterByVehicle(this IEnumerable<TransportRequest> data, string keyword)
        => data.Where(x => x.Vehicle == keyword);

        public static IEnumerable<TransportRequest> FilterByDeliveryTime(this IEnumerable<TransportRequest> data, string keyword)
        => data.Where(x => x.PreferredDeliveryTime == keyword);

        public static IEnumerable<TransportRequest> FilterByPickupAddress(this IEnumerable<TransportRequest> data, string keyword)
        => data.Where(x => x.Pickup.Address.Contains(keyword));

    }
}
