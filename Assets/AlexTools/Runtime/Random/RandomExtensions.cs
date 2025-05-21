using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AlexTools.Extensions;
using UnityEngine;
using SRandom = System.Random;

namespace AlexTools.Random
{
    public static class RandomExtensions
    {
        public static IRandom ToRandom(this SRandom random) => new SystemRandom(random);

        public static IRandom OrDefault(this IRandom random) => random ?? IRandom.Default;
        public static IRandom OrUnity(this IRandom random) => random ?? UnityRandom.Instance;
        public static IRandom OrSystem(this IRandom random) => random ?? new SystemRandom();

        #region Collection&List

        public static int GetIndex<T>(this IRandom random, ICollection<T> collection) =>
            random.GetInt(0, collection.Count);
        public static int GetIndexR<T>(this IRandom random, IReadOnlyCollection<T> collection) =>
            random.GetInt(0, collection.Count);
        public static int GetIndexO(this IRandom random, ICollection collection) =>
            random.GetInt(0, collection.Count);

        public static T GetItem<T>(this IRandom random, IList<T> list) =>
            list[GetIndex(random, list)];
        public static T GetItemR<T>(this IRandom random, IReadOnlyList<T> list) =>
            list[GetIndexR(random, list)];
        public static object GetObject(this IRandom random, IList list) =>
            list[GetIndexO(random, list)];

        #endregion
        
        #region Bool

        public static bool GetBool(this IRandom random, float chance = 0.5f) => random.GetFloat() < chance;
        public static bool GetBool(this IRandom random, int variants) => random.GetInt(0, variants) == 0;

        #endregion
        
        #region Dice

        public static int RollDice(this IRandom random, int sides) => random.GetInt(0, sides) + 1;
        public static int RollDice(this IRandom random, Dice dice) => random.RollDice((byte)dice);

        #endregion

        #region Enum

        public static T GetEnum<T>(this IRandom random) where T : struct, Enum =>
            EnumUtils.GetValues<T>().Random(random);

        public static T GetEnum<T>(this IRandom random, params T[] variants) where T : struct, Enum =>
            variants.GetRandomItem(random);
        
        public static T GetEnum<T>(this IRandom random, T flags) where T : struct, Enum
        { 
            if (!typeof(T).HasCustomAttribute<FlagsAttribute>())
                throw new ArgumentException();

            var variants = flags.GetFlags();
            return variants.Random(random);
        }
        
        public static T GetEnumWithFlags<T>(this IRandom random) where T : struct, Enum
        {
            var type = typeof(T);
            if (!type.HasCustomAttribute<FlagsAttribute>())
                throw new ArgumentException();

            var values = EnumUtils.GetValues<T>().Select(x => Convert.ToInt32(x)).ToArray();
            var amount = values.GetRandomIndex(random);
            var value = values
                .Take(amount)
                .Aggregate(default(int), (current, x) => current | x);

            return (T)Enum.ToObject(type, value);
        }
        
        #endregion

        #region Char&String

        private static readonly char[] Alphanumeric = (
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + 
            "abcdefghijklmnopqrstuvwxyz" + 
            "0123456789"
        ).ToCharArray();

        public static char GetChar(this IRandom random, bool alphanumeric = true) =>
            alphanumeric ? 
                GetItem(random, Alphanumeric) : 
                (char)random.GetInt(0, 256);
        
        public static string GetString(
            this IRandom random, 
            int length = 16, 
            bool alphanumeric = true)
        {
            var array = new char[length];

            for (var i = 0; i < length; i++)
                array[i] = GetChar(random, alphanumeric);

            return new string(array);
        }

        #endregion
        
        #region Color

        public static Color GetColor(this IRandom random, bool withAlpha = false)
        {
            var color = (Color)random.GetVector4();
            if (!withAlpha) color = color.WithAlpha(1);
            
            return color;
        }
            

