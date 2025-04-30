using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AlexTools.Random;
using JetBrains.Annotations;

namespace AlexTools.Extensions
{
    public static class EnumerableExtensions
    {
        #region ForEach

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var element in enumerable)
                action(element);
        }
        
        public static void ForEachO(this IEnumerable enumerable, Action<object> action)
        {
            foreach (var element in enumerable)
                action(element);
        }
        
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<int, T> action)
        {
            var count = 0;
            foreach (var element in enumerable)
                action(count++, element);
        }
        
        public static void ForEachO(this IEnumerable enumerable, Action<int, object> action)
        {
            var count = 0;
            foreach (var element in enumerable)
                action(count++, element);
        }

        #endregion

        #region Extra

        public static IEnumerable<int> To(this int from, int to)
        {
            var diff = to - from;
            if (diff == 0) yield return from;
            
            var delta = Math.Sign(diff);
            while (from - to != delta)
            {
                yield return from;
                from += delta;
            }
        }

        public static IEnumerable<(int, T)> Index<T>(this IEnumerable<T> enumerable)
        {
            var count = 0;
            foreach (var item in enumerable)
                yield return (count++, item);
        }
        
        public static IEnumerable<TValue> SelectFrom<TKey, TValue>(
            this IEnumerable<TKey> enumerable,
            IDictionary<TKey, TValue> dictionary) =>
            enumerable.Select(dictionary.AsFunc);
        
        public static IEnumerable<TValue> SelectFromR<TKey, TValue>(
            this IEnumerable<TKey> enumerable,
            IReadOnlyDictionary<TKey, TValue> dictionary) =>
            enumerable.Select(dictionary.AsFuncR);
        
        public static IEnumerable<IEnumerable<T>> Partition<T>(
            this IEnumerable<T> enumerable, 
            int size, 
            bool trimEnd = true)
        {
            T[] array = null;
            var count = 0;
        
            foreach (var item in enumerable)
            {
                array ??= new T[size];
                array[count] = item;
            
                count++;
                if (count < size) continue;
            
                yield return new ReadOnlyCollection<T>(array);
            
                array = null;
                count = 0;
            }

            if (trimEnd || array == null) yield break;
        
            Array.Resize(ref array, count);
            yield return new ReadOnlyCollection<T>(array);
        }

        #endregion

        #region Random

        private static bool TryCastRandom<T>([NoEnumeration] IEnumerable<T> enumerable, IRandom random, out T value)
        {
            if (enumerable == null)
                throw new Exception();
            
            value = default;
            
            switch (enumerable)
            {
                case IList<T> list when !list.IsEmpty():
                    value = list.GetRandomItem(random);
                    return true;
                case IReadOnlyList<T> list when !list.IsEmptyR():
                    value = list.GetRandomItemR(random);
                    return true;
                case IList list when !list.IsEmptyO():
                    value = (T)list.GetRandomObject(random);
                    return value != null;
                default:
                    return false;
            }
        }
        
        public static T Random<T>(this IEnumerable<T> enumerable, IRandom random = null)
        {
            if (TryCastRandom(enumerable, random, out var value)) 
                return value;
            
            using var enumerator = enumerable.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new InvalidOperationException("The source sequence is empty.");
            
            random = random.OrDefault();
            
            value = enumerator.Current;
            var count = 1;

            while (enumerator.MoveNext())
            {
                if (random.GetBool(++count)) continue;
                value = enumerator.Current;
            }

            return value;
        }
        
        public static T RandomOrDefault<T>(this IEnumerable<T> enumerable, IRandom random = null)
        {
            if (TryCastRandom(enumerable, random, out var value)) 
                return value;
            
            random = random.OrDefault();
            var count = 0;

            foreach (var item in enumerable)
            {
                if (random.GetBool(++count)) continue;
                value = item;
            }

            return value;
        }
        
        // public static T? RandomOrNull<T>(this IEnumerable<T> enumerable, IRandom random = null) where T : struct
        // {
        //     if (TryRandom(enumerable, random, out var value)) 
        //         return value;
        //     
        //     random = random.OrDefault();
        //     var count = 0;
        //
        //     foreach (var item in enumerable)
        //     {
        //         if (random.GetBool(++count)) continue;
        //         value = item;
        //     }
        //
        //     return value;
        // }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable, IRandom random = null)
        {
            var list = enumerable.ToArray();
            list.ShuffleItems(random);
            return new ReadOnlyCollection<T>(list);
        }

        #endregion
    }
}