using System;
using AlexTools.Hash;

namespace AlexTools.Blackboard
{
    public abstract class BlackboardEntry
    {
        public readonly StringKey Key;

        protected BlackboardEntry(StringKey key) => Key = key;

        public BlackboardEntry<T> Cast<T>() => (BlackboardEntry<T>)this;
        public bool TryCast<T>(out BlackboardEntry<T> entry)
        {
            entry = this as BlackboardEntry<T>;
            return entry != null;
        }
    }
    
    public sealed class BlackboardEntry<T> : BlackboardEntry, IDisposable
    {
        public readonly T Value;

        public BlackboardEntry(StringKey key, T value) : base(key) => Value = value;

        void IDisposable.Dispose()
        {
            if (Value is IDisposable disposable)
                disposable.Dispose();
        }
    }
}