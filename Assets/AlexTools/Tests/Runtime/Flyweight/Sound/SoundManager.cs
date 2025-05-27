using System.Collections;
using AlexTools.Coroutines;
using AlexTools.Extensions;
using AlexTools.Flyweight;
using AlexTools.Random;
using UnityEngine;

namespace AlexTools.Tests.Runtime.Flyweight
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private SoundSettings settings;
        [SerializeField] private bool playRandomSounds;
        [SerializeField] private GameObject go;
        
        private IFlyweightFactory _factory;
        private IRandom _random;

        private Dice _dice;

        private CoroutineHandler _handler;
        
        private void Start()
        {
            _factory = new FlyweightFactory();
            _random = _random.OrDefault();

            _handler = PlayRandomSounds().CreateHandler(this);
            _handler.Start();
        }

        public void PlayOneShot(SoundType? type = null, float volume = 1) =>
            PlayClipAtPoint(type, null, volume);

        public void PlayClipAtPoint(SoundType? type = null, Vector3? position = null, float volume = 1)
        {
            var sound = GetSound();
            if (position.HasValue) sound.transform.position = position.Value;
            
            var source = sound.Source;
            var clip = GetClip(type);
            
            source.PlayOneShot(clip, volume);
            sound.StartPlaying(clip.length);
        }

        private Sound GetSound() => _factory.Get<Sound>(settings);
        private AudioClip GetClip(SoundType? type) => settings.GetClip(type.OrRandom());

        private IEnumerator PlayRandomSounds()
        {
            while (playRandomSounds)
            {
                PlayOneShot();
                var seconds = _random.GetFloat(0.2f, 0.6f);
                yield return WaitFor.Seconds(seconds);
            }
        }
    }
}