using AlexTools.Flyweight;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace AlexTools
{
    [CustomEditor(typeof(MonoFlyweightSettings<,>))]
    public class FlyweightSettingsDrawer : Editor
    {
        private SerializedProperty _settingsProperty;
        
        private void OnEnable()
        {
            _settingsProperty = serializedObject.FindProperty("prefab");
            Debug.Log(_settingsProperty);
        }

        public override VisualElement CreateInspectorGUI()
        {
            Debug.Log(_settingsProperty);
            var content = base.CreateInspectorGUI() ?? new VisualElement();
            return content;
        }
    }
}