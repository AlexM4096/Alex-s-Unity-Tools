using System.Collections.Generic;

namespace AlexTools.Collections
{
    public interface IBiMap<TKey1, TKey2> : 
        ICollection<KeyValuePair<TKey1, TKey2>> 
        where TKey1 : notnull
        where TKey2 : notnull
    {
        IReadOnlyDictionary<TKey1, TKey2> Forward { get; }
        IReadOnlyDictionary<TKey2, TKey1> Reverse { get; }
        
        IEnumerable<TKey1> First { get; }
        IEnumerable<TKey2> Second { get; }
        
        TKey1 this[TKey2 key2] { get; set;}
        TKey2 this[TKey1 key1] { get; set;}

        void Add(TKey1 key1, TKey2 key2);

        bool Contains(TKey1 key1, TKey2 key2);

        bool Remove(TKey1 key1);
        bool Remove(TKey2 key2);
        bool Remove(TKey1 key1, TKey2 key2);

        bool TryAdd(TKey1 key1, TKey2 key2);
        
        bool TryGetValue(TKey1 key1, out TKey2 key2);
        bool TryGetValue(TKey2 key2, out TKey1 key1);
    }
}