        public static Color GetColor(this IRandom random, Color min, Color max, bool withAlpha = false)
        {
            var vector = random.GetVector4();
            var diff = max - min;
            vector.Scale(diff);
            
            var color = (Color)vector;
            if (!withAlpha) color = color.WithAlpha(1);

            return color;
        }

        #endregion
        
        #region Vector2

        public static Vector2 GetVector2(this IRandom random)
        {
            var x = random.GetFloat();
            var y = random.GetFloat();
            
            return new Vector2(x, y);
        }
        
        public static Vector2 GetVector2(this IRandom random, Vector2 min, Vector2 max)
        {
            var unit = random.GetVector2();
            var diff = max - min;
            
            return min + diff * unit;
        }

        public static Vector2 GetVector2(this IRandom random, Rect rect) =>
            random.GetVector2(rect.min, rect.max);

        public static Vector2 GetPointOnUnitCircle(this IRandom random)
        {
            var angel = random.GetFloat();
            return Vector2.right.Rotate(angel);
        }
        
        public static Vector2 GetPointInUnitCircle(this IRandom random)
        {
            var angel = random.GetFloat();
            var radius = random.GetFloat();
            
            var value = new Vector2(radius, 0);
            return value.Rotate(angel);
        }

        #endregion

        #region Vector2Int

        public static Vector2Int GetVector2Int(IRandom random, Vector2Int min, Vector2Int max)
        {
            var x = random.GetInt(min.x, max.x);
            var y = random.GetInt(min.y, max.y);
            return new Vector2Int(x, y);
        }

        public static Vector2Int GetVector2Int(IRandom random, RectInt rect) => 
            GetVector2Int(random, rect.min, rect.max);

        #endregion

        #region Vector3

        public static Vector3 GetVector3(this IRandom random)
        {
            var x = random.GetFloat();
            var y = random.GetFloat();
            var z = random.GetFloat();
            return new Vector3(x, y, z);
        }
        
        public static Vector3 GetVector3(this IRandom random, Vector3 min, Vector3 max)
        {
            var unit = random.GetVector3();
            var diff = max - min;
            unit.Scale(diff);
            return min + unit;
        }
        
        public static Vector3 GetVector3(this IRandom random, Bounds bounds) => 
            GetVector3(random, bounds.min, bounds.max);

        #endregion

        #region Vector3Int

        public static Vector3Int RandomVector3Int(this IRandom random, Vector3Int min, Vector3Int max)
        {
            var x = random.GetInt(min.x, max.x);
            var y = random.GetInt(min.y, max.y);
            var z = random.GetInt(min.z, max.z);
            return new Vector3Int(x, y, z);
        }
        
        public static Vector3Int RandomVector3Int(this IRandom random, BoundsInt bounds) => 
            RandomVector3Int(random, bounds.min, bounds.max);

        #endregion

        #region Vector4

        public static Vector4 GetVector4(this IRandom random)
        {
            var x = random.GetFloat();
            var y = random.GetFloat();
            var z = random.GetFloat();
            var w = random.GetFloat();
            
            return new Vector4(x, y, z, w);
        }
        
        public static Vector4 GetVector4(this IRandom random, Vector4 min, Vector4 max)
        {
            var unit = random.GetVector4();
            var diff = max - min;
            
            unit.Scale(diff);
            
            return min + unit;
        }

        #endregion

        #region Rect

        public static Rect GetRect(
            this IRandom random,
            Vector2 minSize, Vector2 maxSize,
            Vector2 minPos, Vector2 maxPos,
            bool inside = true)
        {
            var size = random.GetVector2(minSize, maxSize);
            if (inside) maxPos -= size;
            var position = random.GetVector2(minPos, maxPos);
            return new Rect(position, size);
        }

        public static Rect GetRect(this IRandom random, Rect size, Rect position, bool inside = true) =>
            random.GetRect(size.min, size.max, position.min, position.max, inside);

        #endregion

        #region RectInt



        #endregion

        #region Bounds



        #endregion

        #region BoundsInt



        #endregion
    }
}