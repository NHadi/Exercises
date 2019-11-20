using Maps.Domain.MapsAggregate;
using Maps.Domain.WarehouseAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Builders
{
    public class WarehouseBuilder
    {
        private Warehouse _warehouse;
        public Guid TestId => new Guid("18d45a61-3f63-4cda-a3e2-8ab2c059a6ec");
        public string TestsName => "Test Name";
        public string TestAddress => "Test Address"; 

        public Map TestMap{ get;}
        public Warehouse Build()
        => _warehouse;
        public Warehouse WithDefaultValues()
        {
            _warehouse = new Warehouse(TestsName, TestAddress, new MapBuilder().WithDefaultValues());
            return _warehouse;
        }
        public Warehouse WithNoLocation()
        {
            _warehouse = new Warehouse(TestsName, TestAddress, new Map());
            return _warehouse;
        }

        public Warehouse WithLocation(Map location)
        {
            _warehouse = new Warehouse(TestsName, TestAddress, location);
            return _warehouse;
        }
    }
}
