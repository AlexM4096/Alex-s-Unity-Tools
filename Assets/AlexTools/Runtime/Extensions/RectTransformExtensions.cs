using UnityEngine;

namespace AlexTools.Extensions
{
    public static class RectTransformExtensions
    {
        public static Rect GetScreenRect(
            this RectTransform rt, 
            Canvas canvas
        )
        {
            var size = rt.rect.size * canvas.scaleFactor;
            var position = (Vector2)rt.position - size / 2;
            
            return new Rect(position, size);
        }
        
        public static void SetCanvasRect(
            this RectTransform rt, 
            Rect screenRect,
            Canvas canvas
        )
        {
            var canvasRect = screenRect.Scale(1 / canvas.scaleFactor);

            rt.sizeDelta = canvasRect.size;
            rt.position = canvasRect.center;
        }
    }
}