using SRandom = System.Random;

namespace AlexTools.Random
{
    public sealed class SystemRandom : IRandom
    {
        private SRandom _random;
        
        public SystemRandom(SRandom random) => _random = random;
        public SystemRandom() : this(new SRandom()) {}
        public SystemRandom(int seed) : this(new SRandom(seed)) {}

        public void SetSeed(int seed) => _random = new SRandom(seed);
        
        public int GetInt(int minInclusive, int maxExclusive) => _random.Next(minInclusive, maxExclusive);

        public float GetFloat(float minInclusive, float maxExclusive) =>
            GetFloat() * (maxExclusive - minInclusive) + minInclusive;

        public float GetFloat() => (float)_random.NextDouble();
    }
}