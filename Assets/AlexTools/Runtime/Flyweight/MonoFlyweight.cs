using System;
using UnityEngine;

namespace AlexTools.Flyweight
{
    public class MonoFlyweight : MonoBehaviour, IEquatable<MonoFlyweight>
    {
        public IFlyweightSettings Settings { get; private set; }
        public IFlyweightFactory Factory { get; private set; }

        public void Initialize(IFlyweightSettings settings, IFlyweightFactory factory)
        {
            Settings = settings;
            Factory = factory;
        }

        public bool ReleaseSelf()
        {
            if (Factory == null) return false;
            
            Factory.Release(this);
            return true;
        }
        
        public virtual MonoFlyweight CreateCopy() => Factory.Get(Settings);
        public virtual bool Equals(MonoFlyweight other) => other && Settings == other.Settings;
    }
}