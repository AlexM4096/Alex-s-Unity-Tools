using System;
using UnityEngine;

namespace AlexTools.Collections
{
    public interface IGrid3<T>
    {
        int Width { get; }
        int Height { get; }
        int Depth { get; }
        
        Vector3Int Size { get; }
        Vector3Int Position { get; }
        Vector3 Center { get; }
        BoundsInt Bounds { get; }

        T this[int index] { get; set; }
        
        T this[int x, int y, int z] { get; set; }
        T this[Vector3Int position] { get; set; }

        int GetIndex(int x, int y, int z);
        int GetIndex(Vector3Int position);
        
        bool InBounds(int x, int y, int z);
        bool InBounds(Vector3Int position);

        void ForEach(Action<int, int, int> action);
        void ForEach(Action<Vector3Int> action);
        
        void ForEach(Action<int, int, int, T> action);
        void ForEach(Action<Vector3Int, T> action);

        void AssignValues(Func<int, int, int, T> func);
        void AssignValues(Func<Vector3Int, T> func);
    }
}