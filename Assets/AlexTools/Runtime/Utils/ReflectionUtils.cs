using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AlexTools
{
    public static class ReflectionUtils
    {
        public static IEnumerable<Assembly> GetAllAssemblies() => AppDomain.CurrentDomain.GetAssemblies();
        public static IEnumerable<Type> GetAllTypes() => GetAllAssemblies().SelectMany(a => a.GetTypes());
    }
}