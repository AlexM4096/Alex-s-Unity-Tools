using System;
using AlexTools.Extensions;
using AlexTools.Flyweight;
using AlexTools.Random;
using UnityEngine;

namespace AlexTools.Tests.Runtime.Flyweight
{
    public class FlyweightTest : MonoBehaviour
    {
        [SerializeField] private FlyweightSettings settings;
        [SerializeField] private int spawnAmount = 6;
        
        private IFlyweightFactory _factory;
        private IRandom _random;

        private void Awake()
        {
            _factory = new FlyweightFactory();
            _random = _random.OrDefault();
        }

        private void Start()
        {
            for (var i = 0; i < spawnAmount; i++)
            {
                var instance = _factory.Get(settings);
                instance.transform.position = _random.GetVector2(Vector2.one * -10, Vector2.one * 10);
            }
        }
    }
}