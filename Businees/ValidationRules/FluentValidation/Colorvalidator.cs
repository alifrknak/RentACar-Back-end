using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Entities.Concrete.Color;

namespace Businees.ValidationRules.FluentValidation
{
    public class Colorvalidator : AbstractValidator<Color>
    {
        public Colorvalidator()
        {
            RuleFor(q => q.Name).MinimumLength(2).MaximumLength(255);
        }
    }
}
