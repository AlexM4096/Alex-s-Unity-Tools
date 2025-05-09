using System.Collections.Generic;
using UnityEngine;
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

        public static IEnumerable<T> GetMultiple<T>(this IObjectPool<T> pool, int amount) where T : class
        {
            for (var i = 0; i < amount; i++)
                yield return pool.Get();
        }
        
        public static void ReleaseMultiple<T>(this IObjectPool<T> pool, IEnumerable<T> items) where T : class
        {
            foreach (var item in items)
                pool.Release(item);
        }

        public static MonoPool<T> CreatePool<T>(
            this T prefab,
            Transform origin = null, 
            int capacity = 8) 
            where T : MonoBehaviour => 
            new(prefab, origin, capacity);
    }
}