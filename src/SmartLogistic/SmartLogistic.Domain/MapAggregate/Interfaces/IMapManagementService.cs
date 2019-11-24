using SmartLogistic.Domain.TransportRequestAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.MapAggregate.Interfaces
{
    public interface IMapManagementService
    {
        TransportRequest GetGeocoding(string address);
        Map GetGeocoding(string lat, string lng);
    }
}
