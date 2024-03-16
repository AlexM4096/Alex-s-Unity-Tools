using System.Collections.Generic;

namespace AlexTools.Collections
{
    public interface IReadOnlyBiMap<TKey1, TKey2> : 
        IReadOnlyCollection<KeyValuePair<TKey1, TKey2>>
        where TKey1 : notnull
        where TKey2 : notnull
    {
        IReadOnlyDictionary<TKey1, TKey2> Forward { get; }
        IReadOnlyDictionary<TKey2, TKey1> Reverse { get; }

        TKey1 this[TKey2 key2] { get; }
        TKey2 this[TKey1 key1] { get; }

        bool Contains(TKey1 key1, TKey2 key2);
        
        bool TryGetValue(TKey1 key1, out TKey2 key2);
        bool TryGetValue(TKey2 key2, out TKey1 key1);
    }
}