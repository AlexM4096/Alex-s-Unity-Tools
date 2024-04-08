using UnityEditor;

namespace AlexTools.Extensions
{
    public static class EditorExtensions
    {
        private const string AutoPropertyFormat = "<{0}>k__BackingField";

        private static string GetAutoPropertyPath(string name) => 
            string.Format(AutoPropertyFormat, name);
        
        public static SerializedProperty FindAutoPropertyRelative(
            this SerializedProperty property, string name) =>
            property.FindPropertyRelative(GetAutoPropertyPath(name));
        
        public static SerializedProperty FindAutoProperty(
            this SerializedObject obj, string name) =>
            obj.FindProperty(GetAutoPropertyPath(name));
    }
}