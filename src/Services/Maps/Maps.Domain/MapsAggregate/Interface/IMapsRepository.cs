using EntVisionLibraries.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.MapsAggregate.Interfaces
{
    public interface IMapRepository : IRepository<Map>, IDisposable
    {
        
    }
}
