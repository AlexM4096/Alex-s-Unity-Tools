using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AlexTools
{
    [CustomPropertyDrawer(typeof(ScenePathAttribute))]
    public class ScenePathDrawer : PropertyDrawer
    {      
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var sceneAssetField = new ObjectField(property.displayName) { 
                objectType = typeof(SceneAsset) };

            var scenePath = property.stringValue;
            var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
            sceneAssetField.value = sceneAsset;

            sceneAssetField.RegisterValueChangedCallback(evt =>
            {
                if (evt.newValue is not SceneAsset newSceneAsset) return;

                var newScenePath = AssetDatabase.GetAssetPath(newSceneAsset);
                property.stringValue = newScenePath;
                property.serializedObject.ApplyModifiedProperties();
            });

            return sceneAssetField;
        }
    }
}