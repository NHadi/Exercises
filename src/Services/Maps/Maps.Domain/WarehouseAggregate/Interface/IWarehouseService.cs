using EntVisionLibraries.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate.Interface
{
    public interface IWarehouseService
    {
        EntityValidationResult<Warehouse> AddWarehouse(Warehouse warehouse);
    }
}
