using Maps.Domain.WarehouseAggregate;
using Maps.Infrastructure.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTests.Builders;
using Warehouses.Infrastructure.Data.Repositories;

namespace IntegrationTests.WarehouseRepositoryTest
{
    [TestClass]
    public class NonQueryTests
    {
        private readonly WarehouseBuilder warehouseBuilder = new WarehouseBuilder();

        private Mock<IWarehouseRepository> _mockWarehouseRepository;
        public NonQueryTests()
        {
            _mockWarehouseRepository = new Mock<IWarehouseRepository>();
        }

        [TestMethod]
        public void CreateWarehouse()
        {

            var mockSet = new Mock<DbSet<Warehouse>>();

            var mockContext = new Mock<MapContext>();
            mockContext.Setup(m => m.Warehouse).Returns(mockSet.Object);

            var service = new WarehouseService(_mockWarehouseRepository.Object);
            service.AddWarehouse(warehouseBuilder.WithDefaultValues());

            _mockWarehouseRepository.Verify(x => x.Save(), Times.Once);
        }
    }
}
