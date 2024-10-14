using System.Collections;
using UnityEngine;

namespace AlexTools.Extensions
{
    public static class AsyncOperationExtensions
    {
        public static IEnumerator AsCoroutine(this AsyncOperation operation)
        {
            while (!operation.isDone)
                yield return null;
        }
    }
}