using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AlexTools.Extensions;

namespace AlexTools.Collections
{
    public sealed class BiMap<TKey1, TKey2> : 
        IBiMap<TKey1, TKey2>, 
        IReadOnlyBiMap<TKey1, TKey2>,
        IDeserializationCallback,
        ISerializable
        where TKey1 : notnull
        where TKey2 : notnull
    {
        private readonly Dictionary<TKey1, int> key1Registry;
        private readonly Dictionary<TKey2, int> key2Registry;

        private readonly List<KeyKeyPair<TKey1, TKey2>> list;
        
        private readonly ForwardDictionary forward;
        private readonly ReverseDictionary reverse;
        
        public int Count => list.Count;
        public bool IsReadOnly => false;

        public TKey1 this[TKey2 key2]
        {
            get
            {
                var index = key2Registry[key2];
                return list[index].Key1;
            }
            set
            {
                if (!key2Registry.TryGetValue(key2, out var index2))
                {
                    Add(value, key2);
                    return;
                }
                
                var key1 = list[index2].Key1;
                
                key1Registry.Remove(key1);
                key1Registry.Add(value, index2);
                
                list[index2] = KeyKeyPair.Create(value, key2);
            }
        }

        public TKey2 this[TKey1 key1]
        {
            get
            {
                var index = key1Registry[key1];
                return list[index].Key2;
            }
            set
            {
                if (!key1Registry.TryGetValue(key1, out var index1))
                {
                    Add(key1, value);
                    return;
                }
                
                var key2 = list[index1].Key2;
                
                key2Registry.Remove(key2);
                key2Registry.Add(value, index1);
                
                list[index1] = KeyKeyPair.Create(key1, value);
            }
        }

        public ForwardDictionary Forward => forward;
        public ReverseDictionary Reverse => reverse;

        IDictionary<TKey1, TKey2> IBiMap<TKey1, TKey2>.Forward => forward;
        IDictionary<TKey2, TKey1> IBiMap<TKey1, TKey2>.Reverse => reverse;
        
        IReadOnlyDictionary<TKey1, TKey2> IReadOnlyBiMap<TKey1, TKey2>.Forward => forward;
        IReadOnlyDictionary<TKey2, TKey1> IReadOnlyBiMap<TKey1, TKey2>.Reverse => reverse;

        public BiMap()
        {
            key1Registry = new Dictionary<TKey1, int>();
            key2Registry = new Dictionary<TKey2, int>();

            list = new List<KeyKeyPair<TKey1, TKey2>>();

            forward = new ForwardDictionary(this);
            reverse = new ReverseDictionary(this);
        }

        public void Add(TKey1 key1, TKey2 key2)
        {
            var index = Count;
            
            key1Registry.Add(key1, index);
            key2Registry.Add(key2, index);
            
            list.Add(KeyKeyPair.Create(key1, key2));
        }

        public bool ContainsKey(TKey1 key1) => key1Registry.ContainsKey(key1);
        public bool ContainsKey(TKey2 key2) => key2Registry.ContainsKey(key2);

        public bool Contains(TKey1 key1, TKey2 key2)
        {
            if (!key1Registry.TryGetValue(key1, out var index1) || !key2Registry.TryGetValue(key2, out var index2))
                return false;

            return index1 == index2;
        }

        public bool Remove(TKey1 key1)
        {
            if (!key1Registry.TryGetValue(key1, out var index))
                return false;
            
            PopAt(index);
            return true;
        }

        public bool Remove(TKey2 key2)
        {
            if (!key2Registry.TryGetValue(key2, out var index))
                return false;
            
            PopAt(index);
            return true;
        }

        public bool Remove(TKey1 key1, out TKey2 key2)
        {
            if (!key1Registry.TryGetValue(key1, out var index))
            {
                key2 = default;
                return false;
            }
            
            key2 = PopAt(index).Key2;
            return true;
        }

        public bool Remove(TKey2 key2, out TKey1 key1)
        {
            if (!key2Registry.TryGetValue(key2, out var index))
            {
                key1 = default;
                return false;
            }
            
            key1 = PopAt(index).Key1;
            return true;
        }

        public bool TryAdd(TKey1 key1, TKey2 key2)
        {
            if (Contains(key1, key2)) return false;
            
            Add(key1, key2);
            return true;
        }

        public bool TryGetValue(TKey1 key1, out TKey2 key2)
        {
            if (key1Registry.TryGetValue(key1, out var index))
            {
                key2 = list[index].Key2;
                return true;
            }

            key2 = default;
            return false;
        }

        public bool TryGetValue(TKey2 key2, out TKey1 key1)
        {
            if (key2Registry.TryGetValue(key2, out var index))
            {
                key1 = list[index].Key1;
                return true;
            }

            key1 = default;
            return false;
        }
        
        private KeyKeyPair<TKey1, TKey2> PopAt(int index)
        {
            var pair = list.PopAt(index);

            key1Registry.Remove(pair.Key1);
            key2Registry.Remove(pair.Key2);

            using var enumerator1 = key1Registry.GetEnumerator();
            using var enumerator2 = key2Registry.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                var (key1, index1) = enumerator1.Current;
                if (index1 > index) key1Registry[key1] = index1 - 1;
                
                var (key2, index2) = enumerator2.Current;
                if (index2 > index) key2Registry[key2] = index2 - 1;
            }

            return pair;
        }

