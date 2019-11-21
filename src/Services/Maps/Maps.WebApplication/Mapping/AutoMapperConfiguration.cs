using AutoMapper;
using Maps.Domain.MapsAggregate;
using Maps.Domain.WarehouseAggregate;
using Maps.WebApplication.Models.MapDTOs;
using Maps.WebApplication.Models.WarehouseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.WebApplication.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.MapDTOs.MapRequest, Map>();
                cfg.CreateMap<MapResponse, Map>();
                cfg.CreateMap<Map, MapResponse>();

                cfg.CreateMap<WarehouseRequest, Warehouse>();
                cfg.CreateMap<WarehouseResponse, Warehouse>();
                cfg.CreateMap<Warehouse, WarehouseResponse>();
            });            

            var mapper = config.CreateMapper();

            return mapper;
        }        
    }
}