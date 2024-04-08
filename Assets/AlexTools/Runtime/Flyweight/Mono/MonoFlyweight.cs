using AlexTools.Attributes;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AlexTools.Flyweight
{
    public abstract class MonoFlyweight<TFlyweight, TSettings> :
        MonoBehaviour, IFlyweight<TFlyweight, TSettings>
        where TFlyweight : MonoFlyweight<TFlyweight, TSettings>
        where TSettings : MonoFlyweightSettings<TFlyweight, TSettings>
    {
        [field: SerializeField]
        public TSettings Settings { get; private set; }
        
        public virtual void Release() => Settings.Release(this);
        public virtual void Initialize(TSettings settings) => Settings = settings;

        public new static void Destroy(Object obj)
        {
            if (obj is TFlyweight flyweight)
                flyweight.Release();
            else
                Object.Destroy(obj);
        }
        
        public static implicit operator TFlyweight(MonoFlyweight<TFlyweight, TSettings> flyweight)
            => (TFlyweight)flyweight;
    }
}