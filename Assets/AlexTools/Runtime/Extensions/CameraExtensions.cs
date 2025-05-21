using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace AlexTools.Extensions
{
    public static class CameraExtensions
    {
        public static Camera OrMain(this Camera camera) => camera ? camera : Camera.main;
        
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
                renderTexture.height, 
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

        public static float GetValue(this Camera camera) =>
            camera.orthographic ? camera.orthographicSize : camera.fieldOfView;

        public static void SetValue(this Camera camera, float value)
        {
            if (camera.orthographic)
                camera.orthographicSize = value;
            else
                camera.fieldOfView = value;
        }
    }
}