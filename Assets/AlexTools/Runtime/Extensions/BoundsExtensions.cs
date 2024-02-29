using AlexTools.Enums;
using UnityEngine;

namespace AlexTools.Extensions
{
    public static class BoundsExtensions
    {
        #region Convertation

        public static Rect ToRect(this Bounds bounds, Orientation orientation = Orientation.X0Y)
        {
            Vector2 position = bounds.min.ToVector2(orientation);
            Vector2 size = bounds.size.ToVector2(orientation);
            return new Rect(position, size);
        }
        
        public static RectInt ToRectInt(this BoundsInt boundsInt, Orientation orientation = Orientation.X0Y)
        {
            Vector2Int position = boundsInt.min.ToVector2Int(orientation);
            Vector2Int size = boundsInt.size.ToVector2Int(orientation);
            return new RectInt(position, size);
        }

        #endregion

        #region Random

        public static Bounds RandomBounds(Vector3 minSize, Vector3 maxSize, Bounds bounds)
        {
            Vector3 size = VectorExtensions.RandomVector3(minSize, maxSize);
            Vector3 position = VectorExtensions.RandomVector3(bounds.min, bounds.max - size);
            return new Bounds(position + size / 2, size);
        }

        public static Bounds RandomBounds(Bounds size, Bounds boundsInt) =>
            RandomBounds(size.min, size.max, boundsInt);
        
        public static Bounds RandomBounds(Bounds bounds) =>
            RandomBounds(bounds, bounds);

        public static Bounds RandomBounds(Vector3 minSize, Vector3 maxSize, Vector3 position = default)
        {
            Vector3 size = VectorExtensions.RandomVector3(minSize, maxSize);
            return new Bounds(position + size / 2, size);
        }

        public static Bounds RandomBounds(Bounds size, Vector3 position) =>
            RandomBounds(size.min, size.max, position);
        
        public static BoundsInt RandomBounds(Vector3Int minSize, Vector3Int maxSize, BoundsInt boundsInt)
        {
            Vector3Int size = VectorExtensions.RandomVector3Int(minSize, maxSize);
            Vector3Int  position = VectorExtensions.RandomVector3Int(boundsInt.min, boundsInt.max - size);
            return new BoundsInt(position, size);
        }

        public static BoundsInt RandomBounds(BoundsInt size, BoundsInt boundsInt) =>
            RandomBounds(size.min, size.max, boundsInt);
        
        public static BoundsInt RandomBounds(BoundsInt boundsInt) =>
            RandomBounds(boundsInt, boundsInt);

        public static BoundsInt RandomBounds(Vector3Int minSize, Vector3Int maxSize, Vector3Int position = default)
        {
            Vector3Int size = VectorExtensions.RandomVector3Int(minSize, maxSize);
            return new BoundsInt(position, size);
        }
        
        public static BoundsInt RandomBounds(BoundsInt size, Vector3Int position) =>
            RandomBounds(size.min, size.max, position);

        #endregion

        #region Scale

        public static Bounds Scale(this Bounds bounds, float scale) => 
            new(bounds.center * scale, bounds.size * scale);

        public static Bounds Scale(this Bounds bounds, float scaleX, float scaleY, float scaleZ = 1) =>
            new(bounds.center.Scale(scaleX, scaleY, scaleZ), bounds.size.Scale(scaleX, scaleY, scaleZ));

        public static Bounds Scale(this Bounds bounds, Vector3 scale) =>
            new(Vector3.Scale(bounds.center, scale), Vector3.Scale(bounds.size, scale));
        
        public static BoundsInt Scale(this BoundsInt boundsInt, int scale) => 
            new(boundsInt.position * scale, boundsInt.size * scale);

        public static BoundsInt Scale(this BoundsInt boundsInt, int scaleX, int scaleY, int scaleZ = 1) =>
            new(boundsInt.position.Scale(scaleX, scaleY, scaleZ), boundsInt.size.Scale(scaleX, scaleY, scaleZ));

        public static BoundsInt Scale(this BoundsInt boundsInt, Vector3Int scale) => new(
            Vector3Int.Scale(boundsInt.position, scale), 
            Vector3Int.Scale(boundsInt.size, scale));

        #endregion
    }
}