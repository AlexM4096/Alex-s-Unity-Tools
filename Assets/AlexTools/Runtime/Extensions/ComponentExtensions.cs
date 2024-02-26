using UnityEngine;

namespace AlexTools.Extensions
{
    public static class ComponentExtensions
    {
        public static void EnableChildren(this Component component) 
            => component.transform.EnableChildren();
        
        public static void DisableChildren(this Component component) 
            => component.transform.DisableChildren();
        
        public static void DestroyChildren(this Component component) 
            => component.transform.DestroyChildren();
        
        public static void DestroyImmediateChildren(this Component component) 
            => component.transform.DestroyImmediateChildren();
    }
}