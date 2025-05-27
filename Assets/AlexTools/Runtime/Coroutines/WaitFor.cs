using System.Collections.Generic;
using AlexTools.Comparers;
using AlexTools.Extensions;
using UnityEngine;

namespace AlexTools.Coroutines
{
    /// <summary>
    /// Provides optimized and cached access to Unity's yield instruction objects for coroutines.
    /// </summary>
    /// <remarks>
    /// This static class implements an object pooling pattern for WaitForSeconds and WaitForSecondsRealtime
    /// to minimize garbage collection during frequent coroutine operations. It automatically handles
    /// frame duration thresholds and provides static access to common yield instructions.
    /// </remarks>
    public static class WaitFor
    {
        /// <summary>
        /// Dictionary caching WaitForSeconds instances by duration (thread-safe for Unity's main thread)
        /// </summary>
        private static readonly Dictionary<float, WaitForSeconds> SecondsDictionary;
        
        /// <summary>
        /// Dictionary caching WaitForSecondsRealtime instances by duration (thread-safe for Unity's main thread)
        /// </summary>
        private static readonly Dictionary<float, WaitForSecondsRealtime> SecondsRealtimeDictionary;

        /// <summary>
        /// Gets the duration of one frame in seconds based on the target frame rate
        /// </summary>
        private static float FrameDurationInSeconds => 1f / Application.targetFrameRate;
        
        /// <summary>
        /// Shared instance of WaitForEndOfFrame for yield instructions
        /// </summary>
        public static readonly WaitForEndOfFrame EndOfFrame;
        
        /// <summary>
        /// Shared instance of WaitForFixedUpdate for yield instructions
        /// </summary>
        public static readonly WaitForFixedUpdate FixedUpdate;
        
        /// <summary>
        /// Gets or sets the capacity for the WaitForSeconds cache (default: 64)
        /// </summary>
        public static int SecondsDictionaryCapacity { get; set; } = 64;
        
        /// <summary>
        /// Gets or sets the capacity for the WaitForSecondsRealtime cache (default: 8)
        /// </summary>
        public static int SecondsRealtimeDictionaryCapacity { get; set; } = 8;

        static WaitFor()
        {
            var floatComparer = FloatComparer.Instance;
            SecondsDictionary = new(SecondsDictionaryCapacity, floatComparer);
            SecondsRealtimeDictionary = new(SecondsRealtimeDictionaryCapacity, floatComparer);

            EndOfFrame = new WaitForEndOfFrame();
            FixedUpdate = new WaitForFixedUpdate();
        }
        
        /// <summary>
        /// Gets a cached WaitForSeconds instance or creates a new one if needed
        /// </summary>
        /// <param name="seconds">Delay duration in seconds</param>
        /// <returns>
        /// WaitForSeconds instance if duration ≥ frame duration, null otherwise
        /// </returns>
        /// <remarks>
        /// Returns null for durations shorter than one frame to avoid unnecessary yields.
        /// Automatically pools and reuses instances for the same duration values.
        /// </remarks>
        public static WaitForSeconds Seconds(float seconds) =>
            seconds < FrameDurationInSeconds ? 
                null : 
                SecondsDictionary.GetOrAdd(seconds, CreateSeconds);

        /// <summary>
        /// Gets a cached WaitForSecondsRealtime instance or creates a new one if needed
        /// </summary>
        /// <param name="seconds">Delay duration in unscaled seconds</param>
        /// <returns>
        /// WaitForSecondsRealtime instance if duration ≥ frame duration, null otherwise
        /// </returns>
        /// <remarks>
        /// Returns null for durations shorter than one frame to avoid unnecessary yields.
        /// Automatically pools and reuses instances for the same duration values.
        /// Uses unscaled time (independent of Time.timeScale).
        /// </remarks>
        public static WaitForSecondsRealtime SecondsRealtime(float seconds) =>
            seconds < FrameDurationInSeconds ? 
                null : 
                SecondsRealtimeDictionary.GetOrAdd(seconds, CreateSecondsRealtime);

        /// <summary>
        /// Clears all cached yield instructions and resizes dictionaries to their capacities
        /// </summary>
        /// <remarks>
        /// Useful for memory management or when changing expected delay patterns.
        /// Maintains the originally configured capacity limits.
        /// </remarks>
        public static void Clear()
        {
            SecondsDictionary.Clear();
            SecondsDictionary.TrimExcess(SecondsDictionaryCapacity);
            
            SecondsRealtimeDictionary.Clear();
            SecondsRealtimeDictionary.TrimExcess(SecondsRealtimeDictionaryCapacity);
        }
        
        /// <summary>
        /// Factory method for creating new WaitForSeconds instances
        /// </summary>
        private static WaitForSeconds CreateSeconds(float seconds) => new(seconds);
        
        /// <summary>
        /// Factory method for creating new WaitForSecondsRealtime instances
        /// </summary>
        private static WaitForSecondsRealtime CreateSecondsRealtime(float seconds) => new(seconds);
    }
}