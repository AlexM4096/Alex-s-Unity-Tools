using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AlexTools
{
    public static class Utils
    {
        public static IEnumerable<T> GetValues<T>() where T : Enum =>
            Enum.GetValues(typeof(T)).Cast<T>();

        #region Random

        #region Vector

        public static Vector2 RandomVector2(Vector2 min, Vector2 max)
        {
            float x = Random.Range(min.x, max.x);
            float y = Random.Range(min.y, max.y);
            return new Vector2(x, y);
        }

        public static Vector2 RandomVector2() => RandomVector2(Vector2.zero, Vector2.one);
        public static Vector2 RandomVector2(Rect rect) => RandomVector2(rect.min, rect.max);
        
        public static Vector2Int RandomVector2Int(Vector2Int min, Vector2Int max)
        {
            int x = Random.Range(min.x, max.x);
            int y = Random.Range(min.y, max.y);
            return new Vector2Int(x, y);
        }

        public static Vector2Int RandomVector2Int() => RandomVector2Int(Vector2Int.zero, Vector2Int.one);
        public static Vector2Int RandomVector2Int(RectInt rect) => RandomVector2Int(rect.min, rect.max);

        public static Vector3 RandomVector3(Vector3 min, Vector3 max)
        {
            float x = Random.Range(min.x, max.x);
            float y = Random.Range(min.y, max.y);
            float z = Random.Range(min.z, max.z);
            return new Vector3(x, y, z);
        }

        public static Vector3 RandomVector3() => RandomVector3(Vector3.zero, Vector3.one);
        public static Vector3 RandomVector3(Bounds bounds) => RandomVector3(bounds.min, bounds.max);
        
        public static Vector3Int RandomVector3Int(Vector3Int min, Vector3Int max)
        {
            int x = Random.Range(min.x, max.x);
            int y = Random.Range(min.y, max.y);
            int z = Random.Range(min.z, max.z);
            return new Vector3Int(x, y, z);
        }

        public static Vector3Int RandomVector3Int() => 
            RandomVector3Int(Vector3Int.zero, Vector3Int.one);
        public static Vector3Int RandomVector3Int(BoundsInt bounds) => 
            RandomVector3Int(bounds.min, bounds.max);

        #endregion

        #region Rect

        public static Rect RandomRect(Vector2 minSize, Vector2 maxSize, Rect rect)
        {
            Vector2 size = RandomVector2(minSize, maxSize);
            Vector2 position = RandomVector2(rect.min, rect.max - size);
            return new Rect(position, size);
        }

        public static Rect RandomRect(Rect size, Rect rect) =>
            RandomRect(size.min, size.max, rect);

        public static Rect RandomRect(Rect rect) =>
            RandomRect(rect, rect);

        public static Rect RandomRect(Vector2 minSize, Vector2 maxSize, Vector2Int position = default)
        {
            Vector2 size = RandomVector2(minSize, maxSize);
            return new Rect(position, size);
        }

        public static Rect RandomRect(Rect size, Vector2Int position) =>
            RandomRect(size.min, size.max, position);

        public static RectInt RandomRectInt(Vector2Int minSize, Vector2Int maxSize, RectInt rectInt)
        {
            Vector2Int size = RandomVector2Int(minSize, maxSize);
            Vector2Int position = RandomVector2Int(rectInt.min, rectInt.max - size);
            return new RectInt(position, size);
        }

        public static RectInt RandomRectInt(RectInt size, RectInt rectInt) => 
            RandomRectInt(size.min, size.max, rectInt);

        public static RectInt RandomRectInt(RectInt rectInt) => 
            RandomRectInt(rectInt, rectInt);

        public static RectInt RandomRectInt(Vector2Int minSize, Vector2Int maxSize, Vector2Int position = default)
        {
            Vector2Int size = RandomVector2Int(minSize, maxSize);
            return new RectInt(position, size);
        }

        public static RectInt RandomRect(RectInt size, Vector2Int position) => 
            RandomRectInt(size.min, size.max, position);

        #endregion

        #region Bounds

        public static Bounds RandomBounds(Vector3 minSize, Vector3 maxSize, Bounds bounds)
        {
            Vector3 size = RandomVector3(minSize, maxSize);
            Vector3 position = RandomVector3(bounds.min, bounds.max - size);
            return new Bounds(position + size / 2, size);
        }

        public static Bounds RandomBounds(Bounds size, Bounds boundsInt) => 
            RandomBounds(size.min, size.max, boundsInt);
        
        public static Bounds RandomBounds(Bounds bounds) => 
            RandomBounds(bounds, bounds);

        public static Bounds RandomBounds(Vector3 minSize, Vector3 maxSize, Vector3 position = default)
        {
            Vector3 size = RandomVector3(minSize, maxSize);
            return new Bounds(position + size / 2, size);
        }

        public static Bounds RandomBounds(Bounds size, Vector3 position) => 
            RandomBounds(size.min, size.max, position);
        
        public static BoundsInt RandomBounds(Vector3Int minSize, Vector3Int maxSize, BoundsInt boundsInt)
        {
            Vector3Int size = RandomVector3Int(minSize, maxSize);
            Vector3Int  position = RandomVector3Int(boundsInt.min, boundsInt.max - size);
            return new BoundsInt(position, size);
        }

        public static BoundsInt RandomBounds(BoundsInt size, BoundsInt boundsInt) => 
            RandomBounds(size.min, size.max, boundsInt);
        
        public static BoundsInt RandomBounds(BoundsInt boundsInt) => 
            RandomBounds(boundsInt, boundsInt);

        public static BoundsInt RandomBounds(Vector3Int minSize, Vector3Int maxSize, Vector3Int position = default)
        {
            Vector3Int size = RandomVector3Int(minSize, maxSize);
            return new BoundsInt(position, size);
        }
        
        public static BoundsInt RandomBounds(BoundsInt size, Vector3Int position) => 
            RandomBounds(size.min, size.max, position);

        #endregion

        #endregion
        
    }
}