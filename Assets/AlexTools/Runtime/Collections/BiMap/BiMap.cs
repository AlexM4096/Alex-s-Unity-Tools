using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace AlexTools.Collections
{
    public class BiMap<TKey1, TKey2> : IBiMap<TKey1, TKey2>, IReadOnlyBiMap<TKey1, TKey2>
    {
        private Dictionary<TKey1, TKey2> _forward;
        private Dictionary<TKey2, TKey1> _reverse;

        public IReadOnlyDictionary<TKey1, TKey2> Forward => _forward;
        public IReadOnlyDictionary<TKey2, TKey1> Reverse => _reverse;
        
        public int Count => Forward.Count;

        public TKey1 this[TKey2 key2]
        {
            get => _reverse[key2];
            set => _reverse[key2] = value;
        }


        public TKey2 this[TKey1 key1]
        {
            get => _forward[key1];
            set => _forward[key1] = value;
        }

        public BiMap(
            int capacity,
            IEqualityComparer<TKey1> comparerKey1 = null, 
            IEqualityComparer<TKey2> comparerKey2 = null)
        {
            _forward = new Dictionary<TKey1, TKey2>(capacity, comparerKey1);
            _reverse = new Dictionary<TKey2, TKey1>(capacity, comparerKey2);
        }
        
        public BiMap() : this(0) {}

        private BiMap(
            IEnumerable<KeyValuePair<TKey1, TKey2>> forward,
            IEnumerable<KeyValuePair<TKey2, TKey1>> reverse,
            IEqualityComparer<TKey1> comparerKey1 = null,
            IEqualityComparer<TKey2> comparerKey2 = null)
        {
            _forward = new Dictionary<TKey1, TKey2>(forward, comparerKey1);
            _reverse = new Dictionary<TKey2, TKey1>(reverse, comparerKey2);
        }

        public BiMap(
            IReadOnlyBiMap<TKey1, TKey2> biMap, 
            IEqualityComparer<TKey1> comparerKey1 = null, 
            IEqualityComparer<TKey2> comparerKey2 = null
            ) : this(biMap.Forward, biMap.Reverse, comparerKey1, comparerKey2) {}

        // public BiMap(
        //     IEnumerable<KeyValuePair<TKey1, TKey2>> forward,
        //     IEqualityComparer<TKey1> comparerKey1 = null,
        //     IEqualityComparer<TKey2> comparerKey2 = null
        //     )
        // {
        //     _forward = new Dictionary<TKey1, TKey2>(forward, comparerKey1);
        //     var reverse = forward.Select(pair => new KeyValuePair<TKey2, TKey1>(pair.Value, pair.Key));
        //     _reverse = new Dictionary<TKey2, TKey1>(reverse, comparerKey2);
        // }

        public void Add(TKey1 key1, TKey2 key2)
        {
            if (!Contains(key1, key2))
                throw new ArgumentException();
            
            _forward.Add(key1, key2);
            _reverse.Add(key2, key1);
        }
        
        public bool Contains(TKey1 key1, TKey2 key2) => Forward.ContainsKey(key1) && Reverse.ContainsKey(key2);

        public void Clear()
        {
            _forward.Clear();
            _reverse.Clear();
        }

        public bool Remove(TKey1 key1, TKey2 key2)
        {
            bool success = Contains(key1, key2);

            if (success)
            {
                _forward.Remove(key1);
                _reverse.Remove(key2);
            }

            return success;
        }

        public bool TryGetValue(TKey1 key1, out TKey2 key2) => Forward.TryGetValue(key1, out key2);

        public bool TryGetValue(TKey2 key2, out TKey1 key1) => Reverse.TryGetValue(key2, out key1);

        #region Collection

        public bool IsReadOnly => true;

        public void Add(KeyValuePair<TKey1, TKey2> item) => Add(item.Key, item.Value);

        public bool Contains(KeyValuePair<TKey1, TKey2> item) => Contains(item.Key, item.Value);

        public bool Remove(KeyValuePair<TKey1, TKey2> item) => Remove(item.Key, item.Value);

        public void CopyTo(KeyValuePair<TKey1, TKey2>[] array, int arrayIndex)
        {
            
        }

        #endregion
        
        public IEnumerator<KeyValuePair<TKey1, TKey2>> GetEnumerator() =>
            new NoAllocEnumerator<KeyValuePair<TKey1, TKey2>>(_forward.ToArrayPooled());

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}