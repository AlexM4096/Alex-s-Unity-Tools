using AlexTools.Attributes;
using AlexTools.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AlexTools
{
    [CustomPropertyDrawer(typeof(DisableInPlay))]
    public class DisableInPlayDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var content = new PropertyField(property);
                
            if (Application.isPlaying)
                content.Disable();

            return content;
        }
    }
}