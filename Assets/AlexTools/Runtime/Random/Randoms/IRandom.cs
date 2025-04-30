namespace AlexTools.Random
{
    public interface IRandom
    {
        public static IRandom Default { get; set; } = UnityRandom.Instance;
        
        void SetSeed(int seed);
        
        int GetInt(int minInclusive, int maxExclusive);

        float GetFloat(float minInclusive, float maxExclusive);
        float GetFloat();
    }
}