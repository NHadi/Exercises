using EntVisionLibraries.Common.Domain;
using Maps.Domain.DeliveryAggregate;
using Maps.Domain.DeliveryAggregate.Interface;
using Maps.Domain.DeliveryAggregate.Validator;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.WebApplication.Services
{
    public class DeliveryService: IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly DeliveryValidator _validator = new DeliveryValidator();
        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<EntityValidationResult<Delivery>> SendJob(Delivery data)
        {
            try
            {
                var result = new EntityValidationResult<Delivery>();
                var validationResult = _validator.Validate(data);

                result.IsValid = validationResult.IsValid;
                result.Object = data;

                if (validationResult.IsValid)
                {
                    data.Id = Guid.NewGuid();

                    _deliveryRepository.Create(data);
                    await _deliveryRepository.SaveAsync();
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

        public async Task<Delivery> TrackJob(string code)
        {
            try
            {
                var data = await _deliveryRepository
                    .GetAsync(x => x.Code == code, 
                        includeProperties: "Warehouse.Location,Destination,Direction.Steps");
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}