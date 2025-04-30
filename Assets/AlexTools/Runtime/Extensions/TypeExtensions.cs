using System;
using System.Linq;

namespace AlexTools.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsStandard(this Type type) =>
            !type.IsAbstract && !type.IsInterface && !type.IsGenericType;
        
        private static Type ResolveGeneric(this Type type) 
        {
            if (type is not { IsGenericType: true }) return type;

            var genericType = type.GetGenericTypeDefinition();
            return genericType != type ? genericType : type;
        }
        
        public static bool HasInterface(this Type type, Type interfaceType) =>
            type
                .GetInterfaces()
                .Any(i => i.ResolveGeneric() == interfaceType);

        public static bool InheritsOrImplements(this Type type, Type baseType) 
        {
            type = type.ResolveGeneric();
            baseType = baseType.ResolveGeneric();

            while (type != typeof(object)) 
            {
                if (baseType == type || type.HasInterface(baseType)) return true;
                
                type = type.BaseType.ResolveGeneric();
                if (type == null) return false;
            }
            
            return false;
        }

        public static bool TryGetType(this string typeName, out Type type)
        {
            if (typeName.IsNullOrEmpty())
            {
                type = default;
                return false;
            }
            
            type = Type.GetType(typeName);
            return type != null;
        }

        public static string GetReflectedName(this Type type, string format = "{1} (from {0})") =>
            type.ReflectedType == null ? type.Name : string.Format(format, type.ReflectedType.Name, type.Name);
    }
}