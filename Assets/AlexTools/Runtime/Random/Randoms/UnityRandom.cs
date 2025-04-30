using URandom = UnityEngine.Random;

namespace AlexTools.Random
{
    public sealed class UnityRandom : IRandom
    {
        private static readonly UnityRandom instance = new();
        public static UnityRandom Instance => instance;

        private UnityRandom() {}

        public void SetSeed(int seed) => URandom.InitState(seed);
        
        public int GetInt(int minInclusive, int maxExclusive) => URandom.Range(minInclusive, maxExclusive);

        public float GetFloat(float minInclusive, float maxExclusive) => URandom.Range(minInclusive, maxExclusive);
        public float GetFloat() => URandom.value;
        
        
    }
}