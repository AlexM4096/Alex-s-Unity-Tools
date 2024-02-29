using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Collections
{
    public interface IGrid2<T> :  IEnumerable<T>
    {
        int Width { get; }
        int Height { get; }
        
        Vector2Int Size { get; }
        Vector2Int Position { get; }
        Vector2 Center { get; }
        RectInt Bounds { get; }

        T this[int index] { get; set; }
        
        T this[int x, int y] { get; set; }
        T this[Vector2Int position] { get; set; }

        int GetIndex(int x, int y);
        int GetIndex(Vector2Int position);
        
        bool InBounds(int x, int y);
        bool InBounds(Vector2Int position);

        void ForEach(Action<int, int> action);
        void ForEach(Action<Vector2Int> action);
        
        void ForEach(Action<int, int, T> action);
        void ForEach(Action<Vector2Int, T> action);

        void AssignValues(Func<int, int, T> func);
        void AssignValues(Func<Vector2Int, T> func);
    }
}