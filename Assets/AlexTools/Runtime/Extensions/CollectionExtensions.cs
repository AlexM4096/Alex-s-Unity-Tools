using System.Collections.Generic;

namespace AlexTools.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsEmpty<T>(this ICollection<T> list) => list.Count == 0;
        public static bool IsEmptyOrNull<T>(this ICollection<T> list) => list == null || list.IsEmpty();
    }
}