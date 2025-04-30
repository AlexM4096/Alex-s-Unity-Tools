using System.Collections;
using System.Collections.Generic;

namespace AlexTools.Extensions
{
    public static class EnumeratorExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator) 
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }

        public static bool AsPredicate<T>(this IEnumerator<T> enumerator) => enumerator.MoveNext();
        public static bool AsPredicateO(this IEnumerator enumerator) => enumerator.MoveNext();
    }
}