using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace AlexTools.Extensions
{
    public static class CameraExtensions
    {
        /// <summary>
        /// Returns the camera if not null, otherwise returns Camera.main.
        /// </summary>
        /// <param name="camera">The camera to check.</param>
        /// <returns>The input camera if not null, otherwise Camera.main.</returns>
        /// <remarks>
        /// Provides a clean null-coalescing pattern for Camera references.
        /// Note: Camera.main uses FindGameObjectsWithTag internally - cache the result if used frequently.
        /// </remarks>
        public static Camera OrMain(this Camera camera) => camera ? camera : Camera.main;
        
        /// <summary>
        /// Captures a snapshot from a camera into a render texture.
        /// </summary>
        /// <param name="camera">The camera to render from.</param>
        /// <param name="renderTexture">The target render texture (must match camera's aspect ratio for proper results).</param>
        public static void Snapshot(
            this Camera camera, 
            RenderTexture renderTexture
        )
        {
            camera.targetTexture = renderTexture;
            camera.Render();
            camera.targetTexture = null;
        }

        public static Texture2D Screenshot(
            this Camera camera, 
            RenderTexture renderTexture
        )
        {
            Snapshot(camera, renderTexture);
            
            var screenshot = new Texture2D(
                renderTexture.width,
                renderTexture.width,
                renderTexture.graphicsFormat,
                TextureCreationFlags.None
            );
            Graphics.CopyTexture(renderTexture, screenshot);
            return screenshot;
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
        //     var screenshot = renderTexture.CreateScreenshotTexture();
        //     screenshot.SetPixelData(request.GetData<byte>(), 0);
        //     screenshot.Apply();
        //    
        //     return screenshot;
        // }

        public static float GetValue(this Camera camera) =>
            camera.orthographic ? 
                camera.orthographicSize : 
                camera.fieldOfView;

        public static void SetValue(this Camera camera, float value)
        {
            if (camera.orthographic) camera.orthographicSize = value;
            else camera.fieldOfView = value;
        }
    }
}