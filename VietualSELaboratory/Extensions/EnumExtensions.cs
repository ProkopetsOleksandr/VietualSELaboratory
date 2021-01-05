using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace VietualSELaboratory.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<object> GetDescriptions(Type type)
        {

            var descriptions = type.GetFields()
                .Select(f => (DescriptionAttribute)f.GetCustomAttribute(typeof(DescriptionAttribute)))
                .Where(a => a != null)
                .Select(a => a.Description);


            List<object> items = new List<object>();

            foreach (var i in descriptions)
            {
                items.Add(new
                {
                    Text = i,
                    Value = i
                });
            }

            return items;
        }
    }
}
