using EntVisionLibraries.Common.Domain;
using System;

namespace SmartLogistic.Domain.TransportRequestAggregate
{
    public class JobStatus : Entity<Guid>
    {
        public JobStatus()
        {

        }
        public JobStatus(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}