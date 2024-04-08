using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AlexTools.Extensions
{
    public static class TransformExtensions
    {
        #region Reset

        public static void Reset(this Transform transform)
        {
            transform.ResetPosition();
            transform.ResetRotation();
            transform.ResetScale();
        }
        
        public static void ResetPosition(this Transform transform) 
            => transform.position = Vector3.zero;
        
        public static void ResetRotation(this Transform transform) 
            => transform.rotation = Quaternion.identity;
        
        public static void ResetScale(this Transform transform) 
            => transform.localScale = Vector3.one;

        #endregion

        #region Children

        public static IEnumerable<Transform> Children(this Transform parent) 
        {
            foreach (Transform child in parent)
                yield return child;
        }

        public static void EnableChildren(this Transform parent) => 
            parent.ForEveryChild(child => child.gameObject.Enable());
        
        public static void DisableChildren(this Transform parent) => 
            parent.ForEveryChild(child => child.gameObject.Disable());
        
        public static void DestroyChildren(this Transform parent) => 
            parent.ForEveryChild(child => Object.Destroy(child.gameObject));

        public static void DestroyImmediateChildren(this Transform parent) => 
            parent.ForEveryChild(child => Object.DestroyImmediate(child.gameObject));

        public static void ForEveryChild(this Transform parent, Action<Transform> action) 
        {
            for (var i = parent.childCount - 1; i >= 0; i--)
                action(parent.GetChild(i));
        }

        #endregion
    }
}