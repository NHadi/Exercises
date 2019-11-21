using FluentValidation;
using Maps.Domain.MapsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate.Validator
{
    public class MapValidator : AbstractValidator<Map>
    {
        public MapValidator()
        {
            RuleFor(x => x.Latitude).NotNull();
            RuleFor(x => x.Longitude).NotNull();
        }
    }
}
