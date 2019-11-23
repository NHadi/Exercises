using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.DeliveryAggregate.Interface
{
    public interface IDeliveryService 
    {
        Task<EntityValidationResult<Delivery>> SendJob(Delivery data);
        Task<Delivery> TrackJob(string code);
    }
}
