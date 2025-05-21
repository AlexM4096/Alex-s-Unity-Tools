#if ZSTRING_INSTALLED
using Cysharp.Text;
#endif

namespace AlexTools.Extensions
{
    public static class StringExtensions
    {
        public static string OrEmpty(this string str) => str ?? string.Empty;
        
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);
        public static bool IsNullOrBlank(this string str) => str.IsNullOrEmpty() || str.IsNullOrWhiteSpace();
        
        #region RichText
        
#if ZSTRING_INSTALLED
        
        public static string WithColor(this string text, string color) => 
            ZString.Format(StringFormat.Color, text, color);
        public static string WithGradient(this string text, string color1, string color2) => 
            ZString.Format(StringFormat.Gradient, text, color1, color2);
        
        public static string WithStyle(this string text, string style) => 
            ZString.Format(StringFormat.Style, text, style);
        
        public static string WithSize(this string text, int size) => 
            ZString.Format(StringFormat.Size, text, size);
        public static string WithFont(this string text, string font) => 
            ZString.Format(StringFormat.Font, text, font);
        public static string WithAlign(this string text, string align) => 
            ZString.Format(StringFormat.Align, text, align);
        
        public static string WithBold(this string text) => 
            ZString.Format(StringFormat.Bold, text);
        public static string WithItalic(this string text) => 
            ZString.Format(StringFormat.Italic, text);
        public static string WithUnderline(this string text) => 
            ZString.Format(StringFormat.Underline, text);
        public static string WithStrikethrough(this string text) => 
            ZString.Format(StringFormat.Strikethrough, text);
        
        public static string WithRotation(this string text, float angle) => 
            ZString.Format(StringFormat.Rotation, angle, text);
        public static string WithSpace(this string text, float space) => 
            ZString.Format(StringFormat.Space, space, text);

        public static string WithSprite(this string text, int index) => 
            ZString.Format(StringFormat.SpiteIndex, text, index);
        public static string WithSprite(this string text, string name) => 
            ZString.Format(StringFormat.SpriteName, text, name);
        
#else

        public static string WithColor(this string text, string color) => 
            string.Format(StringFormat.Color, text, color);
        public static string WithGradient(this string text, string color1, string color2) => 
            string.Format(StringFormat.Gradient, text, color1, color2);
        
        public static string WithStyle(this string text, string style) => 
            string.Format(StringFormat.Style, text, style);
        
        public static string WithSize(this string text, int size) => 
            string.Format(StringFormat.Size, text, size);
        public static string WithFont(this string text, string font) => 
            string.Format(StringFormat.Font, text, font);
        public static string WithAlign(this string text, string align) => 
            string.Format(StringFormat.Align, text, align);
        
        public static string WithBold(this string text) => 
            string.Format(StringFormat.Bold, text);
        public static string WithItalic(this string text) => 
            string.Format(StringFormat.Italic, text);
        public static string WithUnderline(this string text) => 
            string.Format(StringFormat.Underline, text);
        public static string WithStrikethrough(this string text) => 
            string.Format(StringFormat.Strikethrough, text);
        
        public static string WithRotation(this string text, float angle) => 
            string.Format(StringFormat.Rotation, text, angle);
        public static string WithSpace(this string text, float space) => 
            string.Format(StringFormat.Space, text, space);

        public static string WithSprite(this string text, int index) => 
            string.Format(StringFormat.SpiteIndex, text, index);
        public static string WithSprite(this string text, string name) => 
            string.Format(StringFormat.SpriteName, text, name);

#endif
        
        #endregion
    }
}