        #region Collection

        public void Add(KeyKeyPair<TKey1, TKey2> pair)
        {
            if (Contains(pair))
            {
                throw null;
            }
            
            var index = Count;
            var (key1, key2) = pair;
            
            key1Registry.Add(key1, index);
            key2Registry.Add(key2, index);
            
            list.Add(pair);
        }

        public void Clear()
        {
            key1Registry.Clear();
            key2Registry.Clear();
            
            list.Clear();
        }

        public bool Contains(KeyKeyPair<TKey1, TKey2> pair) => Contains(pair.Key1, pair.Key2);

        public void CopyTo(KeyKeyPair<TKey1, TKey2>[] array, int arrayIndex) => list.CopyTo(array, arrayIndex);

        public bool Remove(KeyKeyPair<TKey1, TKey2> pair)
        {
            var (key1, key2) = pair;
            return Remove(key1) || Remove(key2);
        }

        public IEnumerator<KeyKeyPair<TKey1, TKey2>> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        
        public void OnDeserialization(object sender)
        {
            
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }

        public sealed class ForwardDictionary : IDictionary<TKey1, TKey2>, IReadOnlyDictionary<TKey1, TKey2>
        {
            private readonly BiMap<TKey1, TKey2> _parent;

            public int Count => _parent.Count;
            public bool IsReadOnly => false;

            public TKey2 this[TKey1 key]
            {
                get => _parent[key];
                set => _parent[key] = value;
            }

            IEnumerable<TKey1> IReadOnlyDictionary<TKey1, TKey2>.Keys => Keys;
            IEnumerable<TKey2> IReadOnlyDictionary<TKey1, TKey2>.Values => Values;

            public ICollection<TKey1> Keys => _parent.key1Registry.Keys;
            public ICollection<TKey2> Values => _parent.key2Registry.Keys;

            public ForwardDictionary(BiMap<TKey1, TKey2> parent) => _parent = parent;

            public void Add(KeyValuePair<TKey1, TKey2> pair) => _parent.Add(pair.Key, pair.Value);
            public void Clear() => _parent.Clear();
            public bool Contains(KeyValuePair<TKey1, TKey2> pair) => _parent.Contains(pair.Key, pair.Value);
            public void CopyTo(KeyValuePair<TKey1, TKey2>[] array, int arrayIndex) { throw null; }
            public bool Remove(KeyValuePair<TKey1, TKey2> pair) => _parent.Remove(pair.Key) || _parent.Remove(pair.Value);
            public void Add(TKey1 key, TKey2 value) => _parent.Add(key, value);
            public bool ContainsKey(TKey1 key) => _parent.ContainsKey(key);
            public bool Remove(TKey1 key) => _parent.Remove(key);
            public bool TryGetValue(TKey1 key, out TKey2 value) => _parent.TryGetValue(key, out value);
            public IEnumerator<KeyValuePair<TKey1, TKey2>> GetEnumerator() { throw null; }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
        
        public sealed class ReverseDictionary : IDictionary<TKey2, TKey1>, IReadOnlyDictionary<TKey2, TKey1>
        {
            private readonly BiMap<TKey1, TKey2> _parent;

            public int Count => _parent.Count;
            public bool IsReadOnly => false;

            public TKey1 this[TKey2 key]
            {
                get => _parent[key];
                set => _parent[key] = value;
            }

            IEnumerable<TKey2> IReadOnlyDictionary<TKey2, TKey1>.Keys => Keys;
            IEnumerable<TKey1> IReadOnlyDictionary<TKey2, TKey1>.Values => Values;

            public ICollection<TKey2> Keys => _parent.key2Registry.Keys;
            public ICollection<TKey1> Values => _parent.key1Registry.Keys;

            public ReverseDictionary(BiMap<TKey1, TKey2> biMap) => _parent = biMap;

            public void Add(KeyValuePair<TKey2, TKey1> pair) => _parent.Add(pair.Value, pair.Key);
            public void Clear() => _parent.Clear();
            public bool Contains(KeyValuePair<TKey2, TKey1> pair) => _parent.Contains(pair.Value, pair.Key);
            public void CopyTo(KeyValuePair<TKey2, TKey1>[] array, int arrayIndex)  { throw null; }
            public bool Remove(KeyValuePair<TKey2, TKey1> pair) => _parent.Remove(pair.Key) || _parent.Remove(pair.Value);
            public void Add(TKey2 key, TKey1 value) => _parent.Add(value, key);
            public bool ContainsKey(TKey2 key) => _parent.ContainsKey(key);
            public bool Remove(TKey2 key) => _parent.Remove(key);
            public bool TryGetValue(TKey2 key, out TKey1 value) => _parent.TryGetValue(key, out value);
            public IEnumerator<KeyValuePair<TKey2, TKey1>> GetEnumerator() { throw null; }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}