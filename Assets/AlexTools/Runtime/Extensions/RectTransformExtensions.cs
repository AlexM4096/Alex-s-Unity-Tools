using UnityEngine;

namespace AlexTools.Extensions
{
    public static class RectTransformExtensions
    {
        public static Rect GetScreenRect(this RectTransform rt)
        {
            var position = rt.position.ToVector2() - rt.rect.size * rt.pivot;
            return new Rect(position, rt.rect.size);
        }
    }
}