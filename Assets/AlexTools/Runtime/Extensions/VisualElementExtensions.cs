using UnityEngine.UIElements;

namespace AlexTools.Extensions
{
    public static class VisualElementExtensions
    {
        public static void Enable(this VisualElement visualElement) => visualElement.SetEnabled(true);
        public static void Disable(this VisualElement visualElement) => visualElement.SetEnabled(false);
        
        public static void SetDisplay(this VisualElement visualElement, bool value) =>
            visualElement.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;

        public static void Show(this VisualElement visualElement) => visualElement.SetDisplay(true);
        public static void Hide(this VisualElement visualElement) => visualElement.SetDisplay(false);
    }
}