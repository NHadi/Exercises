using AutoMapper;
using Maps.Domain.MapsAggregate;
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MapRequest, Map>());
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}