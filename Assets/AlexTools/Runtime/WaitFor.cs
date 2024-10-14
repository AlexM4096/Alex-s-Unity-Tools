using System.Collections.Generic;
using AlexTools.Comparers;
using UnityEngine;

namespace AlexTools
{
    public static class WaitFor
    {
        private const int DictionaryCapacity = 100;

        private static readonly float FrameDurationInSeconds;
        private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDictionary;

        public readonly static WaitForEndOfFrame EndOfFrame;
        public readonly static WaitForFixedUpdate FixedUpdate;

        static WaitFor()
        {
            FrameDurationInSeconds = 1f / Application.targetFrameRate;
            WaitForSecondsDictionary = new(DictionaryCapacity, new FloatComparer());

            EndOfFrame = new WaitForEndOfFrame();
            FixedUpdate = new WaitForFixedUpdate();
        }
        
        public static WaitForSeconds Seconds(float seconds) 
        {
            if (seconds < FrameDurationInSeconds) return null;

            if (WaitForSecondsDictionary.TryGetValue(seconds, out var value)) 
                return value;
                
            value = new WaitForSeconds(seconds);
            WaitForSecondsDictionary.Add(seconds, value);    
            
            return value;
        }
    }
}