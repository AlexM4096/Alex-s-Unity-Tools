using System;
using Newtonsoft.Json;

namespace AlexTools.Hash
{
    public readonly struct StringKey : IEquatable<StringKey>
    {
        private readonly string _name;
        private readonly int _id;

        public string Name => _name;
        public int ID => _id;
        
        public StringKey(string name, HashFunc hashFunc)
        {
            _name = name;
            _id = hashFunc(name);
        }

        public void Deconstruct(out string name, out int id)
        {
            name = _name;
            id = _id;
        }

        public bool Equals(StringKey other) => _id == other._id;

        public override bool Equals(object obj) => obj is StringKey other && Equals(other);
        public override int GetHashCode() => _id;

        public override string ToString()
        {
#if UNITY_EDITOR
            return $"{_name} ({_id})";
#else
            return _name;
#endif
        }

        public static bool operator ==(StringKey lhs, StringKey rhs) => lhs._id == rhs._id;
        public static bool operator !=(StringKey lhs, StringKey rhs) => lhs._id != rhs._id;

        public static implicit operator StringKey(string name) => new(name, Hash.DefaultFunc);
        public static implicit operator string(StringKey key) => key._name;
        public static implicit operator int(StringKey key) => key._id;
    }
}