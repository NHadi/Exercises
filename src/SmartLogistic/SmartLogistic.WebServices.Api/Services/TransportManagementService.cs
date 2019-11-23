using EntVisionLibraries.Common.Domain;
using SmartLogistic.Domain.TransportRequestAggregate;
using SmartLogistic.Domain.TransportRequestAggregate.Enums;
using SmartLogistic.Domain.TransportRequestAggregate.Intefaces;
using SmartLogistic.Domain.TransportRequestAggregate.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SmartLogistic.WebServices.Api.Services
{
    public class TransportManagementService : ITransportManagementService
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly TransportRequestValidator _validator = new TransportRequestValidator();

        public TransportManagementService(ITransportRequestRepository transportRequestRepository)
        {
            _transportRequestRepository = transportRequestRepository;
        }

        public async Task<EntityValidationResult<TransportRequest>> AddTransportRequest(TransportRequest data)
        {
            try
            {                
                var result = new EntityValidationResult<TransportRequest>();
                var validationResult = _validator.Validate(data);

                result.IsValid = validationResult.IsValid;
                result.Object = data;

                if (validationResult.IsValid)
                {
                    data.Id = Guid.NewGuid();

                    _transportRequestRepository.Create(data);
                    await _transportRequestRepository.SaveAsync();
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

        public async Task<List<TransportRequest>> FindTransportRequestAsync(FilterTransportType filterCriteria, string keywords = null)
        {
            try
            {
                var data = await _transportRequestRepository.FindTransportRequestAsync(filterCriteria, keywords);
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        
    }
}