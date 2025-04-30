using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Comparers
{
    public class Vector2Comparer : IEqualityComparer<Vector2>
    {
        private static readonly Vector2Comparer instance = new();
        public static Vector2Comparer Instance => instance;
            
        private readonly IEqualityComparer<float> _floatComparer;

        public Vector2Comparer(IEqualityComparer<float> floatComparer = null) =>
            _floatComparer = floatComparer ?? FloatComparer.Instance;
        
        public bool Equals(Vector2 a, Vector2 b) => _floatComparer.Equals(0, Vector2.Distance(a, b));
        public int GetHashCode(Vector2 obj) => obj.GetHashCode();
    }
}