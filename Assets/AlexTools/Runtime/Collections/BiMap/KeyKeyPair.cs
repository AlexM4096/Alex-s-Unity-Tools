using System.Collections.Generic;

namespace AlexTools.Collections
{
    public static class KeyKeyPair
    {
        public static KeyKeyPair<TKey1, TKey2> Create<TKey1, TKey2>(TKey1 key1, TKey2 key2) => new(key1, key2);
        internal static string PairToString(object key1, object key2) => $"[{key1}, {key2}]";
    }
    
    public readonly struct KeyKeyPair<TKey1, TKey2>
    {
        private readonly TKey1 key1;
        private readonly TKey2 key2;

        public TKey1 Key1 => key1;
        public TKey2 Key2 => key2;
        
        public KeyKeyPair(TKey1 key1, TKey2 key2)
        {
            this.key1 = key1;
            this.key2 = key2;
        }

        public override string ToString() => KeyKeyPair.PairToString(key1, key2);
        
        public void Deconstruct(out TKey1 key1, out TKey2 key2)
        {
            key1 = Key1;
            key2 = Key2;
        }

        public static implicit operator KeyValuePair<TKey1, TKey2>(KeyKeyPair<TKey1, TKey2> pair) =>
            new(pair.Key1, pair.Key2);
        
        public static implicit operator KeyValuePair<TKey2, TKey1>(KeyKeyPair<TKey1, TKey2> pair) =>
            new(pair.Key2, pair.Key1);
    }
}