using System.Collections.Generic;
using UnityEngine;

namespace AlexTools
{
    public static class Waiters
    {
        private class FloatComparer : IEqualityComparer<float> 
        {
            public bool Equals(float x, float y) => Mathf.Abs(x - y) <= Mathf.Epsilon;
            public int GetHashCode(float obj) => obj.GetHashCode();
        }
        
        private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDictionary = new(100, new FloatComparer());

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