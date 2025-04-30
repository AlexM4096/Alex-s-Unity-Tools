using UnityEngine;

namespace AlexTools
{
    public readonly struct LocalTransformMemento : ITransformMemento
    {
        public readonly Vector3 localPosition;
        public readonly Quaternion localRotation;
        public readonly Vector3 localScale;
        
        public LocalTransformMemento(Transform transform)
        {
            localPosition = transform.localPosition;
            localRotation = transform.localRotation;
            localScale = transform.localScale;
        }
        
        public void Restore(Transform transform)
        {
            transform.localPosition = localPosition;
            transform.localRotation = localRotation;
            transform.localScale = localPosition;
        }
    }
}