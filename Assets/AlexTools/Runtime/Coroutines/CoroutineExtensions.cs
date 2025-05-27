using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace AlexTools.Coroutines
{
    public static class CoroutineExtensions
    {
        public static MonoBehaviour OrDefault(this MonoBehaviour runner) => 
            runner ? runner : CoroutineRunner.Instance;

        public static CoroutineHandler CreateHandler(
            this IEnumerator enumerator, 
            MonoBehaviour runner = null
        ) => new(enumerator, runner.OrDefault());
        
        public static IEnumerator AsCoroutine(
            this AsyncOperation operation,
            float frequency = 0
        )
        {
            var waitForSeconds = WaitFor.Seconds(frequency);
            
            while (!operation.isDone)
                yield return waitForSeconds;
        }
        public static IEnumerator AsCoroutine(this Task task) 
        {
            while (!task.IsCompleted) 
                yield return null;

            task.GetAwaiter().GetResult();
        }
        
    }
}