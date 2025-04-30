using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Comparers
{
    public class Vector3Comparer : IEqualityComparer<Vector3>
    {
        private static readonly Vector3Comparer instance = new();
        public static Vector3Comparer Instance => instance;
        
        private readonly IEqualityComparer<float> _floatComparer;

        public Vector3Comparer(IEqualityComparer<float> floatComparer = null) =>
            _floatComparer = floatComparer ?? FloatComparer.Instance;

        public bool Equals(Vector3 a, Vector3 b) => _floatComparer.Equals(0, Vector3.Distance(a, b));
        public int GetHashCode(Vector3 obj) => obj.GetHashCode();
    }
}