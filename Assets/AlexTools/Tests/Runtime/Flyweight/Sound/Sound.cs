using System.Collections;
using AlexTools.Flyweight;
using UnityEngine;

namespace AlexTools.Tests.Runtime.Flyweight
{
    [RequireComponent(typeof(AudioSource))]
    public class Sound : MonoFlyweight
    {
        public AudioSource Source { get; private set; }
        
        private Coroutine _coroutine;
        
        private void Awake()
        {
            Source = GetComponent<AudioSource>();
        }

        public void StartPlaying(float seconds)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(PlayRoutine(seconds));
        }
        
        private IEnumerator PlayRoutine(float seconds)
        {
            yield return WaitFor.Seconds(seconds);
            ReleaseSelf();
        }
    }
}