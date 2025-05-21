using System.Collections;
using System.Collections.Generic;
using AlexTools.Random;

namespace AlexTools.Extensions
{
    public static class ListExtensions
    {
        #region First&Last

        public static T First<T>(this IList<T> list) => list[0];
        public static T FirstR<T>(this IReadOnlyList<T> list) => list[0];
        public static object FirstO(this IList list) => list[0];
        
        public static T Last<T>(this IList<T> list) => list[^1];
        public static T LastR<T>(this IReadOnlyList<T> list) => list[^1];
        public static object LastO(this IList list) => list[^1];

        #endregion
        
        #region PopAt

        public static T PopAt<T>(this IList<T> list, int index)
        {
            var value = list[index];
            list.RemoveAt(index);
            return value;
        }
        public static bool TryPopAt<T>(this IList<T> list, int index, out T value)
        {
            if (!list.IsEmptyOrNull() && list.Count > index)
            {
                value = list.PopAt(index);
                return true;
            }

            value = default;
            return true;
        }
        
        public static object PopAtO(this IList list, int index)
        {
            var value = list[index];
            list.RemoveAt(index);
            return value;
        }
        public static bool TryPopAtO(this IList list, int index, out object value)
        {
            if (!list.IsEmptyOrNullO() && list.Count > index)
            {
                value = list.PopAtO(index);
                return true;
            }

            value = default;
            return true;
        }

        #endregion
        
        #region Random

        public static T GetRandomItem<T>(this IList<T> list, IRandom random = null) =>
            random.OrDefault().GetItem(list);
        public static bool TryGetRandomItem<T>(this IList<T> list, out T item, IRandom random = null)
        {
            if (list.IsEmptyOrNull())
            {
                item = default;
                return false;
            }

            item = list.GetRandomItem(random);
            return true;
        }
        
        public static T GetRandomItemR<T>(this IReadOnlyList<T> list, IRandom random = null) =>
            random.OrDefault().GetItemR(list);
        public static bool GetRandomItemR<T>(this IReadOnlyList<T> list, out T item, IRandom random = null)
        {
            if (list.IsEmptyOrNullR())
            {
                item = default;
                return false;
            }

            item = list.GetRandomItemR(random);
            return true;
        }

        public static object GetRandomObject(this IList list, IRandom random = null) =>
            random.OrDefault().GetObject(list);
        public static bool TryGetRandomObject(this IList list, out object item, IRandom random = null)
        {
            if (list.IsEmptyOrNullO())
            {
                item = default;
                return false;
            }

            item = list.GetRandomObject(random);
            return true;
        }
        
        public static T PopRandomItem<T>(this IList<T> list, IRandom random = null)
        {
            var index = list.GetRandomIndex(random);
            return list.PopAt(index);
        }
        public static bool TryPopRandomItem<T>(this IList<T> list, out T item, IRandom random = null)
        {
            if (list.IsEmptyOrNull())
            {
                item = default;
                return false;
            }

            item = list.PopRandomItem(random);
            return true;
        }
        
        public static object PopRandomObject(this IList list, IRandom random = null)
        {
            var index = list.GetRandomIndexO(random);
            return list.PopAtO(index);
        }
        public static bool TryPopRandomObject(this IList list, out object obj, IRandom random = null)
        {
            if (list.IsEmptyOrNullO())
            {
                obj = default;
                return false;
            }
        
            obj = list.PopRandomObject(random);
            return true;
        }
        
        public static void ShuffleItems<T>(this IList<T> list, IRandom random = null)
        {
            random = random.OrDefault();
            
            for (var i = list.Count; i > 0; i--)
            {
                var index = random.GetInt(0, i);
                (list[i], list[index]) = (list[index], list[i]);
            }
        }
        
        public static void ShuffleObjects(this IList list, IRandom random = null)
        {
            random = random.OrDefault();
            
            for (var i = list.Count; i > 0; i--)
            {
                var index = random.GetInt(0, i);
                (list[i], list[index]) = (list[index], list[i]);
            }
        }

        #endregion

        #region Stack

        public static void Push<T>(this IList<T> list, T value) => list.Add(value);
        public static void PushO(this IList list, object value) => list.Add(value);

        public static T Pop<T>(this IList<T> list) => list.PopAt(list.LastIndex());
        public static bool TryPop<T>(this IList<T> list, out T value)
        {
            if (list.IsEmptyOrNull())
            {
                value = default;
                return false;
            }

            value = list.Pop();
            return true;
        }
        
        public static object PopO(this IList list) => list.PopAtO(list.LastIndexO());
        public static bool TryPopO(this IList list, out object value)
        {
            if (list.IsEmptyOrNullO())
            {
                value = default;
                return false;
            }

            value = list.PopO();
            return true;
        }

        #endregion

        #region Queue

        public static T Dequeue<T>(this IList<T> list)
        {
            var value = list.First();
            list.RemoveAt(0);
            return value;
        }
        
        public static object DequeueO(this IList list)
        {
            var value = list.FirstO();
            list.RemoveAt(0);
            return value;
        }

        public static void Enqueue<T>(this IList<T> list, T value) => list.Insert(0, value);
        public static void EnqueueO(this IList list, object value) => list.Insert(0, value);

        public static bool TryDequeue<T>(this IList<T> list, out T value)
        {
            if (list.IsEmptyOrNull())
            {
                value = default;
                return false;
            }

            value = list.Dequeue();
            return true;
        }
        
        public static bool TryDequeueO(this IList list, out object value)
        {
            if (list.IsEmptyOrNullO())
            {
                value = default;
                return false;
            }

            value = list.DequeueO();
            return true;
        }

        #endregion
        
        public static IEnumerable<T> FastReverse<T>(this IList<T> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
        }
        
        public static IEnumerable<T> FastReverseR<T>(this IReadOnlyList<T> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
        }
        
        public static IEnumerable FastReverseO(this IList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
        }
        
        public static CycleEnumerator<T> GetCycleEnumerator<T>(this IList<T> list) => new(list);
        public static CycleEnumerator GetCycleEnumeratorO(this IList list) => new(list);
    }
}