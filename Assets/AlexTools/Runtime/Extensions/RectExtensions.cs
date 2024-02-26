using UnityEngine;

namespace AlexTools.Extensions
{
    public static class RectExtensions
    {
        #region Random

        public static Rect RandomRect(Vector2 minSize, Vector2 maxSize, Rect rect)
        {
            Vector2 size = VectorExtensions.RandomVector2(minSize, maxSize);
            Vector2 position = VectorExtensions.RandomVector2(rect.min, rect.max - size);
            return new Rect(position, size);
        }

        public static Rect RandomRect(Rect size, Rect rect) 
            => RandomRect(size.min, size.max, rect);
        
        public static Rect RandomRect(Vector2 minSize, Vector2 maxSize, Vector2Int position = default)
        {
            Vector2 size = VectorExtensions.RandomVector2(minSize, maxSize);
            return new Rect(position, size);
        }
        
        public static Rect RandomRect(Rect size, Vector2Int position) 
            => RandomRect(size.min, size.max, position);
        public static RectInt RandomRectInt(Vector2Int minSize, Vector2Int maxSize, RectInt rectInt)
        {
            Vector2Int size = VectorExtensions.RandomVector2Int(minSize, maxSize);
            Vector2Int position = VectorExtensions.RandomVector2Int(rectInt.min, rectInt.max - size);
            return new RectInt(position, size);
        }
        
        public static RectInt RandomRectInt(RectInt size, RectInt rectInt) 
            => RandomRectInt(size.min, size.max, rectInt);
        
        public static RectInt RandomRectInt(Vector2Int minSize, Vector2Int maxSize, Vector2Int position = default)
        {
            Vector2Int size = VectorExtensions.RandomVector2Int(minSize, maxSize);
            return new RectInt(position, size);
        }
        
        public static RectInt RandomRect(RectInt size, Vector2Int position) 
            => RandomRectInt(size.min, size.max, position);

        #endregion

        #region Scale

        public static Rect Scale(this Rect rect, int scale) => new(
            rect.position * scale, rect.size * scale);
        
        public static Rect Scale(this Rect rect, Vector2Int scale) => new(
            rect.position * scale, rect.size * scale);
        
        public static RectInt Scale(this RectInt rectInt, int scale) => new(
            rectInt.position * scale, rectInt.size * scale);
        
        public static RectInt Scale(this RectInt rectInt, Vector2Int scale) => new(
            rectInt.position * scale, rectInt.size * scale);

        #endregion

        #region Border

        public static Rect AddBorder(this Rect rect, float radius) => new(
            rect.position - Vector2.one * radius,
            rect.size + Vector2.one * (radius * 2));
        
        public static Rect AddBorder(this Rect rect, float radiusX, float radiusY) => new(
            rect.position - Vector2.right * radiusX - Vector2.up * radiusY,
            rect.size + (Vector2.right * radiusX + Vector2.up * radiusY) * 2);
        
        public static Rect AddBorder(
            this Rect rect, float topRadius, float rightRadius, float bottomRadius, float leftRadius) => new(
            rect.position - Vector2.right * (rightRadius - leftRadius) - Vector2.up * (topRadius - bottomRadius),
            rect.size + Vector2.right * (rightRadius + leftRadius) + Vector2.up * (topRadius + bottomRadius));
        
        public static RectInt AddBorder(this RectInt rectInt, int radius) => new(
            rectInt.position - Vector2Int.one * radius,
            rectInt.size + Vector2Int.one * (radius * 2));
        
        public static RectInt AddBorder(this RectInt rectInt, int radiusX, int radiusY) => new(
            rectInt.position - Vector2Int.right * radiusX - Vector2Int.up * radiusY,
            rectInt.size + (Vector2Int.right * radiusX + Vector2Int.up * radiusY) * 2);
        
        public static RectInt AddBorder(
            this RectInt rectInt, int topRadius, int rightRadius, int bottomRadius, int leftRadius) => new(
            rectInt.position - Vector2Int.right * (rightRadius - leftRadius) - Vector2Int.up * (topRadius - bottomRadius),
            rectInt.size + Vector2Int.right * (rightRadius + leftRadius) + Vector2Int.up * (topRadius + bottomRadius));

        #endregion

        public static Rect Centralize(this Rect rect) => new(
            rect.position - rect.size / 2, rect.size);
        
        public static RectInt Centralize(this RectInt rectInt) => new(
            rectInt.position - rectInt.size / 2, rectInt.size);
    }
}