using FluentValidation;
using SmartLogistic.Domain.TransportRequestAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogistic.Domain.TransportRequestAggregate.Validators
{
    public class AddressDetailValidator : AbstractValidator<AddressDetail>
    {
        public AddressDetailValidator()
        {
            RuleFor(x => x.Address).NotNull();            
        }
    }
}
