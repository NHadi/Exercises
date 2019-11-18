using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntVisionLibraries.Sample.Models
{
    public class SmartLogisticContext : DbContext
    {
        public SmartLogisticContext() : base("name=SmartLogisticConnectionString")
        {

        }

        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Maps> Maps { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
    }
}