﻿using EntVisionLibraries.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.MapAggregate.Interfaces
{
    public interface IMapRepository : IRepository<MapDirection>, IAggregateRoot
    {
    }
}
