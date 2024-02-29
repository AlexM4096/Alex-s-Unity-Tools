using UnityEngine.UIElements;

namespace AlexTools.Extensions
{
    public static class VisualElementExtensions
    {
        public static void Enable(this VisualElement visualElement) => visualElement.SetEnabled(true);
        public static void Disable(this VisualElement visualElement) => visualElement.SetEnabled(false);
    }
}