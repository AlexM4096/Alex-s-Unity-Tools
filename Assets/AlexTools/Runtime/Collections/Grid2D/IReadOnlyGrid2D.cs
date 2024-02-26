using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Collections
{
    public interface IReadOnlyGrid2D<out T> : IEnumerable<T>
    {
        int Width { get; }
        int Height { get; }
        
        Vector2Int Size { get; }
        Vector2Int Position { get; }
        RectInt Bounds { get; }

        T this[int index] { get; }

        T this[int x, int y] { get; }
        T this[Vector2Int position] { get; }

        int GetIndex(int x, int y);
        int GetIndex(Vector2Int position);
        
        bool InBounds(int x, int y);
        bool InBounds(Vector2Int position);

        void ForEach(Action<int, int> action);
        void ForEach(Action<Vector2Int> action);
        
        void ForEach(Action<int, int, T> action);
        void ForEach(Action<Vector2Int, T> action);
    }
}