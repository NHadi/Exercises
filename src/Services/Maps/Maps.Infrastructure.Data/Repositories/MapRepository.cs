using EntVisionLibraries.EntityFramework.Common;
using Maps.Domain.MapsAggregate;
using Maps.Domain.MapsAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Infrastructure.Data.Repositories
{
    public class MapRepository : EntityFrameworkRepository<Map, MapDbContext>, IMapRepository, IDisposable
    {
        
    }
}
