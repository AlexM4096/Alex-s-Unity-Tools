using UnityEngine;

namespace AlexTools.Extensions
{
    public static class AudioSourceExtensions
    {
        public static float GetRemainingTime(this AudioSource audioSource)
        {
            var clip = audioSource.clip;
            return clip ? clip.length - audioSource.time : 0f;
        }
    }
}