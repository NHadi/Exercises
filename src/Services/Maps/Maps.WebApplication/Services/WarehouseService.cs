using EntVisionLibraries.Common.Domain;
using Maps.Domain.MapsAggregate;
using Maps.Domain.MapsAggregate.Interface;
using Maps.Domain.MapsAggregate.Interfaces;
using Maps.Domain.WarehouseAggregate;
using Maps.Domain.WarehouseAggregate.Enums;
using Maps.Domain.WarehouseAggregate.Interface;
using Maps.Domain.WarehouseAggregate.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        public async Task<EntityValidationResult<Warehouse>> AddWarehouse(Warehouse data)
        {
            try
            {
                var result = new EntityValidationResult<Warehouse>();
                var validationResult = _validator.Validate(data);

                result.IsValid = validationResult.IsValid;
                result.Object = data;

                if (validationResult.IsValid)
                {
                    data.Id = Guid.NewGuid();

                    _warehouseRepository.Create(data);
                    await _warehouseRepository.SaveAsync();
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


        public List<Warehouse> FindWarehouse(FilterCriteriaWarehouseType filterCriteria, string[] keywords = null)
        {
            try
            {
                var data = _warehouseRepository.FilterWarehouseByCriteria(filterCriteria, keywords);

                return data.ToList();
            }
            catch (Exception ex)
            {
                //log here
                throw ex;
            }
        }
    }
}