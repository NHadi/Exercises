using AutoMapper;
using EntVisionLibraries.Common.API;
using Maps.Domain.WarehouseAggregate.Interface;
using Maps.WebApplication.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Maps.Domain.WarehouseAggregate.Enums;
using Maps.Domain.WarehouseAggregate;
using Maps.WebApplication.Models.WarehouseDTOs;

namespace Maps.WebApplication.Controllers
{
    [RoutePrefix("api/Warehouse")]
    public class WarehouseController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _mapper = AutoMapperConfiguration.Init();
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var response = _warehouseService
                .FindWarehouse(FilterCriteriaWarehouseType.Default);

            return Ok(new ApiOkResponse(response, response.Count));
        }

        [HttpGet]
        [Route("FindByAddress")]
        public IHttpActionResult FindByAddress(string address)
        {

            var response = _warehouseService
                .FindWarehouse(FilterCriteriaWarehouseType.Address, new string[] { address });

            var result = _mapper.Map<List<WarehouseResponse>>(response);

            return Ok(new ApiOkResponse(result, result.Count));
        }

        [HttpGet]
        [Route("FindByLatLng")]
        public IHttpActionResult FindByLatLng(string lat, string lng)
        {

            var response = _warehouseService
                .FindWarehouse(FilterCriteriaWarehouseType.LatLng, new string[] { lat, lng });

            var result = _mapper.Map<List<WarehouseResponse>>(response);

            return Ok(new ApiOkResponse(result, result.Count));
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostAsync([FromBody] WarehouseRequest request)
        {
            try
            {
                var data = _mapper.Map<Warehouse>(request);

                var response = await _warehouseService.AddWarehouse(data);

                if (response.IsValid == false)
                {
                    return Ok(new ApiBadRequestResponse(400, response.Errors));
                }

                var result = _mapper.Map<WarehouseResponse>(response.Object);

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
