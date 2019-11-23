using FluentValidation;
using Maps.Domain.WarehouseAggregate.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maps.Domain.DeliveryAggregate.Validator
{
    public class DeliveryValidator : AbstractValidator<Delivery>
    {
        public DeliveryValidator()
        {
            RuleFor(x => x.Code).NotNull();
            RuleFor(x => x.Warehouse).NotNull();
            RuleFor(x => x.Warehouse).SetValidator(new WarehouseValidator());
            RuleFor(x => x.Destination).NotNull();
            RuleFor(x => x.Destination).SetValidator(new MapValidator());
        }
    }

}
