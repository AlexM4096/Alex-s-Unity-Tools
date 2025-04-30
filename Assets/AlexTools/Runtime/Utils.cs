using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AlexTools
{
    public static class Utils
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>();

        public static IEnumerable<Assembly> GetAllAssemblies() => AppDomain.CurrentDomain.GetAssemblies();
        public static IEnumerable<Type> GetAllTypes() => GetAllAssemblies().SelectMany(a => a.GetTypes());
    }
}