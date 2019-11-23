using EntVisionLibraries.EntityFramework.Common;
using SmartLogistic.Domain.MapAggregate;
using SmartLogistic.Domain.MapAggregate.Interfaces;

namespace SmartLogistic.Infrastructure.Data.Repositories
{
    public class MapRepository : EntityFrameworkRepository<MapDirection, SmartLogisticContext>, IMapRepository
    {
    }
}
