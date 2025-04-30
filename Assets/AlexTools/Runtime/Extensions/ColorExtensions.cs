using UnityEngine;

namespace AlexTools.Extensions
{
    public static class ColorExtensions
    {
        public static Color Invert(this Color color) => 
            new(1 - color.r, 1 - color.g, 1 - color.b, color.a);

        public static Color WithAlpha(this Color color, float a)
        {
            color.a = Mathf.Clamp01(a);
            return color;
        }
        
        public static Color With(this Color color, 
            float? r = null, float? g = null, float? b = null, float? a = null) =>
            new(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);

        public static Color Clamp01(this Color color)
        {
            return new Color
            {
                r = Mathf.Clamp01(color.r),
                g = Mathf.Clamp01(color.g),
                b = Mathf.Clamp01(color.b),
                a = Mathf.Clamp01(color.a)
            };
        }

        #region Convertation

        public static string ToHex(this Color color, bool withAlpha = true)
        {
            var hexColor = withAlpha ? 
                ColorUtility.ToHtmlStringRGBA(color) : 
                ColorUtility.ToHtmlStringRGB(color);
            return '#' + hexColor;
        }
        
        public static Color ToColorOrDefault(this string hex) => 
            ColorUtility.TryParseHtmlString(hex, out var color) ? color : default;
        public static Color? ToColorOrNull(this string hex) => 
            ColorUtility.TryParseHtmlString(hex, out var color) ? color : null;

        public static Vector3 ToVector3(this Color color) => (Vector4)color;
        public static Color ToColor(this Vector3 vector) => (Vector4)vector;

        #endregion
    }
}