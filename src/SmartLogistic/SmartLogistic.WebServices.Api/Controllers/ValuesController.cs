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
    public class ValuesController : ApiController
    {

        private readonly IMapManagementService _mapManagementService;
        public ValuesController(IMapManagementService mapManagementService)
        {
            _mapManagementService = mapManagementService;
        }

        [HttpGet]
        [Route("Geocoding")]
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


        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
