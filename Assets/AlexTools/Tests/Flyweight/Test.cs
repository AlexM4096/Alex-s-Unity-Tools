using UnityEngine;

namespace AlexTools.Tests.Flyweight
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private TestFlyweightSettings settings;
        private void Awake()
        {

            for (int i = 0; i < 10; i++)
            {
                settings.Get();
            }
        }
    }
}