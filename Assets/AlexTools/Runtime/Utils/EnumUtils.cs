using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexTools
{
    public static class EnumUtils
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum => Enum.GetValues(typeof(T)).Cast<T>();
    }
}