using AlexTools.Hash;
using System;

namespace AlexTools.Blackboard
{
    public readonly struct BlackboardKey : IEquatable<BlackboardKey>
    {
        public readonly string name;
        public readonly int id;

        public BlackboardKey(string name, IHash hash)
        {
            this.name = name;
            id = hash.Hash(name);
        }

        public bool Equals(BlackboardKey other) => id == other.id;

        public override bool Equals(object obj) => obj is BlackboardKey other && Equals(other);
        public override int GetHashCode() => id;
        public override string ToString() => name;

        public static bool operator ==(BlackboardKey lhs, BlackboardKey rhs) => lhs.id == rhs.id;
        public static bool operator !=(BlackboardKey lhs, BlackboardKey rhs) => !(lhs == rhs);
    }
}