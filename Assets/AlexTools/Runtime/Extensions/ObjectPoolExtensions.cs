using UnityEngine.Pool;

namespace AlexTools.Extensions
{
    public static class ObjectPoolExtensions
    {
        public static IObjectPool<T> AsPreloaded<T>(this IObjectPool<T> pool, int amount) where T : class
        {
            pool.Preload(amount);
            return pool;
        }
        
        public static void Preload<T>(this IObjectPool<T> pool, int amount) where T : class
        {
            var objects = new T[amount];

            for (var i = 0; i < amount; i++)
                objects[i] = pool.Get();
            
            for (var i = 0; i < amount; i++)
                pool.Release(objects[i]);
        }
    }
}