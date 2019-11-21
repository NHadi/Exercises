using EntVisionLibraries.Common.Domain;
using Maps.Domain.MapsAggregate;
using Maps.Domain.MapsAggregate.Interface;
using Maps.Domain.MapsAggregate.Interfaces;
using Maps.Domain.WarehouseAggregate.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Maps.WebApplication.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly MapValidator _validator = new MapValidator();
        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;
        }

        public async Task<EntityValidationResult<Map>> AddMap(Map map)
        {
            try
            {
                var result = new EntityValidationResult<Map>();
                var validationResult = _validator.Validate(map);

                result.IsValid = validationResult.IsValid;
                result.Object = map;

                if (validationResult.IsValid)
                {
                    map.Id = Guid.NewGuid();

                    _mapRepository.Create(map);
                    await _mapRepository.SaveAsync();
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