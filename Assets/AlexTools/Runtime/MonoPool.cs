using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace AlexTools
{
    public class MonoPool<T> : IDisposable, IObjectPool<T> where T : MonoBehaviour
    {
        public const int DefaultCapacity = 8;
        
        private readonly T _prefab;
        private readonly Transform _origin;
        private readonly List<T> _list;

        public int CountInactive => _list.Count;

        public MonoPool(T prefab, Transform origin = null, int capacity = DefaultCapacity)
        {
            _prefab = prefab;
            _origin = origin;
            _list = new List<T>(capacity);
        }

        private T Create() => Object.Instantiate(_prefab, _origin);
        private static void OnGet(T obj) => obj.gameObject.SetActive(true);
        private static void OnRelease(T obj) => obj.gameObject.SetActive(false);
        private static void OnDestroy(T obj) => Object.Destroy(obj);

        public T Get()
        {
            T obj;
            
            if (_list.Count == 0)
                obj = Create();
            else
            {
                var index = _list.Count - 1;
                obj = _list[index];
                _list.RemoveAt(index);
            }
            
            OnGet(obj);
            return obj;
        }

        public PooledObject<T> Get(out T v) => throw new NotImplementedException();

        public void Release(T element)
        {
            OnRelease(element);
            
            if (CountInactive < _list.Capacity)
                _list.Add(element);
            else
                OnDestroy(element);
        }

        public void Clear()
        {
            foreach (var obj in _list)
                OnDestroy(obj);
            
            _list.Clear();
        }

        public void Dispose() => Clear();
    }
}