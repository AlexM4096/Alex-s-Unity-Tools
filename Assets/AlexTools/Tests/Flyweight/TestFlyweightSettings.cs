using AlexTools.Flyweight;
using UnityEngine;

namespace AlexTools.Tests.Flyweight
{
    [CreateAssetMenu(menuName = "Flyweight/Create TestSettings")]
    public class TestFlyweightSettings : MonoFlyweightSettings<TestFlyweight, TestFlyweightSettings>
    {
        
    }
}