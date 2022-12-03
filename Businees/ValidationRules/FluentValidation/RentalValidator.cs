using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(q => q.CarId).NotEmpty().NotNull();
            RuleFor(q => q.CustomerId).NotEmpty().NotNull();
            RuleFor(q => q.RentDate).NotEmpty().NotNull();

        }
    }
}
