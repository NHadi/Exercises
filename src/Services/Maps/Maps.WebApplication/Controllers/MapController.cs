using AutoMapper;
using EntVisionLibraries.Common.API;
using Maps.Domain.MapsAggregate;
using Maps.Domain.MapsAggregate.Interface;
using Maps.WebApplication.Mapping;
using Maps.WebApplication.Models.MapDTOs;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
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
            _mapper = AutoMapperConfiguration.Init();
            _mapService = mapService;
        }
        
        [HttpGet]
        public async Task<IHttpActionResult> GetAsync()
        {

            var response = await _mapService.AllMap();
            var result = _mapper.Map<List<MapResponse>>(response);

            return Ok(new ApiOkResponse(result, result.Count));
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] Models.MapDTOs.MapRequest request)
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
                //Log here
                return BadRequest();
            }

        }       
    }
}
