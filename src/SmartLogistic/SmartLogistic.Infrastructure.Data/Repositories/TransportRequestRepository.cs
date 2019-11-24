using EntVisionLibraries.EntityFramework.Common;
using SmartLogistic.Domain.TransportRequestAggregate;
using SmartLogistic.Domain.TransportRequestAggregate.Enums;
using SmartLogistic.Domain.TransportRequestAggregate.Extensions;
using SmartLogistic.Domain.TransportRequestAggregate.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Infrastructure.Data.Repositories
{
    public class TransportRequestRepository : EntityFrameworkRepository<TransportRequest, SmartLogisticContext>, ITransportRequestRepository
    {
        public IEnumerable<TransportRequest> FindTransportRequest(FilterTransportType filterCriteria, string keywords = null)
        =>  Get(includeProperties: "RouteDetail")
                    .FilterByCriteria(filterCriteria, keywords)                    
                .ToList();

        public async Task<DeliveryTime> GetDeliveryTime(DeliveryTimeType deliveryTimeType)
        {
            string keyword = string.Empty;
            var qry = context.DeliveryTime.AsQueryable();
            switch (deliveryTimeType)
            {
                case DeliveryTimeType.Morning:
                    keyword = "Morning";
                    break;
                case DeliveryTimeType.Afternoon:
                    keyword = "Afternoon";
                    break;
                case DeliveryTimeType.Night:
                    keyword = "Night";
                    break;
                default:
                    break;
            }

            return await qry.Where(x => x.Name.Contains(keyword)).FirstOrDefaultAsync();
        }
    }
}
