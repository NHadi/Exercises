using AutoMapper;
using Maps.Domain.MapsAggregate;
using Maps.WebApplication.Models.MapDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maps.WebApplication.Mapping
{
    public static class MapMapperConfiguration
    {
        public static IMapper Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Models.MapDTOs.MapRequest, Map>();
                cfg.CreateMap<MapResponse, Map>();
                cfg.CreateMap<Map, MapResponse>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}