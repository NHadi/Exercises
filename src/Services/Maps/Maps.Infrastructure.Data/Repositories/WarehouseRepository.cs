using EntVisionLibraries.EntityFramework.Common;
using Maps.Domain.WarehouseAggregate;
using Maps.Domain.WarehouseAggregate.Enums;
using Maps.Domain.WarehouseAggregate.Extensions;
using Maps.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouses.Infrastructure.Data.Repositories
{
    public class WarehouseRepository : EntityFrameworkRepository<Warehouse, MapContext>, IWarehouseRepository, IDisposable
    {        
        public List<Warehouse> FilterWarehouseByCriteria(FilterCriteriaWarehouseType filterCriteria, string[] keywords)
        {
            var result = Get(includeProperties: "Location")                
                .FilterByCriteria(filterCriteria, keywords);

            return result.ToList();
        }

        public Task<List<Warehouse>> FilterWarehouseByCriteriaAsync(FilterCriteriaWarehouseType filterCriteria, string[] keywords)
        {
            throw new NotImplementedException();
        }
    }
}
