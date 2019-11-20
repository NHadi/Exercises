using EntVisionLibraries.EntityFramework.Common;
using Maps.Domain.DeliveryAggregate;
using Maps.Domain.DeliveryAggregate.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Infrastructure.Data.Repositories
{
    public class DeliveryRepository : EntityFrameworkRepository<Delivery, MapContext>, IDeliveryRepository, IDisposable
    {
    }
}
