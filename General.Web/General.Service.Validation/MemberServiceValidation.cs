using General.Service.Validation.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Service.Interface;
using FluentValidation;

namespace General.Service.Validation
{
    public class MemberServiceValidation : MemberServiceWrapper
    {
        public MemberServiceValidation(IMemberService memberService) 
            : base(memberService)
        {
        }

        public override bool IsExist(string name, string email, int age)
        {
            // Validation

            var result = this.MemberService.IsExist(name, email, age);
            return result;
        }
    }
}
