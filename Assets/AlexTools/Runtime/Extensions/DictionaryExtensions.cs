using System;
using System.Collections.Generic;

namespace AlexTools.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue AsFunc<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) => 
            dictionary[key];

        public static TValue AsFuncR<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary[key];

        #region GetOrAdd

        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key) 
            where TValue: new()
        {
            if (dictionary.TryGetValue(key, out var value))
                return value;

            value = new TValue();
            dictionary[key] = value;

            return value;
        }
        
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> createFunc)
        {
            if (dictionary.TryGetValue(key, out var value))
                return value;

            value = createFunc();
            dictionary[key] = value;

            return value;
        }
        
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> createFunc)
        {
            if (dictionary.TryGetValue(key, out var value))
                return value;

            value = createFunc(key);
            dictionary[key] = value;

            return value;
        }

        #endregion
    }
}