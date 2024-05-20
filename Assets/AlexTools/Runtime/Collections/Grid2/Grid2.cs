using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AlexTools.Collections
{
    public class Grid2<T> : IGrid2<T>, IReadOnlyGrid2<T>
    {
        private readonly T[] _array;

        public int Width => Size.x;
        public int Height => Size.y;

        public Vector2Int Size => Bounds.size;

        public Vector2Int Position => Bounds.position;
        public Vector2 Center => Bounds.center;

        public RectInt Bounds { get; }

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public T this[int x, int y]
        {
            get => this[GetIndex(x, y)];
            set => this[GetIndex(x, y)] = value;
        }

        public T this[Vector2Int position]
        {
            get => this[GetIndex(position)];
            set => this[GetIndex(position)] = value;
        }

        public Grid2(RectInt bounds)
        {
            Bounds = bounds;
            _array = new T[Width * Height];
        }

        public Grid2(Vector2Int position, Vector2Int size) : 
            this(new RectInt(position, size)){}

        public Grid2(int x, int y, int width, int height) : 
            this(new Vector2Int(width, height), new Vector2Int(x, y)){}

        public Grid2(IReadOnlyGrid2<T> grid) : this(grid.Bounds) =>
            AssignValues((x, y) => grid[x, y]);

        public int GetIndex(int x, int y) => (x - Position.x) + (y - Position.y) * Width;
        
        public int GetIndex(Vector2Int position) => GetIndex(position.x, position.y);
        
        public bool InBounds(int x, int y) =>
            Bounds.xMin <= x && x < Bounds.xMax &&
            Bounds.yMin <= y && y < Bounds.yMax;
        
        public bool InBounds(Vector2Int position) => Bounds.Contains(position);
            
        public void ForEach(Action<int, int> action)
        {
            for (int y = Bounds.yMin; y < Bounds.yMax; y++)
            {
                for (int x = Bounds.xMin; x < Bounds.xMax; x++)
                {
                    action(x, y);
                }
            }
        }

        public void ForEach(Action<Vector2Int> action)
        {
            foreach (Vector2Int position in Bounds.allPositionsWithin)
                action(position);
        }
        
        public void ForEach(Action<int, int, T> action) => 
            ForEach((x, y) => action(x, y, this[x, y]));

        public void ForEach(Action<Vector2Int, T> action) => 
            ForEach(position => action(position, this[position]));

        public void AssignValues(Func<int, int, T> func) => 
            ForEach((x, y) => this[x, y] = func(x, y));

        public void AssignValues(Func<Vector2Int, T> func) => 
            ForEach(position => this[position] = func(position));

        public IEnumerator<T> GetEnumerator() => new NoAllocEnumerator<T>(_array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}    