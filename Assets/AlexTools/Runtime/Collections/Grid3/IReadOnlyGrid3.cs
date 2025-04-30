using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Collections
{
    public interface IReadOnlyGrid3<out T> : IEnumerable<T>
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
    }
}