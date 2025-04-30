using UnityEngine;

namespace AlexTools.Extensions
{
    public static class UnityObjectExtensions
    {
        public static bool IsNull(this Object obj) => !obj;
        public static bool IsNotNull(this Object obj) => obj;

        public static T OrNull<T>(this T obj) where T : Object => obj ? obj : null;
    }
}