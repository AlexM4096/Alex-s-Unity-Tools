using System;
using System.Collections.Generic;

namespace AlexTools.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue AsFunc<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary, 
            TKey key) => dictionary[key];

        public static TValue AsFuncR<TKey, TValue>(
            this IReadOnlyDictionary<TKey, TValue> dictionary, 
            TKey key) => dictionary[key];

        #region GetOrAdd

        /// <summary>
        /// Gets an existing value or creates a new instance using the default constructor.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary (must have parameterless constructor).</typeparam>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="key">The key to look up.</param>
        /// <returns>The existing value if found, or a new instance if not present.</returns>
        /// <remarks>
        /// This is useful for lazy initialization of dictionary values.
        /// Note: Not thread-safe by default. For concurrent scenarios, use ConcurrentDictionary or external synchronization.
        /// </remarks>
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
        
        /// <summary>
        /// Gets an existing value or creates a new instance using the provided factory function.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="key">The key to look up.</param>
        /// <param name="createFunc">Factory function to create a new value when needed.</param>
        /// <returns>The existing value if found, or the result of createFunc if not present.</returns>
        /// <remarks>
        /// More flexible than the parameterless version as it allows custom initialization logic.
        /// The factory function is only invoked when the key doesn't exist.
        /// </remarks>
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> createFunc
        )
        {
            if (dictionary.TryGetValue(key, out var value))
                return value;

            value = createFunc();
            dictionary[key] = value;

            return value;
        }
        
        /// <summary>
        /// Gets an existing value or creates a new instance using the provided key-aware factory function.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary to operate on.</param>
        /// <param name="key">The key to look up.</param>
        /// <param name="createFunc">Factory function that receives the key to create a new value.</param>
        /// <returns>The existing value if found, or the result of createFunc if not present.</returns>
        /// <remarks>
        /// Most flexible version that allows value creation based on the key.
        /// Useful when the key contains information needed for value initialization.
        /// Pattern commonly used in caching scenarios and dependency injection containers.
        /// </remarks>
        public static TValue GetOrAdd<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TKey, TValue> createFunc
        )
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