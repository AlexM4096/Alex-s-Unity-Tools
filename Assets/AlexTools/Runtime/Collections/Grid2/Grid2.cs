using System.Collections;
using System.Collections.Generic;
using AlexTools.Enumerators;
using UnityEngine;

namespace AlexTools.Collections
{
    public class Grid2<T> : IGrid2<T>
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

        public Grid2(Vector2Int position, Vector2Int size) : this(new RectInt(position, size)) {}
        public Grid2(int x, int y, int width, int height) : this(new Vector2Int(width, height), new Vector2Int(x, y)) {}
        public Grid2(IReadOnlyGrid2<T> grid) : this(grid.Bounds) => this.AssignValues((x, y) => grid[x, y]);

        public int GetIndex(int x, int y) => (x - Position.x) + (y - Position.y) * Width;
        public int GetIndex(Vector2Int position) => GetIndex(position.x, position.y);
        
        public bool InBounds(int x, int y) => 
            Bounds.xMin <= x && x < Bounds.xMax && 
            Bounds.yMin <= y && y < Bounds.yMax;
        public bool InBounds(Vector2Int position) => Bounds.Contains(position);

        public IEnumerator<T> GetEnumerator() => new Enumerator<T>(_array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}    