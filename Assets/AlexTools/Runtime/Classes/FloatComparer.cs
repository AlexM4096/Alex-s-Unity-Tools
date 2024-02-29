using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Classes
{
    public class FloatComparer : IEqualityComparer<float> 
    {
        public bool Equals(float x, float y) => Mathf.Abs(x - y) <= Mathf.Epsilon;
        public int GetHashCode(float obj) => obj.GetHashCode();
    }
}