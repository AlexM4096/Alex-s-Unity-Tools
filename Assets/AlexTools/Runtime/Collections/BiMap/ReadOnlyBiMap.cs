using System;
using System.Collections;
using System.Collections.Generic;

namespace AlexTools.Collections
{
    // public sealed class ReadOnlyBiMap<TKey1, TKey2> : 
    //     IBiMap<TKey1, TKey2>, 
    //     IReadOnlyBiMap<TKey1, TKey2>
    //     where TKey1 : notnull
    //     where TKey2 : notnull
    // {
    //     private readonly BiMap<TKey1, TKey2> _biMap;
    //
    //     public ReadOnlyBiMap(BiMap<TKey1, TKey2> biMap)
    //     {
    //         _biMap = biMap;
    //     }
    //
    //     public int Count => _biMap.Count;
    //     public bool IsReadOnly => true;
    //
    //     public TKey1 this[TKey2 key2]
    //     {
    //         get => throw new System.NotImplementedException();
    //         set => throw new System.NotImplementedException();
    //     }
    //
    //     public TKey2 this[TKey1 key1]
    //     {
    //         get => throw new System.NotImplementedException();
    //         set => throw new System.NotImplementedException();
    //     }
    //
    //     public void Add(TKey1 key1, TKey2 key2)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Contains(TKey1 key1, TKey2 key2)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Remove(TKey1 key1)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Remove(TKey2 key2)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Remove(TKey1 key1, out TKey2 key2)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Remove(TKey2 key2, out TKey1 key1)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool TryAdd(TKey1 key1, TKey2 key2)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool TryGetValue(TKey1 key1, out TKey2 key2)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool TryGetValue(TKey2 key2, out TKey1 key1)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     #region Collection
    //
    //     public IEnumerator<KeyKeyPair<TKey1, TKey2>> GetEnumerator()
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     IEnumerator IEnumerable.GetEnumerator()
    //     {
    //         return GetEnumerator();
    //     }
    //
    //     public void Add(KeyKeyPair<TKey1, TKey2> item)
    //     {
    //         throw new NotSupportedException();
    //     }
    //
    //     public void Clear()
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Contains(KeyKeyPair<TKey1, TKey2> item)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public void CopyTo(KeyKeyPair<TKey1, TKey2>[] array, int arrayIndex)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public bool Remove(KeyKeyPair<TKey1, TKey2> item)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     #endregion
    // }
}