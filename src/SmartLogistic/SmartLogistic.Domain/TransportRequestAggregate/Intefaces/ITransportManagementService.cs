using EntVisionLibraries.Common.Domain;
using SmartLogistic.Domain.TransportRequestAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate.Intefaces
{
    public interface ITransportManagementService
    {        
        Task<EntityValidationResult<TransportRequest>> AddTransportRequest(TransportRequest data);
        List<TransportRequest> FindTransportRequest(FilterTransportType filterCriteria, string keywords = null);
    }
}
