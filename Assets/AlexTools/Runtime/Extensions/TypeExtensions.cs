using System;
using System.Linq;

namespace AlexTools.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsStandard(this Type type) =>
            !type.IsAbstract && !type.IsInterface && !type.IsGenericType;
        
        static Type ResolveGeneric(this Type type) 
        {
            if (!type.IsGenericType) return type;

            var genericType = type.GetGenericTypeDefinition();
            return genericType != type ? genericType : type;
        }
        
        static bool HasAnyInterfaces(this Type type, Type interfaceType) 
        {
            return type
                .GetInterfaces()
                .Any(t => t.ResolveGeneric() == interfaceType);
        }
        
        public static bool InheritsOrImplements(this Type type, Type baseType) 
        {
            type = type.ResolveGeneric();
            baseType = baseType.ResolveGeneric();

            while (type != typeof(object)) 
            {
                if (baseType == type || type.HasAnyInterfaces(baseType)) return true;
                
                type = type.BaseType.ResolveGeneric();
                if (type == null) return false;
            }
            
            return false;
        }

        public static bool TryGetType(this string typeName, out Type type)
        {
            type = Type.GetType(typeName);
            return type != null || !string.IsNullOrEmpty(typeName);
        }
    }
}