namespace AlexTools.Hash
{
    public readonly struct FNV1aHash : IHash
    {
        public int Hash(string str)
        {
            uint hash = 2166136261;

            foreach (char c in str)
            {
                hash = (hash ^ c) * 16777619;
            }
            return unchecked((int)hash);
        }
    }
}