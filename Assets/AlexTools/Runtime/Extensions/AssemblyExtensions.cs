using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AlexTools.Extensions
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetEnums(this Assembly assembly) => 
            assembly
                .GetTypes()
                .Where(t => t.IsEnum && t.IsPublic);

        public static IEnumerable<Type> GetInterfaces(this Assembly assembly) =>
            assembly
                .GetTypes()
                .Where(t => t.IsInterface && t.IsPublic);

        public static IEnumerable<Type> GetImplementers<T>(this Assembly assembly) =>
            assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(T)));
    }
}