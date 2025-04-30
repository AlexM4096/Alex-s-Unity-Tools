using System;

namespace AlexTools.Hash
{
    public readonly struct StringKey : IEquatable<StringKey>
    {
        private readonly string _name;
        private readonly int _id;

        public string Name => _name;
        public int ID => _id;

        public StringKey(string name, IHash hash)
        {
            _name = name;
            _id = hash.Hash(name);
        }

        public void Deconstruct(out string name, out int id)
        {
            name = Name;
            id = ID;
        }

        public bool Equals(StringKey other) => _id == other._id;

        public override bool Equals(object obj) => obj is StringKey other && Equals(other);
        public override int GetHashCode() => _id;
        public override string ToString() => _name;

        public static bool operator ==(StringKey lhs, StringKey rhs) => lhs._id == rhs._id;
        public static bool operator !=(StringKey lhs, StringKey rhs) => lhs._id != rhs._id;
    }
}