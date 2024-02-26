using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AlexTools.Extensions
{
    public static class VectorExtensions
    {
        #region Convertation

        public enum VectorSwizzle : byte
        {
            X0Y,
            Y0X,
            X0Z,
            Z0X,
            Y0Z,
            Z0Y
        }
        
        public static Vector3 ToVector3(this Vector2 vector2, VectorSwizzle swizzle = VectorSwizzle.X0Y) 
            => swizzle switch
        {
            VectorSwizzle.X0Y => new Vector3(vector2.x, vector2.y, 0),
            VectorSwizzle.Y0X => new Vector3(vector2.y, vector2.x, 0),
            VectorSwizzle.X0Z => new Vector3(vector2.x, 0, vector2.y),
            VectorSwizzle.Z0X => new Vector3(vector2.y, 0, vector2.x),
            VectorSwizzle.Y0Z => new Vector3(0, vector2.x, vector2.y),
            VectorSwizzle.Z0Y => new Vector3(0, vector2.y, vector2.x),
            _ => throw new ArgumentException()
        };

        public static Vector2 ToVector2(this Vector3 vector3, VectorSwizzle swizzle = VectorSwizzle.X0Y) 
            => swizzle switch
        {
            VectorSwizzle.X0Y => new Vector2(vector3.x, vector3.y),
            VectorSwizzle.Y0X => new Vector2(vector3.y, vector3.x),
            VectorSwizzle.X0Z => new Vector2(vector3.x, vector3.z),
            VectorSwizzle.Z0X => new Vector2(vector3.z, vector3.x),
            VectorSwizzle.Y0Z => new Vector2(vector3.y, vector3.z),
            VectorSwizzle.Z0Y => new Vector2(vector3.z, vector3.y),
            _ => throw new ArgumentException()
        };
        
        public static Vector3Int ToVector3Int(this Vector2Int vector2Int, VectorSwizzle swizzle = VectorSwizzle.X0Y) 
            => swizzle switch
        {
            VectorSwizzle.X0Y => new Vector3Int(vector2Int.x, vector2Int.y, 0),
            VectorSwizzle.Y0X => new Vector3Int(vector2Int.y, vector2Int.x, 0),
            VectorSwizzle.X0Z => new Vector3Int(vector2Int.x, 0, vector2Int.y),
            VectorSwizzle.Z0X => new Vector3Int(vector2Int.y, 0, vector2Int.x),
            VectorSwizzle.Y0Z => new Vector3Int(0, vector2Int.x, vector2Int.y),
            VectorSwizzle.Z0Y => new Vector3Int(0, vector2Int.y, vector2Int.x),
            _ => throw new ArgumentException()
        };
        
        public static Vector2Int ToVector2Int(this Vector3Int vector3Int, VectorSwizzle swizzle = VectorSwizzle.X0Y) 
            => swizzle switch
        {
            VectorSwizzle.X0Y => new Vector2Int(vector3Int.x, vector3Int.y),
            VectorSwizzle.Y0X => new Vector2Int(vector3Int.y, vector3Int.x),
            VectorSwizzle.X0Z => new Vector2Int(vector3Int.x, vector3Int.z),
            VectorSwizzle.Z0X => new Vector2Int(vector3Int.z, vector3Int.x),
            VectorSwizzle.Y0Z => new Vector2Int(vector3Int.y, vector3Int.z),
            VectorSwizzle.Z0Y => new Vector2Int(vector3Int.z, vector3Int.y),
            _ => throw new ArgumentException()
        };

        public static Vector2 ToVector2(this Vector2Int vector2Int) => new(vector2Int.x, vector2Int.y);
        public static Vector2 ToVector2(this Vector3Int vector3Int, VectorSwizzle swizzle = VectorSwizzle.X0Y) =>
            vector3Int.ToVector2Int(swizzle).ToVector2();
        
        public static Vector3 ToVector3(this Vector3Int vector3Int) => new(vector3Int.x, vector3Int.y, vector3Int.z);
        public static Vector3 ToVector3(this Vector2Int vector2Int, VectorSwizzle swizzle = VectorSwizzle.X0Y) =>
            vector2Int.ToVector2().ToVector3(swizzle);

        #endregion

        #region Floor/Ceil/Round

        public static Vector2Int FloorVector2(this Vector2 vector2)
        {
            int x = Mathf.FloorToInt(vector2.x);
            int y = Mathf.FloorToInt(vector2.y);
            return new Vector2Int(x, y);
        }
        
        public static Vector2Int CeilVector2(this Vector2 vector2)
        {
            int x = Mathf.CeilToInt(vector2.x);
            int y = Mathf.CeilToInt(vector2.y);
            return new Vector2Int(x, y);
        }
        
        public static Vector2Int RoundVector2(this Vector2 vector2)
        {
            int x = Mathf.RoundToInt(vector2.x);
            int y = Mathf.RoundToInt(vector2.y);
            return new Vector2Int(x, y);
        }
        
        public static Vector3Int FloorVector3(this Vector3 vector3)
        {
            int x = Mathf.FloorToInt(vector3.x);
            int y = Mathf.FloorToInt(vector3.y);
            int z = Mathf.FloorToInt(vector3.z);
            return new Vector3Int(x, y, z);
        }
        
        public static Vector3Int CeilVector3(this Vector3 vector3)
        {
            int x = Mathf.CeilToInt(vector3.x);
            int y = Mathf.CeilToInt(vector3.y);
            int z = Mathf.CeilToInt(vector3.z);
            return new Vector3Int(x, y, z);
        }
        
        public static Vector3Int RoundVector3(this Vector3 vector3)
        {
            int x = Mathf.RoundToInt(vector3.x);
            int y = Mathf.RoundToInt(vector3.y);
            int z = Mathf.RoundToInt(vector3.z);
            return new Vector3Int(x, y, z);
        }

        #endregion

        #region Random

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

        public static Vector3Int RandomVector3Int() => RandomVector3Int(Vector3Int.zero, Vector3Int.one);
        public static Vector3Int RandomVector3Int(BoundsInt bounds) => RandomVector3Int(bounds.min, bounds.max);

        #endregion

        #region Addition

        public static Vector2 Add(this Vector2 vector3, float x = 0, float y = 0) => 
            new(vector3.x + x, vector3.y + y);

        public static Vector2 With(this Vector2 vector3, float? x = null, float? y = null) => 
            new(x ?? vector3.x, y ?? vector3.y);
        
        public static Vector2Int Add(this Vector2Int vector3Int, int x = 0, int y = 0) => 
            new(vector3Int.x + x, vector3Int.y + y);

        public static Vector2Int With(this Vector2Int vector3Int, int? x = null, int? y = null) => 
            new(x ?? vector3Int.x, y ?? vector3Int.y);
        
        public static Vector3 Add(this Vector3 vector3, float x = 0, float y = 0, float z = 0) => 
            new(vector3.x + x, vector3.y + y, vector3.z + z);

        public static Vector3 With(this Vector3 vector3, float? x = null, float? y = null, float? z = null) => 
            new(x ?? vector3.x, y ?? vector3.y, z ?? vector3.z);
        
        public static Vector3Int Add(this Vector3Int vector3Int, int x = 0, int y = 0, int z = 0) => 
            new(vector3Int.x + x, vector3Int.y + y, vector3Int.z + z);

        public static Vector3Int With(this Vector3Int vector3Int, int? x = null, int? y = null, int? z = null) => 
            new(x ?? vector3Int.x, y ?? vector3Int.y, z ?? vector3Int.z);

        #endregion

        #region InRange

        public static bool InRange(this Vector2 current, Vector2 target, float range) =>
            (current - target).sqrMagnitude <= range * range;
        
        public static bool InRange(this Vector2Int current, Vector2Int target, float range) =>
            (current - target).sqrMagnitude <= range * range;
        
        public static bool InRange(this Vector3 current, Vector3 target, float range) =>
            (current - target).sqrMagnitude <= range * range;
        
        public static bool InRange(this Vector3Int current, Vector3Int target, float range) =>
            (current - target).sqrMagnitude <= range * range;

        #endregion

        #region ComponentDivision

        public static Vector2 ComponentDivide(this Vector2 v0, Vector2 v1) => new( 
                v1.x != 0 ? v0.x / v1.x : v0.x, 
                v1.y != 0 ? v0.y / v1.y : v0.y);
        
        public static Vector3 ComponentDivide(this Vector3 v0, Vector3 v1) => new( 
                v1.x != 0 ? v0.x / v1.x : v0.x, 
                v1.y != 0 ? v0.y / v1.y : v0.y, 
                v1.z != 0 ? v0.z / v1.z : v0.z);

        #endregion
        
    }
}