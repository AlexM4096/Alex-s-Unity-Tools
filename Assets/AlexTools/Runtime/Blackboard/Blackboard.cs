using System.Collections.Generic;
using AlexTools.Extensions;
using AlexTools.Hash;

namespace AlexTools.Blackboard
{
    [System.Serializable]
    public class Blackboard
    {
        private readonly Dictionary<string, StringKey> _keyRegistry = new();
        private readonly Dictionary<StringKey, BlackboardEntry> _entries = new();

        private readonly IHash _hash;

        public Blackboard(IHash hash = null) => _hash = hash.OrDefault();

        public StringKey GetOrRegisterKey(string name) => _keyRegistry.GetOrAdd(name, CreateKey);
        private StringKey CreateKey(string name) => new(name, _hash);
        
        public void Set<T>(StringKey key, T value) => _entries[key] = new BlackboardEntry<T>(key, value);
        public T Get<T>(StringKey key) => _entries[key].Cast<T>().Value;
        
        public bool TryGetValue<T>(StringKey key, out T value)
        {
            if (_entries.TryGetValue(key, out var entry) && entry.TryCast<T>(out var castedEntry))
            {
                value = castedEntry.Value;
                return true;
            }

            value = default;
            return false;
        }
    }
}