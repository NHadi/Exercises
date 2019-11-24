using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntVisionLibraries.Common.Interface;
using SmartLogistic.Domain.TransportRequestAggregate.Enums;

namespace SmartLogistic.Domain.TransportRequestAggregate.Intefaces
{
    public interface ITransportRequestRepository : IRepository<TransportRequest>, IAggregateRoot
    {
        Task<DeliveryTime> GetDeliveryTime(DeliveryTimeType deliveryTimeType);
        IEnumerable<TransportRequest> FindTransportRequest(FilterTransportType filterCriteria, string keywords = null);

    }
}
