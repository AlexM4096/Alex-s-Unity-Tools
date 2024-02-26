using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace AlexTools.Clocks
{
    public class ClockContext : MonoBehaviour
    {
        private Dictionary<Type, ObjectPool<Clock>> _dictionary;

        public T Create<T>(float initialTime, string timeFormat) where T : Clock
        {
            if (!_dictionary.TryGetValue(typeof(T), out var value))
            {
                
            }

            return null;
        }

        private T OnCreate<T>() where T : Clock, new() => new T();
    }
}