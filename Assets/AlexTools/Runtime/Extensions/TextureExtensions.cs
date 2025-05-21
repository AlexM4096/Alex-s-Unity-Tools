using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace AlexTools.Extensions
{
    public static class TextureExtensions
    {
        public static Texture2D Crop(
            this Texture2D texture, 
            RectInt rectInt
        ) 
        {
            var cropped = new Texture2D(
                rectInt.width,
                rectInt.height,
                texture.graphicsFormat,
                TextureCreationFlags.None
            );
            Graphics.CopyTexture(
                texture,
                0,
                0,
                rectInt.x,
                rectInt.y,
                rectInt.width,
                rectInt.height,
                cropped,
                0,
                0,
                0,
                0
            );
            return cropped;
        }

        public static void SetScreenSize(this RenderTexture texture)
        {
            texture.width = Screen.width;
            texture.height = Screen.height;
        }
    }
}