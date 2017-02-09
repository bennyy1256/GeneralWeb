using General.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace General.Common.Extension
{
    public static class HtmlExtension
    {
        #region == DropDownList ==

        /// <summary>
        /// Generate DropDownList html with only showable enum fields.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <param name="defaultItems"></param>
        /// <returns></returns>
        public static MvcHtmlString DropDownListForShowableEnumDesc<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object htmlAttributes,
            IDictionary<string, string> defaultItems)
            where TModel : struct, IComparable
        {
            List<SelectListItem> list =
                EnumHelper.GetShowableEnumDescriptionListItemWithDefault<TModel>(defaultItems);

            return htmlHelper.DropDownListFor(expression, list, htmlAttributes);
        }

        #endregion
    }
}
