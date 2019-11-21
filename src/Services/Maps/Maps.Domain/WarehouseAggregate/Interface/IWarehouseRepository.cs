using EntVisionLibraries.Common;
using EntVisionLibraries.Common.Interface;
using Maps.Domain.WarehouseAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        Task<List<Warehouse>> FilterWarehouseByCriteriaAsync(FilterCriteriaWarehouseType filterCriteria, string[] keywords);
        List<Warehouse> FilterWarehouseByCriteria(FilterCriteriaWarehouseType filterCriteria, string[] keywords);
    }
}
