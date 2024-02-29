using System.Collections.Generic;
using AlexTools.Classes;
using UnityEngine;

namespace AlexTools
{
    public static class Waiters
    {
        private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDictionary = 
            new(100, new FloatComparer());

        public static WaitForSeconds GetWaitForSeconds(float seconds) 
        {
            if (seconds < 1f / Application.targetFrameRate) return null;

            if (WaitForSecondsDictionary.TryGetValue(seconds, out var value))
            {
                value = new WaitForSeconds(seconds);
                WaitForSecondsDictionary.Add(seconds, value);
            }
            
            return value;
        }
    }
}