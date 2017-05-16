using FluentValidation;
using General.Service.ParameterDto;
using General.Service.Validation.Message;
using General.Service.Validation.ValidatorExtensions;
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
                .IsGuid()
                .WithMessage(ValidateMessage.IsGuid, "Id");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage(ValidateMessage.NotNull, "Name")
                .NotEmpty()
                .WithMessage(ValidateMessage.NotEmpty, "Name");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage(ValidateMessage.NotNull, "Email")
                .NotEmpty()
                .WithMessage(ValidateMessage.NotEmpty, "Email")
                .EmailAddress()
                .WithMessage(ValidateMessage.IncorrectEmailFormat, "Email");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage(ValidateMessage.NotNull, "Password")
                .NotEmpty()
                .WithMessage(ValidateMessage.NotEmpty, "Password");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18)
                .WithMessage(ValidateMessage.GreaterThanOrEqualTo, new object[] { "Age", "18" });

        }
    }
}
