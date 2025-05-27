using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace AlexTools.Extensions
{
    public static class TextureExtensions
    {
        /// <summary>
        /// Creates a cropped copy of a Texture using the specified rectangular region.
        /// </summary>
        /// <param name="texture">The source Texture to crop.</param>
        /// <param name="rectInt">The rectangular region to crop (in pixel coordinates).</param>
        /// <returns>A new Texture2D containing only the specified region of the original texture.</returns>
        /// <remarks>
        /// This method efficiently copies pixel data using Graphics.CopyTexture for better performance.
        /// The cropped texture maintains the same graphics format as the original.
        /// The RectInt coordinates use Unity's texture space convention (x: left, y: bottom).
        /// For large textures, consider calling Apply() on the result if you need CPU access to pixels.
        /// </remarks>
        public static Texture2D Crop(
            this Texture texture, 
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
        
        // public static async UniTask<Texture2D> ScreenshotAsync(
        //     this Camera camera, 
        //     RenderTexture renderTexture
        // )
        // {
        //     Snapshot(camera, renderTexture);
        //     
        //     var request = await AsyncGPUReadback.Request(renderTexture);
        //                
        //     var screenshot = new Texture2D(
        //         renderTexture.width, 
        //         renderTexture.height, 
        //         renderTexture.graphicsFormat, 
        //         TextureCreationFlags.None
        //     );
        //     screenshot.SetPixelData(request.GetData<byte>(), 0);
        //     screenshot.Apply();
        //    
        //     return screenshot;
        // }
        
        /// <summary>
        /// Safely resizes a RenderTexture to specified dimensions while preserving its configuration.
        /// Includes optimization to skip unnecessary resize operations.
        /// </summary>
        /// <param name="renderTexture">The RenderTexture to resize.</param>
        /// <param name="width">The new width in pixels.</param>
        /// <param name="height">The new height in pixels.</param>
        public static void SetSize(
            this RenderTexture renderTexture,
            int width,
            int height
        )
        {
            if (renderTexture.width == width || renderTexture.height == height)
                return;
            
            renderTexture.Release();

            renderTexture.width = width;
            renderTexture.height = height;

            renderTexture.Create();
        }

        /// <summary>
        /// Resizes the RenderTexture to match the current screen dimensions.
        /// </summary>
        /// <param name="renderTexture">The RenderTexture to resize.</param>
        /// <remarks>
        /// This method sets the width and height of the RenderTexture to match
        /// the screen's width and height (Screen.width and Screen.height).
        /// Useful when you need a RenderTexture that covers the entire screen,
        /// such as for full-screen effects or render-to-texture operations.
        /// </remarks>
        public static void SetScreenSize(this RenderTexture renderTexture) =>
            SetSize(renderTexture, Screen.width, Screen.height);

        /// <summary>
        /// Resizes a RenderTexture to match a camera's pixel dimensions.
        /// </summary>
        /// <param name="renderTexture">The RenderTexture to resize.</param>
        /// <param name="camera">Target camera (uses main camera if null).</param>
        /// <param name="unscaled">When true, uses pixelWidth/Height; when false, uses scaledPixelWidth/Height.</param>
        public static void SetCameraSize(
            this RenderTexture renderTexture,
            Camera camera = null,
            bool unscaled = true
        )
        {
            camera = camera.OrMain();
            
            if (unscaled) SetSize(renderTexture, camera.pixelWidth, camera.pixelHeight);
            else SetSize(renderTexture, camera.scaledPixelWidth, camera.scaledPixelHeight);
        }
    }
}