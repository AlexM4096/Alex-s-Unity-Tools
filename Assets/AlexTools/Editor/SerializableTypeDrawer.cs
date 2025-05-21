using System;
using System.Linq;
using AlexTools.Extensions;
using AlexTools.Serialization;
using UnityEditor;
using UnityEngine;

namespace AlexTools
{
    [CustomPropertyDrawer(typeof(SerializableType))]
    public class SerializableTypeDrawer : PropertyDrawer 
    {
        private string[] _typeNames, _typeFullNames;
        private bool _initialized;

        private void Initialize() 
        {
            if (_initialized) return;
            
            var filter = fieldInfo.TryGetCustomAttribute(out TypeFilterAttribute filterAttribute) ? 
                filterAttribute.Filter : DefaultFilter;
            var types = ReflectionUtils.GetAllTypes().Where(filter).ToArray();
                
            _typeNames = types.Select(t => t.GetReflectedName()).ToArray();
            _typeFullNames = types.Select(t => t.AssemblyQualifiedName).ToArray();

            _initialized = true;
        }
        
        private static bool DefaultFilter(Type type) => type.IsStandard();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
        {
            Initialize();
            
            var typeIdProperty = property.FindPropertyRelative("assemblyQualifiedName");
            
            if (typeIdProperty.stringValue.IsNullOrEmpty()) 
            {
                typeIdProperty.stringValue = _typeFullNames.First();
                property.serializedObject.ApplyModifiedProperties();
            }

            var currentIndex = Array.IndexOf(_typeFullNames, typeIdProperty.stringValue);
            var selectedIndex = EditorGUI.Popup(position, label.text, currentIndex, _typeNames);

            if (selectedIndex < 0 || selectedIndex == currentIndex) return;
            
            typeIdProperty.stringValue = _typeFullNames[selectedIndex];
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}