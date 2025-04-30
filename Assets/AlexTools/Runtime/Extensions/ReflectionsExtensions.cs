using System;
using System.Reflection;

namespace AlexTools.Extensions
{
    public static class ReflectionsExtensions
    {
        public static bool TryGetCustomAttribute<T>(this MemberInfo memberInfo, out T attribute) where T : Attribute
        {
            attribute = memberInfo.GetCustomAttribute<T>();
            return attribute != null;
        }

        public static bool HasCustomAttribute<T>(this MemberInfo memberInfo) where T : Attribute =>
            memberInfo.TryGetCustomAttribute<T>(out _);
    }
}