using System;
using System.Linq;
using AlexTools.Flyweight;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AlexTools.Extensions
{
    public static class GameObjectExtensions
    {
        public static void Enable(this GameObject gameObject) => gameObject.SetActive(true);
        public static void Disable(this GameObject gameObject) => gameObject.SetActive(false);

        #region ComponentBase

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent(out T component))
                component = gameObject.AddComponent<T>();

            return component;
        }
        
        public static Component GetOrAddComponent(this GameObject gameObject, Type type)
        {
            if (!gameObject.TryGetComponent(type, out var component))
                component = gameObject.AddComponent(type);

            return component;
        }

        public static bool HasComponent<T>(this GameObject gameObject) where T : Component => 
            gameObject.GetComponent<T>();
        
        public static bool HasComponent(this GameObject gameObject, Type type) => 
            gameObject.GetComponent(type);

        public static bool RemoveComponent<T>(this GameObject gameObject) where T : Component
        {
            if (!gameObject.TryGetComponent(out T component))
                return false;
            
            Object.Destroy(component);
            return true;
        }
        
        public static bool RemoveComponent(this GameObject gameObject, Type type)
        {
            if (!gameObject.TryGetComponent(type, out var component))
                return false;
            
            Object.Destroy(component);
            return true;
        }
        
        public static void RemoveAllComponents<T>(this GameObject gameObject) where T : Component
        {
            var components = gameObject.GetComponents<T>();
            components.ForEach(Object.Destroy);
        }
        
        public static void RemoveAllComponents(this GameObject gameObject, Type type)
        {
            var components = gameObject.GetComponents(type);
            components.ForEach(Object.Destroy);
        }

        #endregion

        #region Flyweight

        public static void ReleaseOrDestroy(this GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out MonoFlyweight flyweight) && flyweight.ReleaseSelf())
                return;
            
            Object.Destroy(gameObject);
        }

        #endregion

        #region Path

        public static string GetPath(this GameObject gameObject, bool isFullPath = true)
        {
            var origin = isFullPath ? gameObject.transform : gameObject.transform.parent;
            return string.Join('/', origin
                .GetComponentsInParent<Transform>()
                .Select(t => t.name)
                .Reverse());
        }
    
        public static GameObject InstantiateAt(this GameObject prefab, string path, bool isFullPath = true)
        {
            var names = path.Split('/');

            var origin = GameObject.Find(names.First())?.transform;
            
            if (origin.IsNull())
            {
                
                return null;
            }

            var length = isFullPath ? names.Length - 1 : names.Length;
            for (var i = 1; i < length; i++)
            {
                var name = names[i];
                
                origin = origin.Children().FirstOrDefault(x => x.name == name);
                if (origin.IsNotNull()) continue;
                
                
                return null;
            }

            var instance = Object.Instantiate(prefab, origin);
            if (isFullPath) instance.name = names.Last();

            return instance;
        }

        #endregion
    }
}