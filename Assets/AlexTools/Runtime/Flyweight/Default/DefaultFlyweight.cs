using System;

namespace AlexTools.Flyweight.Default
{
    public abstract class DefaultFlyweight<TFlyweight, TSettings> : 
        IFlyweight<TFlyweight, TSettings>, IDisposable
        where TFlyweight : DefaultFlyweight<TFlyweight, TSettings>, new()
        where TSettings : DefaultFlyweightSettings<TFlyweight, TSettings>
    {
        public TSettings Settings { get; private set; }
        public virtual void Release() => Settings.Release(this);
        
        public void Initialize(TSettings settings) => Settings = settings;
        public virtual void Dispose() => Release();

        public static implicit operator TFlyweight(DefaultFlyweight<TFlyweight, TSettings> flyweight)
            => (TFlyweight)flyweight;
    }
}