using EntVisionLibraries.Common.Domain;
using Maps.Domain.WarehouseAggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate.Interface
{
    public interface IWarehouseService
    {
        Task<EntityValidationResult<Warehouse>> AddWarehouse(Warehouse warehouse);
        List<Warehouse> FindWarehouse(FilterCriteriaWarehouseType filterCriteria, string[] keywords = null);
    }
}
