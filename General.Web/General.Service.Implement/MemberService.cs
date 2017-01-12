using General.Service.Interface;
using General.Service.Validation.ParameterValidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Implement
{
    public class MemberService : IMemberService
    {
        /// <summary>
        /// Is member exist, return true, otherwise, return false.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public bool IsExist(string name, string email, int age)
        {
            bool result = false;
            var validate = ValidateHelper.Begin()
                          .NotNull(name)
                          .NotNull(email)
                          .IsEmail(email)
                          .NotNull(age)
                          .InRange(age, 18, 130);

            if (validate.IsValid)
            {
                // do somting....
                result = true;
            }

            return result;
        }
    }
}
