using System;
using UnityEngine;

namespace AlexTools.Collections
{
    public interface IReadOnlyGrid3<out T>
    {
        int Width { get; }
        int Height { get; }
        int Depth { get; }
        
        Vector3Int Size { get; }
        Vector3Int Position { get; }
        Vector3 Center { get; }
        BoundsInt Bounds { get; }

        T this[int index] { get; }

        T this[int x, int y, int z] { get; }
        T this[Vector3Int position] { get; }

        int GetIndex(int x, int y, int z);
        int GetIndex(Vector3Int position);
        
        bool InBounds(int x, int y, int z);
        bool InBounds(Vector3Int position);

        void ForEach(Action<int, int, int> action);
        void ForEach(Action<Vector3Int> action);
        
        void ForEach(Action<int, int, int, T> action);
        void ForEach(Action<Vector3Int, T> action);
    }
}