using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace CustomFramework.Utils
{
    public static class EnumHelper
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}