using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businees.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(q => q.ModelYear).LessThan(DateTime.Now.Year);
            RuleFor(q => q.Description).MinimumLength(3);
            RuleFor(q => q.DailyPrice).NotEmpty();
            RuleFor(q => q.BrandId).NotEmpty();
            RuleFor(q => q.ColorId).NotEmpty();
        }
	}
}
