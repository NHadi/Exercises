using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.MapsAggregate.Interface
{
    public interface IMapService
    {
        Task<EntityValidationResult<Map>> AddMap(Map map);
        Task<List<Map>> AllMap();
    }
}
