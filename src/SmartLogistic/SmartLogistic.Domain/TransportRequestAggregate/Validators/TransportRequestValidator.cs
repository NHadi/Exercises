using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate.Validators
{
    public class TransportRequestValidator : AbstractValidator<TransportRequest>
    {
        public TransportRequestValidator()
        {
            RuleFor(x => x.Pickup).NotNull();
            RuleFor(x => x.Pickup).SetValidator(new AddressDetailValidator());
            RuleFor(x => x.Delivery).NotNull();
            RuleFor(x => x.Delivery).SetValidator(new AddressDetailValidator());
            RuleFor(x => x.PreferredDeliveryTime).NotNull();            
        }
    }
}
