using EntVisionLibraries.Common.API;
using SmartLogistic.Domain.MapAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartLogistic.WebServices.Api.Controllers
{
    [RoutePrefix("api/Maps")]
    public class MapsController : ApiController
    {

        private readonly IMapManagementService _mapManagementService;
        public MapsController(IMapManagementService mapManagementService)
        {
            _mapManagementService = mapManagementService;
        }

        [HttpGet]
        [Route("GeocodingByAddress")]
        public IHttpActionResult Geocoding(string address)
        {
            try
            {
                var response = _mapManagementService.GetGeocoding(address);

                return Ok(new ApiOkResponse(response, response != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                //Log here
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GeocodingByLatLng")]
        public IHttpActionResult Geocoding(double lat, double lng)
        {
            try
            {
                var response = _mapManagementService.GetGeocoding(lat, lng);

                return Ok(new ApiOkResponse(response, response != null ? 1 : 0));
            }
            catch (Exception ex)
            {
                //Log here
                return BadRequest();
            }
        }
    }
}
