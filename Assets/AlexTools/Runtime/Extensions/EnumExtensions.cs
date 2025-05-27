using System;
using System.Collections.Generic;
using System.Linq;
using AlexTools.Random;

namespace AlexTools.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> GetFlags<T>(this T @enum) where T : struct, Enum => 
            EnumUtils.GetValues<T>().Where(flag => @enum.HasFlag(flag));

        #region Random

        public static T OrRandom<T>(this T? @enum, IRandom random = null) where T : struct, Enum => 
            @enum ?? random.OrDefault().GetEnum<T>();

        public static T OrRandomFlags<T>(this T? @enum, IRandom random = null) where T : struct, Enum => 
            @enum ?? random.OrDefault().GetEnumWithFlags<T>();

        #endregion
    }
}