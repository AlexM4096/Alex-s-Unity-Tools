using UnityEditor;

namespace AlexTools
{
    public static class EditorExtensions
    {
        private static string GetAutoPropertyPath(string name) => string.Format(StringFormat.AutoProperty, name);
        
        public static SerializedProperty FindAutoPropertyRelative(this SerializedProperty property, string name) =>
            property.FindPropertyRelative(GetAutoPropertyPath(name));
        
        public static SerializedProperty FindAutoProperty(this SerializedObject obj, string name) =>
            obj.FindProperty(GetAutoPropertyPath(name));
    }
}