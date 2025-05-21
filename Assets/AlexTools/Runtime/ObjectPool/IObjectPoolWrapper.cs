using System.Collections.Generic;
using UnityEngine.Pool;

namespace AlexTools.ObjectPool
{
    public interface IObjectPoolWrapper<T> : IObjectPool<T> where T : class
    {
        
        void ReleaseAll();
    }

    public class ObjectPoolWrapper<T> : IObjectPoolWrapper<T> where T : class
    {
        private readonly IObjectPool<T> _inner;
        private readonly HashSet<T> _active;

        public ObjectPoolWrapper(IObjectPool<T> inner)
        {
            _inner = inner;
            _active = new HashSet<T>(_inner.CountInactive);
        }

        public T Get()
        {
            var obj = _inner.Get();
            _active.Add(obj);
            return obj;
        }

        public PooledObject<T> Get(out T v)
        {
            var po = _inner.Get(out v);
            _active.Add(v);
            return po;
        }

        public void Release(T element)
        {
            _inner.Release(element);
            _active.Remove(element);
        }

        public void Clear()
        {
            _inner.Clear();
            _active.Clear();
        }

        public int CountInactive => _inner.CountInactive;
        
        public void ReleaseAll()
        {
            foreach (var obj in _active)
                _inner.Release(obj);
            
            _active.Clear();
        }
    }
}