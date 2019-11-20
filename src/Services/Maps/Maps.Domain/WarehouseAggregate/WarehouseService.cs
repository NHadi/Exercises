using EntVisionLibraries.Common.Domain;
using Maps.Domain.WarehouseAggregate.Interface;
using Maps.Domain.WarehouseAggregate.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly WarehouseValidator _validator = new WarehouseValidator();
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
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
