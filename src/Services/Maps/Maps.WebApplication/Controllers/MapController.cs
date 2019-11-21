using AutoMapper;
using EntVisionLibraries.Common.API;
using Maps.Domain.MapsAggregate;
using Maps.Domain.MapsAggregate.Interface;
using Maps.WebApplication.Mapping;
using Maps.WebApplication.Models.MapDTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Maps.WebApplication.Controllers
{
    [RoutePrefix("api/Map")]
    public class MapController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IMapService _mapService;
        public MapController(IMapService mapService)
        {
            _mapper = MapMapperConfiguration.Init();
            _mapService = mapService;
        }
        // GET api/values
        public IHttpActionResult Get()
        {
            var response = new MapResponse
            {
                Title = "Title",
                Content = "Content",
                Latitude = "10",
                Longitude = "20"
            };
            

            var result = _mapper.Map<Map>(response);

            return Ok(new ApiOkResponse(result, 1));
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public async System.Threading.Tasks.Task<IHttpActionResult> PostAsync([FromBody]Models.MapDTOs.MapRequest request)
        {
            try
            {
                var data = _mapper.Map<Map>(request);

                var response = await _mapService.AddMap(data);

                if (response.IsValid == false)
                {
                    return Ok(new ApiBadRequestResponse(400, response.Errors));
                }

                var result = _mapper.Map<MapResponse>(response.Object);

                return Ok(new ApiOkResponse(result, 1));
            }
            catch (Exception ex)
            {

                throw ex;
            }

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
