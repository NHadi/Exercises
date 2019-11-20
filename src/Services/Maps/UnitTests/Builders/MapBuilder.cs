using Maps.Domain.MapsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Builders
{
    public class MapBuilder
    {
        private Map _map;
        public Guid TestId => new Guid("18d45a61-3f63-4cda-a3e2-8ab2c059a6ec");
        public string TestsName => "Test Name";
        public string TestAddress => "Test Address";
        public string TestTitle => "Test Title";
        public string TestContent => "Test Content";
        public string TestLat => "Test Lat";
        public string TestLng => "Test Lng";

        public Map Build()
        => _map;
        public Map WithDefaultValues()
        => new Map(TestTitle, TestContent, TestLat, TestLng);

    }

}
