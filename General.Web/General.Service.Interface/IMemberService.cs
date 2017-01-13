using General.Service.ParameterDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Interface
{
    public interface IMemberService
    {
        /// <summary>
        /// Is member exist, return true, otherwise, return false.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsExist(string name, string email);

        /// <summary>
        /// Save Member.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool SaveMember(MemberParameterDto parameter);
    }
}
