using System;
using System.ComponentModel;
using System.Reflection;

namespace _02.Scripts.Util
{
    public static class EnumExtensions 
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            
            var att = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (att != null && att.Length > 0)
            {
                return att[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
