using General.Common.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Common.Enum
{
    public enum GenderEnum
    {
        [EnumDescription("女性")]
        [EnumDescription("Female", true)]
        //[EnumShow]
        [EnumDisplayOrder(2)]
        Female = 0,

        [EnumDescription("男性")]
        [EnumDescription("Male", true)]
        [EnumShow(false)]
        [EnumDisplayOrder(1)]
        Male = 1,

        [EnumDescription("無性別")]
        [EnumDescription("NoGender", true)]
        //[EnumShow]
        [EnumDisplayOrder(3)]
        NoGender
    }
}
