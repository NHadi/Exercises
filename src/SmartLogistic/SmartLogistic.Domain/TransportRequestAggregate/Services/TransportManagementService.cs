using EntVisionLibraries.Common.Domain;
using EntVisionLibraries.Common.Enums;
using EntVisionLibraries.Common.Utilities.Interfaces;
using SmartLogistic.Domain.MapAggregate;
using SmartLogistic.Domain.TransportRequestAggregate.Enums;
using SmartLogistic.Domain.TransportRequestAggregate.Intefaces;
using SmartLogistic.Domain.TransportRequestAggregate.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate.Services
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

        public List<TransportRequest> FindTransportRequest(FilterTransportType filterCriteria, string keywords = null)
        {
            try
            {
                var data = _transportRequestRepository.FindTransportRequest(filterCriteria, keywords);
                return data.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task JobAssignment()
        {
            var dataPending = await _transportRequestRepository.GetAsync(x => x.Status == "Pending");
            dataPending.ToList().ForEach(item =>
            {
                item.AssignedStatus("Assigned");

                var geocodingDelivery = new HttpRequestUtlitiy<Geocoding>()
                    .Request(HttpRequestType.GET, $"http://localhost:59810/Geocoding?address={item.Delivery}");

                item.Delivery.Latitude = geocodingDelivery.Geometry.Location.Lat;
                item.Delivery.Longitude = geocodingDelivery.Geometry.Location.Lng;

                var geocodingPickup = new HttpRequestUtlitiy<Geocoding>()
                    .Request(HttpRequestType.GET, $"http://localhost:59810/Geocoding?address={item.Pickup}");

                item.Pickup.Latitude = geocodingPickup.Geometry.Location.Lat;
                item.Pickup.Longitude = geocodingPickup.Geometry.Location.Lng;

                item.DeliveryDate = DateTime.Now;
                item.AssignedVehicle("Vehicle Default");

                _transportRequestRepository.Update(item);
                _transportRequestRepository.SaveAsync();                                
            });
            
        }

        public async Task RouteOptimisation()
        {
            var dataPending = await _transportRequestRepository.GetAsync(x => x.Status == "Assigned");
            dataPending.ToList().ForEach(item =>
            {
                item.AssignedStatus("Routed");

                _transportRequestRepository.Update(item);
                _transportRequestRepository.SaveAsync();
            });

            
        }
    }
}