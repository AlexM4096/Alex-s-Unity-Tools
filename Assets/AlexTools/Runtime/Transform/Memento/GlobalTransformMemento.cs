using UnityEngine;

namespace AlexTools
{
    public readonly struct GlobalTransformMemento : ITransformMemento
    {
        public readonly Vector3 position;
        public readonly Quaternion rotation;
        public readonly Vector3 localScale;
        
        public GlobalTransformMemento(Transform transform)
        {
            position = transform.position;
            rotation = transform.rotation;
            localScale = transform.localScale;
        }

        public void Restore(Transform transform)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = localScale;
        }
    }
}