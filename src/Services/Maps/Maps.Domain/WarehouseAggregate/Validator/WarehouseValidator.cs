using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.WarehouseAggregate.Validator
{
    public class WarehouseValidator : AbstractValidator<Warehouse>
    {
        public WarehouseValidator()
        {
            RuleFor(x => x.Location).NotNull();
            RuleFor(x => x.Address).NotNull();
        }
    }
}
