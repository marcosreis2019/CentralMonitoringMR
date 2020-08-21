using System;
using System.ComponentModel;

namespace LibClass.Commom.Enum
{
    public static class EnumExt
    {
        /// <summary>
        /// Gets the description defined in the [Description ("xx")] attribute for Enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Description(this System.Enum value)
        {
            var attribute = value.ObterAtributo<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Gets an attribute associated with the Enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ObterAtributo<T>(this System.Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }
    }
}