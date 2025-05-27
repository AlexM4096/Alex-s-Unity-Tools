using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AlexTools.Extensions
{
    public static class TransformExtensions
    {
        public static void UnParent(this Transform transform) => transform.SetParent(null);
        
        #region Reset

        public static void Reset(this Transform transform)
        {
            ResetPosition(transform);
            ResetRotation(transform);
            ResetScale(transform);
        }
            
        public static void ResetPosition(this Transform transform) => 
            transform.position = Vector3.zero;
            
        public static void ResetRotation(this Transform transform) => 
            transform.rotation = Quaternion.identity;
            
        public static void ResetScale(this Transform transform) => 
            transform.localScale = Vector3.one;

        #endregion

        #region Set

        public static void Set(this Transform transform, Transform origin)
        {
            
            SetPosition(transform, origin);
            SetRotation(transform, origin);
            SetScale(transform, origin);
        }
            
        public static void SetPosition(this Transform transform, Transform origin) => 
            transform.position = origin.position;
            
        public static void SetRotation(this Transform transform, Transform origin) => 
            transform.rotation = origin.rotation;
            
        public static void SetScale(this Transform transform, Transform origin) => 
            transform.localScale = origin.localScale;

        #endregion
            
        #region Children

        public static IEnumerable<Transform> Children(this Transform parent)
        {
            var count = parent.childCount;
            var array = new Transform[count];

            for (var i = 0; i < count; i++)
                array[i] = parent.GetChild(i);
            
            return new ReadOnlyCollection<Transform>(array);
        }

        public static void SetActiveChildren(this Transform parent, bool value) =>
            parent.Children().ForEach(child => child.gameObject.SetActive(value));

        public static void EnableChildren(this Transform parent) => 
            parent.Children().ForEach(child => child.gameObject.Enable());
        public static void DisableChildren(this Transform parent) => 
            parent.Children().ForEach(child => child.gameObject.Disable());
            
        public static void DestroyChildren(this Transform parent) => 
            parent.Children().ForEach(child => Object.Destroy(child.gameObject));
        public static void DestroyImmediateChildren(this Transform parent) => 
            parent.Children().ForEach(child => Object.DestroyImmediate(child.gameObject));

        #endregion

        #region Memento

        public static void SetMemento(this Transform transform, ITransformMemento memento) =>
            memento.Restore(transform);

        public static ITransformMemento CreteMemento(this Transform transform, bool local = false) =>
            local ? new LocalTransformMemento(transform) : new GlobalTransformMemento(transform);

        #endregion
    }
}