using System;
using UnityEngine;

namespace AlexTools.Extensions
{
    public static class ComponentExtensions
    {
        public static T GetOrAddComponent<T>(this Component component) where T : Component =>
            component.gameObject.GetOrAddComponent<T>();
        public static Component GetOrAddComponent(this Component component, Type type) =>
            component.gameObject.GetOrAddComponent(type);

        public static bool HasComponent<T>(this Component component) where T : Component =>
            component.gameObject.HasComponent<T>();
        public static bool HasComponent(this Component component, Type type) =>
            component.gameObject.HasComponent(type);
        
        public static bool RemoveComponent<T>(this Component component) where T : Component =>
            component.gameObject.RemoveComponent<T>();
        public static bool RemoveComponent(this Component component, Type type) =>
            component.gameObject.RemoveComponent(type);

        public static void RemoveAllComponents<T>(this Component component) where T : Component =>
            component.gameObject.RemoveAllComponents<T>();
        public static void RemoveAllComponents(this Component component, Type type) =>
            component.gameObject.RemoveAllComponents(type);
    }
}