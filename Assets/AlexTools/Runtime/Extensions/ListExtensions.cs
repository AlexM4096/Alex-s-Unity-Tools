using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandomItem<T>(this IList<T> list) => list[Random.Range(0, list.Count - 1)];
        public static object GetRandomItem(this IList list) => list[Random.Range(0, list.Count)];
        
        public static bool RemoveRandomItem<T>(this IList<T> list) => list.Remove(GetRandomItem(list));
        public static void RemoveRandomItem(this IList list) => list.Remove(GetRandomItem(list));

        public static void Shuffle(this IList list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int index = Random.Range(0, list.Count);
                (list[i], list[index]) = (list[index], list[i]);
            }
        }
    }
}