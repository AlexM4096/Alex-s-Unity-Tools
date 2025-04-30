using System;
using System.Collections.Generic;
using AlexTools.Extensions;
using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace AlexTools.Flyweight
{
    public class FlyweightFactory : IFlyweightFactory, IDisposable
    {
        private readonly Dictionary<IFlyweightSettings, SubFactory> _subFactories = new();
        private readonly Transform _origin;
   
        public FlyweightFactory(Transform origin = null, IEnumerable<IFlyweightSettings> settingsToAdd = null)
        {
            _origin = origin ?? CreateOrigin();
            settingsToAdd?.ForEach(AddSettings);
        }

        private static Transform CreateOrigin() => new GameObject { name = "FlyweightFactory" }.transform;
        
        public void AddSettings(IFlyweightSettings settings) => GetOrAddSubFactory(settings);
        public MonoFlyweight Get(IFlyweightSettings settings) => GetOrAddSubFactory(settings).Get();
        public void Release(MonoFlyweight flyweight) => GetOrAddSubFactory(flyweight.Settings).Release(flyweight);
        
        private SubFactory GetOrAddSubFactory(IFlyweightSettings settings) => 
            _subFactories.GetOrAdd(settings, CreateSubFactory);

        private SubFactory CreateSubFactory(IFlyweightSettings settings) => new(this, settings);

        public void Dispose()
        {
            _subFactories.Values.ForEach(subFactory => subFactory.Dispose());
            _subFactories.Clear();
        }
        
        private class SubFactory : IDisposable
        {
            private readonly FlyweightFactory _parent;
            private readonly IFlyweightSettings _settings;
                       
            private readonly Transform _spawnOrigin;
            private readonly IObjectPool<MonoFlyweight> _pool;
                
            public SubFactory(FlyweightFactory parent, IFlyweightSettings settings)
            {
                _parent = parent;
                _settings = settings;
                           
                _spawnOrigin = CreateSpawnOrigin();
                _pool = new ObjectPool<MonoFlyweight>(
                    Create,
                    settings.OnGet,
                    settings.OnRelease,
                    settings.OnDestroy,
                    settings.CollectionCheck,
                    settings.DefaultCapacity,
                    settings.MaxSize
                ).AsPreloaded(settings.PreloadAmount);
            }
                       
            private Transform CreateSpawnOrigin()
            {
                var spawnOrigin = new GameObject { name = $"{_settings.PrefabName} Pool" }.transform;
                spawnOrigin.SetParent(_parent._origin);
                return spawnOrigin;
            }
            
            private MonoFlyweight Create()
            {
                var flyweight = _settings.Create();
                           
                flyweight.Initialize(_settings, _parent);
                flyweight.transform.SetParent(_spawnOrigin);
                           
                return flyweight;
            }
                       
            public MonoFlyweight Get() => _pool.Get();
            public void Release(MonoFlyweight flyweight) => _pool.Release(flyweight);
        
            public void Dispose()
            {
                _pool.Clear();
                Object.Destroy(_spawnOrigin.gameObject);
            }
        }
    }
}