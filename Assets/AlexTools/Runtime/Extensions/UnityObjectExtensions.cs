using UnityEngine;

namespace AlexTools.Extensions
{
    public static class UnityObjectExtensions
    {
        public static bool IsNull<T>(this T obj) where T : Object => obj;
        public static bool IsNotNull<T>(this T obj) where T : Object => !obj;

        public static T OrNull<T>(this T obj) where T : Object => obj ?? null;
    }
}