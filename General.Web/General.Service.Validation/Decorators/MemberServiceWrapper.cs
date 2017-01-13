using General.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Service.ParameterDto;

namespace General.Service.Validation.Decorators
{
    public abstract class MemberServiceWrapper : IMemberService
    {
        protected IMemberService MemberService { get; set; }

        public MemberServiceWrapper(IMemberService memberService)
        {
            this.MemberService = memberService;
        }

        public abstract bool IsExist(string name, string email);

        public abstract bool SaveMember(MemberParameterDto parameter);
    }
}
