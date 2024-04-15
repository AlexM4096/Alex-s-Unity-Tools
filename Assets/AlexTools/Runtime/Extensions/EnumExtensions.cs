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
        
        // public static void ForEachFlag<TEnum>(this TEnum @enum,
        //     Action<TEnum> action) where TEnum : Enum =>
        //     @enum.GetFlags().ForEach(action);
        //
        // public static IEnumerable<TResult> SelectFromFlag<TEnum, TResult>(this TEnum @enum,
        //     Func<TEnum, TResult> switchFunc) where TEnum : Enum =>
        //     @enum.GetFlags().Select(switchFunc);
    }
}