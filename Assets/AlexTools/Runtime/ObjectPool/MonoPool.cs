using System;
using System.Collections.Generic;
using AlexTools.Extensions;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace AlexTools.ObjectPool
{
    public class MonoPool<T> : 
        IDisposable, 
        IObjectPool<T> 
        where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _origin;
        
        private readonly bool _resize;
        private readonly List<T> _list;

        public int CountInactive => _list.Count;

        public MonoPool(
            T prefab, 
            Transform origin = null, 
            int capacity = 8,
            bool resize = true
        )
        {
            _prefab = prefab;
            _origin = origin;
            
            _resize = resize;
            _list = new List<T>(capacity);
        }

        private T Create() => Object.Instantiate(_prefab, _origin);
        private static void OnGet(T obj) => obj.gameObject.Enable();
        private static void OnRelease(T obj) => obj.gameObject.Disable();
        private static void OnDestroy(T obj) => Object.Destroy(obj);

        public T Get()
        {
            if (!_list.TryPop(out var obj)) obj = Create();
            OnGet(obj);
            return obj;
        }

        public PooledObject<T> Get(out T v) => throw new NotImplementedException();

        public void Release(T element)
        {
            OnRelease(element);
            
            if (_resize || CountInactive < _list.Capacity)
                _list.Add(element);
            else
                OnDestroy(element);
        }

        public void Clear()
        {
            foreach (var obj in _list)
                OnDestroy(obj);
            
            _list.Clear();
            if (_resize) _list.TrimExcess();
        }

        public void Dispose() => Clear();
    }
}