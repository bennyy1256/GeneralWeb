using General.Common.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace General.Common.Utility
{
    public static class EnumHelper
    {
        /// <summary>
        /// Get enum dictionary which value is field's desciption.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumDescriptionDictionary<T>()
            where T : struct, IComparable
        {
            var dict = new Dictionary<int, string>();

            Type type = typeof(T);

            foreach (var item in Enum.GetValues(type))
            {
                var info = type.GetField(item.ToString());
                var descriptionAttribute = GetDefaultDescriptionAttribute(info);

                if (!dict.ContainsKey((int)item))
                {
                    dict.Add((int)item, descriptionAttribute.Description);
                }
            }

            return dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Get showable enum dictionary which value is field's desciption.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> GetShowableEnumDescriptionDictionary<T>()
            where T : struct, IComparable
        {
            var dict = new Dictionary<int, string>();

            Type type = typeof(T);

            foreach (var item in Enum.GetValues(type))
            {
                var info = type.GetField(item.ToString());
                var descriptionAttribute = GetDefaultDescriptionAttribute(info);
                var enumShowAttribute = (EnumShowAttribute)System.Attribute.GetCustomAttribute(
                                                                    info, typeof(EnumShowAttribute));

                var isShow = enumShowAttribute == null ? true : enumShowAttribute.IsShow;

                if (!dict.ContainsKey((int)item) && isShow)
                {
                    dict.Add((int)item, descriptionAttribute.Description);
                }
            }

            return dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        /// <summary>
        /// Get showable enum SelectListItem list with default items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="defaultItems"></param>
        /// <returns></returns>
        public static List<SelectListItem> GetShowableEnumDescriptionListItemWithDefault<T>(
            IDictionary<string, string> defaultItems)
            where T : struct, IComparable
        {
            List<SelectListItem> items = GenerateDefaultItems(defaultItems);

            var enumResult = GetShowableEnumDescriptionListItem<T>();

            items.AddRange(enumResult);

            return items;
        }

        /// <summary>
        /// Add default items to list.
        /// </summary>
        /// <param name="defaultItemText"></param>
        /// <param name="defaultItemValue"></param>
        /// <returns></returns>
        public static List<SelectListItem> GenerateDefaultItems(IDictionary<string, string> defaultItems)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            if (defaultItems != null && defaultItems.Count > 0)
            {
                
                foreach(var item in defaultItems)
                {
                    list.Add(new SelectListItem
                    {
                        Text = item.Value,
                        Value = item.Key
                    });
                }
            }

            return list;
        }

        /// <summary>
        /// Get showable enum SelectListItem list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<SelectListItem> GetShowableEnumDescriptionListItem<T>()
            where T : struct, IComparable
        {
            var result = new List<Tuple<int, SelectListItem>>();

            Type type = typeof(T);

            foreach (var item in Enum.GetValues(type))
            {
                var info = type.GetField(item.ToString());
                var descriptionAttribute = GetDefaultDescriptionAttribute(info);
                var enumShowAttribute = (EnumShowAttribute)System.Attribute.GetCustomAttribute(
                                                                    info, typeof(EnumShowAttribute));
                var enumDisplayOrderAttribute = (EnumDisplayOrderAttribute)System.Attribute.GetCustomAttribute(
                                                                    info, typeof(EnumDisplayOrderAttribute));

                var isShow = enumShowAttribute == null ? true : enumShowAttribute.IsShow;

                if (isShow)
                {
                    result.Add(Tuple.Create(
                        enumDisplayOrderAttribute == null ? 0 : enumDisplayOrderAttribute.Order,
                        new SelectListItem
                        {
                            Text = descriptionAttribute == null ? string.Empty : descriptionAttribute.Description,
                            Value = ((int)item).ToString()
                        }));
                }
            }

            return result.OrderBy(x => x.Item2.Text).Select(x => x.Item2).ToList();
        }

        /// <summary>
        /// Get first default DescriptionAttribute.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private static EnumDescriptionAttribute GetDefaultDescriptionAttribute(MemberInfo info)
        {
            var attributes = (EnumDescriptionAttribute[])System.Attribute.GetCustomAttributes(info, typeof(EnumDescriptionAttribute));
            
            return attributes.Where(x => x.IsDefault).FirstOrDefault();
        }


    }
}
