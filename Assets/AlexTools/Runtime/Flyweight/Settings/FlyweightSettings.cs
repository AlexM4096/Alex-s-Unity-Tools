using AlexTools.Extensions;
using AlexTools.Serialization;
using UnityEngine;

namespace AlexTools.Flyweight
{
    [CreateAssetMenu(menuName = "Flyweight/Create FlyweightSettings", fileName = "FlyweightSettings")]
    public class FlyweightSettings : ScriptableObject, IFlyweightSettings
    {
        [Header("MonoFlyweight")]
        [SerializeField] private GameObject prefab;
        [SerializeField, TypeFilter(typeof(MonoFlyweight))] 
        private SerializableType flyweightType = typeof(MonoFlyweight);
        [SerializeField] private int preloadAmount = 8;
        
        [Header("ObjectPool")] 
        [SerializeField] private bool collectionCheck = true;
        [SerializeField] private int defaultCapacity = 32;
        [SerializeField] private int maxSize = 64;

        public int PreloadAmount => preloadAmount;
        public bool CollectionCheck => collectionCheck;
        public int DefaultCapacity => defaultCapacity;
        public int MaxSize => maxSize;
        public string PrefabName => prefab.name;

        public virtual MonoFlyweight Create()
        {
            var instance = Instantiate(prefab);
            instance.name = PrefabName;

            var flyweight = instance.GetOrAddComponent(flyweightType) as MonoFlyweight;
            return flyweight;
        }
    }
}