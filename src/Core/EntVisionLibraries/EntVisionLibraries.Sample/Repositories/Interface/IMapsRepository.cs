using EntVisionLibraries.Common.Interface;
using EntVisionLibraries.EntityFramework.Common;
using EntVisionLibraries.Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntVisionLibraries.Sample.Repositories.Interface
{
    public interface IMapsRepository : IRepository<Maps>, IDisposable
    {
        IEnumerable<Maps> GetMapByTitle(string keyword);
    }
}