using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Collections
{
    public class ReadOnlyGrid3<T> : IReadOnlyGrid3<T>
    {
        private readonly IGrid3<T> _grid;

        public int Width => _grid.Width;
        public int Height => _grid.Height;
        public int Depth => _grid.Depth;

        public Vector3Int Size => _grid.Size;
        public Vector3Int Position => _grid.Position;

        public Vector3 Center => _grid.Center;
        public BoundsInt Bounds => _grid.Bounds;

        public T this[int index] => _grid[index];
        public T this[int x, int y, int z] => _grid[x, y, z];
        public T this[Vector3Int position] => _grid[position];

        public ReadOnlyGrid3(IGrid3<T> grid) => _grid = grid;

        public int GetIndex(int x, int y, int z) => _grid.GetIndex(x, y, z);
        public int GetIndex(Vector3Int position) => _grid.GetIndex(position);

        public bool InBounds(int x, int y, int z) => _grid.InBounds(x, y, z);
        public bool InBounds(Vector3Int position) => _grid.InBounds(position);

        public IEnumerator<T> GetEnumerator() => _grid.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _grid.GetEnumerator();
    }
}