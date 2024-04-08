using AlexTools.Attributes;
using AlexTools.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AlexTools
{
    [CustomPropertyDrawer(typeof(DisableAttribute))]
    public class DisableDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var content = new PropertyField(property);
            content.Disable();
            return content;
        }
    }
}