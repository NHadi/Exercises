using EntVisionLibraries.Common.Domain;
using Maps.Domain.WarehouseAggregate;
using Maps.Domain.WarehouseAggregate.Interface;
using Maps.Domain.WarehouseAggregate.Validator;
using Maps.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.WebApplication.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly WarehouseValidator _validator = new WarehouseValidator();
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public WarehouseService(TestMapContext testMapDbContext)
        {

        }

        public EntityValidationResult<Warehouse> AddWarehouse(Warehouse warehouse)
        {
            try
            {
                var result = new EntityValidationResult<Warehouse>();
                var validationResult = _validator.Validate(warehouse);

                result.IsValid = validationResult.IsValid;
                result.Object = warehouse;

                if (validationResult.IsValid)
                {
                    _warehouseRepository.Create(warehouse);
                    _warehouseRepository.Save();
                }
                else
                {
                    result.Errors = validationResult.Errors.Select(x => new EntityValidationFailure { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }).ToList();
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}