using AlexTools.Attributes;
using AlexTools.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AlexTools
{
    [CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
    public class ShowOnlyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement content = base.CreatePropertyGUI(property);
            content ??= new VisualElement();
            
            PropertyField propertyField = new(property);
            content.Add(propertyField);

            content.Disable();

            return content;
        }
    }
}