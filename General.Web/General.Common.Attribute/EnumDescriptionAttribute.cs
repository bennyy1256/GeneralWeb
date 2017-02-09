using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Common.Attribute
{
    /// <summary>
    /// Enum Descriotion.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class EnumDescriptionAttribute : System.Attribute
    {
        public bool IsDefault { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Default use this description.
        /// </summary>
        public EnumDescriptionAttribute(string description)
        {
            IsDefault = false;
            Description = description;
        }

        public EnumDescriptionAttribute(string description, bool isDefault)
        {
            IsDefault = isDefault;
            Description = description;
        }
    }
}
