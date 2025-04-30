using System;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Serialization
{
    [Serializable]
    public class SerializableType : ISerializationCallbackReceiver
    {
        [SerializeField] private string assemblyQualifiedName = string.Empty;
        
        public Type Type { get; private set; }

        private SerializableType(Type type) => Type = type;
        
        void ISerializationCallbackReceiver.OnBeforeSerialize() 
        {
            assemblyQualifiedName = Type?.AssemblyQualifiedName ?? assemblyQualifiedName;
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize() 
        {
            if (assemblyQualifiedName.TryGetType(out var type)) 
            {
                Type = type;
                return;
            }
            
            Debug.LogError($"Type {assemblyQualifiedName} not found");
        }
        
        public static implicit operator Type(SerializableType serializableType) => serializableType.Type;
        public static implicit operator SerializableType(Type type) => new(type);
    }
}