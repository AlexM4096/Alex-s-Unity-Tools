using System;
using System.Collections.Generic;
using System.Linq;

namespace AlexTools.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<TEnum> GetFlags<TEnum>(
            this TEnum @enum) where TEnum : Enum => 
            Utils.GetValues<TEnum>().Where(x => @enum.HasFlag(x));
    }
}