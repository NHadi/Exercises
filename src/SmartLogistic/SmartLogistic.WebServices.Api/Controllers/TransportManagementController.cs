using EntVisionLibraries.Common.API;
using SmartLogistic.Domain.MapAggregate.Interfaces;
using SmartLogistic.Domain.TransportRequestAggregate;
using SmartLogistic.Domain.TransportRequestAggregate.Enums;
using SmartLogistic.Domain.TransportRequestAggregate.Intefaces;
using SmartLogistic.Domain.TransportRequestAggregate.ValueObjects;
using SmartLogistic.WebServices.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SmartLogistic.WebServices.Api.Controllers
{
    [RoutePrefix("api/TransportManagement")]
    public class TransportManagementController : ApiController
    {
        private readonly ITransportManagementService _transportManagementService;
        private readonly IMapManagementService _mapManagementService;
        public TransportManagementController(ITransportManagementService transportManagementService,
            IMapManagementService mapManagementService)
        {
            _transportManagementService = transportManagementService;
            _mapManagementService = mapManagementService;
        }

        [HttpGet]
        [Route("TrackJob")]
        public IHttpActionResult TrackJob(string code)
        {
            try
            {
                var response = _transportManagementService.FindTransportRequest(FilterTransportType.Code, code).FirstOrDefault();

                return Ok(new ApiOkResponse(response, response != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                //Log here
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("JobAssignment")]
        public async Task<IHttpActionResult> JobAssignment()
        {
            try
            {
                await _transportManagementService.JobAssignment();
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("RouteOptimisation")]
        public async Task<IHttpActionResult> RouteOptimisation()
        {
            try
            {
                await _transportManagementService.RouteOptimisation();
                return Ok(new ApiResponse(200));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("AssignJob")]
        public async Task<IHttpActionResult> AssignJob([FromBody] AsssignJobRequest request)
        {
            try
            {
                var pickUp = new AddressDetail(request.PickupAddress);
                var delivery = new AddressDetail(request.DeliveryAddress);                

                var newJob = new TransportRequest(pickUp, delivery)
                {
                    DeliveryDate = DateTime.Now,
                    PreferredDeliveryTime = StaticTransportRequest.DeliveryTime.Morning
                };

                var response = await _transportManagementService.AddTransportRequest(newJob);

                if (response.IsValid == false)
                    return Ok(new ApiBadRequestResponse(400, response.Errors));


                return Ok(new ApiOkResponse(response.Object, response.Object != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                //Log here
                return BadRequest();
            }
        }


    }
}
