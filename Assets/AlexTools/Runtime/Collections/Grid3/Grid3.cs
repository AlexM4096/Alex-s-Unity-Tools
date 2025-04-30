using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlexTools.Collections
{
    public class Grid3<T> : IGrid3<T>
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

        public Grid3(IReadOnlyGrid3<T> grid) : this(grid.Bounds) => this.AssignValues((x, y, z) => grid[x, y, z]);

        public int GetIndex(int x, int y, int z) => 
            (x - Position.x) + ((y - Position.y) + (z - Position.z) * Height) * Width;

        public int GetIndex(Vector3Int position) =>
            GetIndex(position.x, position.y, position.z);

        public bool InBounds(int x, int y, int z) => 
            Bounds.xMin <= x && x < Bounds.xMax &&
            Bounds.yMin <= y && y < Bounds.yMax &&
            Bounds.zMin <= z && z < Bounds.zMax;

        public bool InBounds(Vector3Int position) => Bounds.Contains(position);
        
        public IEnumerator<T> GetEnumerator() => new Enumerator<T>(_array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}