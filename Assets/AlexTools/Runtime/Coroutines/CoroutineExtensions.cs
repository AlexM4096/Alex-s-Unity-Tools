using System.Collections;
using UnityEngine;

namespace AlexTools.Coroutines
{
    public static class CoroutineExtensions
    {
        public static MonoBehaviour OrDefault(this MonoBehaviour runner) => 
            runner ? runner : CoroutineRunner.Default;
    
        public static Coroutine Start(this IEnumerator enumerator, MonoBehaviour runner = null) =>
            runner.OrDefault().StartCoroutine(enumerator);
        
        public static void Stop(this Coroutine coroutine, MonoBehaviour runner = null)
        {
            if (coroutine == null) return;
            runner.OrDefault().StopCoroutine(coroutine);
        }
    }
}