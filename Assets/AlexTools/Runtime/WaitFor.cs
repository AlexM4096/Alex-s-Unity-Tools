using System.Collections.Generic;
using AlexTools.Comparers;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools
{
    public static class WaitFor
    {
        private static readonly Dictionary<float, WaitForSeconds> SecondsDictionary;
        private static readonly Dictionary<float, WaitForSecondsRealtime> SecondsRealtimeDictionary;

        private static float FrameDurationInSeconds => 1f / Application.targetFrameRate;
        
        public static readonly WaitForEndOfFrame EndOfFrame;
        public static readonly WaitForFixedUpdate FixedUpdate;
        
        public static int SecondsDictionaryCapacity { get; set; } = 64;
        public static int SecondsRealtimeDictionaryCapacity { get; set; } = 8;

        static WaitFor()
        {
            var floatComparer = FloatComparer.Instance;
            SecondsDictionary = new(SecondsDictionaryCapacity, floatComparer);
            SecondsRealtimeDictionary = new(SecondsRealtimeDictionaryCapacity, floatComparer);

            EndOfFrame = new WaitForEndOfFrame();
            FixedUpdate = new WaitForFixedUpdate();
        }
        
        public static WaitForSeconds Seconds(float seconds) =>
            seconds < FrameDurationInSeconds ? null : SecondsDictionary.GetOrAdd(seconds, CreateSeconds);
        public static WaitForSecondsRealtime SecondsRealtime(float seconds) =>
            seconds < FrameDurationInSeconds ? null : SecondsRealtimeDictionary.GetOrAdd(seconds, CreateSecondsRealtime);

        public static void Clear()
        {
            SecondsDictionary.Clear();
            SecondsDictionary.TrimExcess(SecondsDictionaryCapacity);
            
            SecondsRealtimeDictionary.Clear();
            SecondsRealtimeDictionary.TrimExcess(SecondsRealtimeDictionaryCapacity);
        }
        
        private static WaitForSeconds CreateSeconds(float seconds) => new(seconds);
        private static WaitForSecondsRealtime CreateSecondsRealtime(float seconds) => new(seconds);
    }
}