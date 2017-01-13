using General.Service.Interface;
using General.Service.Validation.ParameterValidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General.Service.ParameterDto;
using General.Repository.Interface;
using AutoMapper;
using General.Model;
using General.Service.Implement.Mappings;

namespace General.Service.Implement
{
    public class MemberService : IMemberService
    {
        private IMemberRepository MemberRepository { get; set; }

        public MemberService(IMemberRepository memberRepository)
        {
            this.MemberRepository = memberRepository;

            //ServiceProfile profile = new ServiceProfile();
            
        }

        /// <summary>
        /// Is member exist, return true, otherwise, return false.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsExist(string name, string email)
        {
            bool result = false;
            var validate = ValidateHelper.Begin()
                          .NotNull(name)
                          .NotNull(email)
                          .IsEmail(email);

            if (validate.IsValid)
            {
                // do somting....
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Save Member.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool SaveMember(MemberParameterDto parameter)
        {
            var model = Mapper.Map<MemberParameterDto, MemberModel>(parameter);

            var result = this.MemberRepository.Save(model);

            return result;
        }
    }
}
