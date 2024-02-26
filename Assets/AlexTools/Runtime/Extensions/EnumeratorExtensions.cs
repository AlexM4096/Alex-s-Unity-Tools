using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlexTools.Extensions
{
    public static class EnumeratorExtensions
    {
        public static IEnumerator AsCoroutine(this Task task) 
        {
            while (!task.IsCompleted) yield return null;
            task.GetAwaiter().GetResult();
        }
        
        public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator) 
        {
            while (enumerator.MoveNext())
                yield return enumerator.Current;
        }
    }
}