using AutoMapper;
using EntVisionLibraries.Common.API;
using Maps.Domain.DeliveryAggregate.Interface;
using Maps.WebApplication.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Maps.WebApplication.Controllers
{
    [RoutePrefix("api/Delivery")]
    public class DeliveryController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IDeliveryService _deliveryService;
        public DeliveryController(IDeliveryService deliveryService)
        {
            _mapper = AutoMapperConfiguration.Init();
            _deliveryService = deliveryService;
        }

        [HttpGet]
        [Route("TrackJob")]
        public async Task<IHttpActionResult> TrackJob(string code)
        {

            var response = await _deliveryService.TrackJob(code);
            //var result = _mapper.Map<List<MapResponse>>(response);

            return Ok(new ApiOkResponse(response, response != null ? 1 : 0));
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> PostAsync([FromBody] Models.MapDTOs.MapRequest request)
        //{
        //    try
        //    {
        //        var data = _mapper.Map<Map>(request);

        //        var response = await _mapService.AddMap(data);

        //        if (response.IsValid == false)
        //        {
        //            return Ok(new ApiBadRequestResponse(400, response.Errors));
        //        }

        //        var result = _mapper.Map<MapResponse>(response.Object);

        //        return Ok(new ApiOkResponse(result, 1));
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log here
        //        return BadRequest();
        //    }

        //}
    }
}
