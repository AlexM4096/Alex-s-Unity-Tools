using System.Collections.Generic;

namespace AlexTools.Blackboard
{
    [System.Serializable]
    public class Blackboard
    {
        private Dictionary<string, BlackboardKey> _keys;
        private Dictionary<BlackboardKey, object> _values;

        public T Get<T>(BlackboardKey key) => (T)_values[key];
        public void Set<T>(BlackboardKey key, T value) => _values[key] = value;
    }
}