using EntVisionLibraries.EntityFramework.Common;
using Maps.Domain.WarehouseAggregate;
using Maps.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouses.Infrastructure.Data.Repositories
{
    public class WarehouseRepository : EntityFrameworkRepository<Warehouse, MapDbContext>, IWarehouseRepository, IDisposable
    {

    }
}
