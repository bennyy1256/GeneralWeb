using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Common.Attribute
{
    /// <summary>
    /// Show the Enum field or not. (ex. DropDownList)
    /// </summary>
    public class EnumShowAttribute : System.Attribute
    {
        public bool IsShow { get; set; }

        /// <summary>
        /// Default show the enum fields.
        /// </summary>
        public EnumShowAttribute()
        {
            IsShow = true;
        }

        public EnumShowAttribute(bool show)
        {
            IsShow = show;
        }
    }
}
