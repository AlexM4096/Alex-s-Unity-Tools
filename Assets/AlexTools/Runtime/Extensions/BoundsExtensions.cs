using UnityEngine;

namespace AlexTools.Extensions
{
    public static class BoundsExtensions
    {
        public static Vector3[] GetPoints(this Bounds b)
        {
            var points = new[]
            {
                new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z),
                new Vector3(b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z),
                new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z),
                new Vector3(b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z),
                new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z),
                new Vector3(b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z),
                new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z),
                new Vector3(b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)
            };
            return points;
        }
        
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

        #region Scale

        public static Bounds Scale(this Bounds bounds, float scale) => 
            new(bounds.center * scale, bounds.size * scale);

        public static Bounds Scale(this Bounds bounds, 
            float scaleX = 1, float scaleY = 1, float scaleZ = 1) => 
            new(
                bounds.center.Scale(scaleX, scaleY, scaleZ), 
                bounds.size.Scale(scaleX, scaleY, scaleZ));

        public static Bounds Scale(this Bounds bounds, Vector3 scale) => 
            new(Vector3.Scale(bounds.center, scale), Vector3.Scale(bounds.size, scale));
        
        public static BoundsInt Scale(this BoundsInt boundsInt, int scale) => 
            new(boundsInt.position * scale, boundsInt.size * scale);

        public static BoundsInt Scale(this BoundsInt boundsInt, 
            int scaleX = 1, int scaleY = 1, int scaleZ = 1) => 
            new(
                boundsInt.position.Scale(scaleX, scaleY, scaleZ), 
                boundsInt.size.Scale(scaleX, scaleY, scaleZ));

        public static BoundsInt Scale(this BoundsInt boundsInt, Vector3Int scale) => new(
            Vector3Int.Scale(boundsInt.position, scale), 
            Vector3Int.Scale(boundsInt.size, scale));

        #endregion
    }
}