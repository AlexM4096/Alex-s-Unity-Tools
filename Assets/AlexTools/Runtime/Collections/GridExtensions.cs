using System;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Collections
{
    public static class GridExtensions
    {
        #region Grid2

        public static void ForEach<T>(this IReadOnlyGrid2<T> grid, Action<int, int> action)
        {
            var bounds = grid.Bounds;
            for (var y = bounds.yMin; y < bounds.yMax; y++)
            for (var x = bounds.xMin; x < bounds.xMax; x++)
                action(x, y);
        }

        public static void ForEach<T>(this IReadOnlyGrid2<T> grid, Action<Vector2Int> action) =>
            grid.Bounds.allPositionsWithin.ToEnumerable().ForEach(action);
        
        public static void ForEach<T>(this IReadOnlyGrid2<T> grid, Action<int, int, T> action) => 
            grid.ForEach((x, y) => action(x, y, grid[x, y]));

        public static void ForEach<T>(this IReadOnlyGrid2<T> grid, Action<Vector2Int, T> action) => 
            grid.ForEach(position => action(position, grid[position]));

        public static void AssignValues<T>(this IGrid2<T> grid, Func<int, int, T> func) => 
            grid.ForEach((x, y) => grid[x, y] = func(x, y));

        public static void AssignValues<T>(this IGrid2<T> grid, Func<Vector2Int, T> func) => 
            grid.ForEach(position => grid[position] = func(position));

        #endregion

        #region Grid3

        public static void ForEach<T>(this IReadOnlyGrid3<T> grid, Action<int, int, int> action)
        {
            var bounds = grid.Bounds;
            for (var z = bounds.zMin; z < bounds.zMax; z++)
            for (var y = bounds.yMin; y < bounds.yMax; y++)
            for (var x = bounds.xMin; x < bounds.xMax; x++)
                action(x, y, z);
        }

        public static void ForEach<T>(this IReadOnlyGrid3<T> grid, Action<Vector3Int> action) =>
            grid.Bounds.allPositionsWithin.ToEnumerable().ForEach(action);

        public static void ForEach<T>(this IReadOnlyGrid3<T> grid, Action<int, int, int, T> action) =>
            grid.ForEach((x, y, z) => action(x, y, z, grid[x, y, z]));

        public static void ForEach<T>(this IReadOnlyGrid3<T> grid, Action<Vector3Int, T> action) =>
            grid.ForEach(position => action(position, grid[position]));

        public static void AssignValues<T>(this IGrid3<T> grid, Func<int, int, int, T> func) =>
            grid.ForEach((x, y, z) => grid[x, y, z] = func(x, y, z));

        public static void AssignValues<T>(this IGrid3<T> grid, Func<Vector3Int, T> func) =>
            grid.ForEach(position => grid[position] = func(position));

        #endregion
    }
}