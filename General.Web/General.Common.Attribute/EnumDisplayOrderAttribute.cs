using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Common.Attribute
{
    /// <summary>
    /// Enum display order.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayOrderAttribute : System.Attribute
    {
        public int Order { get; set; }

        public EnumDisplayOrderAttribute()
        {
            this.Order = 0;
        }

        public EnumDisplayOrderAttribute(int order)
        {
            this.Order = order;
        }
    }
}
