using System;
using System.Collections.Generic;
using System.Linq;
using AlexTools.Extensions;
using AlexTools.Flyweight;
using AlexTools.Random;
using UnityEngine;

namespace AlexTools.Tests.Runtime.Flyweight
{
    [CreateAssetMenu(menuName = "Flyweight/Create SoundSettings", fileName = "SoundSettings")]
    public class SoundSettings : FlyweightSettings
    {
        [SerializeField] private List<SoundList> sounds;

        private IRandom _random;
        private Dictionary<SoundType, IList<AudioClip>> _dictionary;

        public AudioClip GetClip(SoundType type)
        {
            if (_dictionary.TryGetValue(type, out var variants))
                return variants.GetRandomItem(_random);

            Debug.LogError($"No such type as {type}");
            return null;
        }

        private void OnEnable()
        {
            _random = _random.OrDefault();
            
            if (sounds == null) return;

            _dictionary = new Dictionary<SoundType, IList<AudioClip>>(sounds.Count);
            var collisions = sounds.Where(item => !_dictionary.TryAdd(item.type, item.variations));
            collisions.ForEach(soundList => Debug.LogError($"The type {soundList.type} already declared!!!!"));
        }
    }

    [Serializable]
    public struct SoundList
    {
        public SoundType type;
        public AudioClip[] variations;
    }
}