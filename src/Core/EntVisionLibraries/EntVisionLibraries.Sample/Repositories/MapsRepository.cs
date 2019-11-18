using EntVisionLibraries.EntityFramework.Common;
using EntVisionLibraries.Sample.Models;
using EntVisionLibraries.Sample.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntVisionLibraries.Sample.Repositories
{
    public class MapsRepository : EntityFrameworkRepository<Maps, SmartLogisticContext>, IMapsRepository, IDisposable
    {
        public IEnumerable<Maps> GetMapByTitle(string keyword)
            => context.Maps.Where(x => x.Title.Contains(keyword)).ToList();
    }

}