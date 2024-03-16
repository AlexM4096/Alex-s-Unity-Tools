using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AlexTools.Collections
{
    public class Grid3<T> : IGrid3<T>, IReadOnlyGrid3<T>,  IEnumerable<T>
    {
        private readonly T[] _array;

        public int Width => Size.x;
        public int Height => Size.y;
        public int Depth => Size.z;

        public Vector3Int Size => Bounds.size;

        public Vector3Int Position => Bounds.position;
        public Vector3 Center => Bounds.center;
        
        public BoundsInt Bounds { get; }

        public T this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public T this[int x, int y, int z]
        {
            get => _array[GetIndex(x, y, z)];
            set => _array[GetIndex(x, y, z)] = value;
        }

        public T this[Vector3Int position]
        {
            get => _array[GetIndex(position)];
            set => _array[GetIndex(position)] = value;
        }

        public Grid3(BoundsInt bounds)
        {
            Bounds = bounds;
            _array = new T[Width * Height * Depth];
        }

        public Grid3(IReadOnlyGrid3<T> grid) : this(grid.Bounds)
        {
            AssignValues((x, y, z) => grid[x, y, z]);
        }

        public int GetIndex(int x, int y, int z) => 
            (x - Position.x) + ((y - Position.y) + (z - Position.z) * Height) * Width;

        public int GetIndex(Vector3Int position) =>
            GetIndex(position.x, position.y, position.z);

        public bool InBounds(int x, int y, int z) => 
            Bounds.xMin <= x && x < Bounds.xMax &&
            Bounds.yMin <= y && y < Bounds.yMax &&
            Bounds.zMin <= z && z < Bounds.zMax;

        public bool InBounds(Vector3Int position) => Bounds.Contains(position);

        public void ForEach(Action<int, int, int> action)
        {
            for (int z = 0; z < Depth; z++)
            {
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        action(x, y, z);
                    }
                }
            }
        }

        public void ForEach(Action<Vector3Int> action)
        {
            foreach (Vector3Int position in Bounds.allPositionsWithin)
            {
                action(position);
            }
        }

        public void ForEach(Action<int, int, int, T> action) =>
            ForEach((x, y, z) => action(x, y, z, this[x, y, z]));

        public void ForEach(Action<Vector3Int, T> action) =>
            ForEach((position) => action(position, this[position]));

        public void AssignValues(Func<int, int, int, T> func) =>
            ForEach((x, y, z) => this[x, y, z] = func(x, y, z));

        public void AssignValues(Func<Vector3Int, T> func) =>
            ForEach((position) => this[position] = func(position));
        
        public IEnumerator<T> GetEnumerator() => new NoAllocEnumerator<T>(_array);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}