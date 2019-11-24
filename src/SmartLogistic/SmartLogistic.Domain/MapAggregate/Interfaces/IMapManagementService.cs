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
        Geocoding GetGeocoding(string address);
        Geocoding GetGeocoding(double lat, double lng);
    }
}
