using AlexTools.Attributes;
using AlexTools.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AlexTools
{
    [CustomPropertyDrawer(typeof(HideInPlay))]
    public class HideInPlayDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement content = base.CreatePropertyGUI(property);
            content ??= new VisualElement();
            
            PropertyField propertyField = new(property);
            content.Add(propertyField);
    
            if (Application.isPlaying)
                content.Disable();

            return content;
        }
    }
}