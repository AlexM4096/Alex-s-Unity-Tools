using System.Collections;
using System.Collections.Generic;
using AlexTools.Random;

namespace AlexTools.Extensions
{
    public static class CollectionExtensions
    {
        public static int LastIndex<T>(this ICollection<T> collection) => collection.Count - 1;
        public static int LastIndexR<T>(this IReadOnlyCollection<T> collection) => collection.Count - 1;
        public static int LastIndexO(this ICollection collection) => collection.Count - 1;
        
        #region CollectionCheck

        public static bool IsEmpty<T>(this ICollection<T> collection) => 
            collection.Count == 0;
        public static bool IsEmptyO(this ICollection collection) => 
            collection.Count == 0;
        public static bool IsEmptyR<T>(this IReadOnlyCollection<T> collection) => 
            collection.Count == 0;
        
        public static bool IsEmptyOrNull<T>(this ICollection<T> collection) => 
            collection == null || collection.IsEmpty();
        public static bool IsEmptyOrNullO(this ICollection collection) => 
            collection == null || collection.IsEmptyO();
        public static bool IsEmptyOrNullR<T>(this IReadOnlyCollection<T> collection) => 
            collection == null || collection.IsEmptyR();

        #endregion

        #region Random

        public static int GetRandomIndex<T>(this ICollection<T> collection, IRandom random = null) => 
            random.OrDefault().GetIndex(collection);
        public static int GetRandomIndexO(this ICollection collection, IRandom random = null) => 
            random.OrDefault().GetIndexO(collection);
        public static int GetRandomIndexR<T>(this IReadOnlyCollection<T> collection, IRandom random = null) => 
            random.OrDefault().GetIndexR(collection);

        #endregion
    }
}