using System.Collections.Generic;

namespace AlexTools.Collections
{
    public interface IBiMap<TKey1, TKey2> : 
        ICollection<KeyKeyPair<TKey1, TKey2>> 
        where TKey1 : notnull
        where TKey2 : notnull
    {
        TKey1 this[TKey2 key2] { get; set;}
        TKey2 this[TKey1 key1] { get; set;}

        IDictionary<TKey1, TKey2> Forward { get; }
        IDictionary<TKey2, TKey1> Reverse { get; }
        
        void Add(TKey1 key1, TKey2 key2);

        bool ContainsKey(TKey1 key1);
        bool ContainsKey(TKey2 key2);
        
        bool Contains(TKey1 key1, TKey2 key2);

        bool Remove(TKey1 key1);
        bool Remove(TKey2 key2);
        
        bool Remove(TKey1 key1, out TKey2 key2);
        bool Remove(TKey2 key2, out TKey1 key1);

        bool TryAdd(TKey1 key1, TKey2 key2);
        
        bool TryGetValue(TKey1 key1, out TKey2 key2);
        bool TryGetValue(TKey2 key2, out TKey1 key1);
    }
}