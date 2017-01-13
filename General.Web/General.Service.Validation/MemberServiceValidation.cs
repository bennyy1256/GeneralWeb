using General.Service.Validation.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Service.Interface;
using FluentValidation;
using General.Service.ParameterDto;
using General.Service.Validation.Validators;

namespace General.Service.Validation
{
    public class MemberServiceValidation : MemberServiceWrapper
    {
        public MemberServiceValidation(IMemberService memberService) 
            : base(memberService)
        {
        }

        public override bool IsExist(string name, string email)
        {
            // Validation

            var result = this.MemberService.IsExist(name, email);
            return result;
        }

        public override bool SaveMember(MemberParameterDto parameter)
        {
            var result = false;
            var validator = new MemberParameterDtoValidator();

            validator.ValidateAndThrow(parameter);

            //var validateResult = validator.Validate(parameter);

            //if (!validateResult.IsValid)
            //{
            //    // Throw Exception
            //    validateResult.Errors
            //}

            result = MemberService.SaveMember(parameter);

            return result;
        }
    }
}
