using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Flyweight
{
    public interface IFlyweightSettings
    {
        int PreloadAmount { get; }
        bool CollectionCheck { get; }
        int DefaultCapacity { get; }
        int MaxSize { get; }
        string PrefabName { get; }

        MonoFlyweight Create();

        public void OnGet(MonoFlyweight flyweight) => flyweight.gameObject.Enable();
        public void OnRelease(MonoFlyweight flyweight) => flyweight.gameObject.Disable();
        public void OnDestroy(MonoFlyweight flyweight) => Object.Destroy(flyweight.gameObject);
    }
}