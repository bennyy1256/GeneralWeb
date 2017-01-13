using FluentValidation;
using General.Service.ParameterDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Validation.Validators
{
    public class MemberParameterDtoValidator : AbstractValidator<MemberParameterDto>
    {
        public MemberParameterDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("{PropertyName} 不能為Null。");
        }
    }
}
