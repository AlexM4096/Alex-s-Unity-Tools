namespace AlexTools.Hash
{
    public sealed class FNV1aHash : IHash
    {
        private static readonly FNV1aHash instance = new();
        public static FNV1aHash Instance => instance;
        
        private FNV1aHash(){}
            
        public int Hash(string str)
        {
            var hash = 2166136261;

            foreach (var c in str)
                hash = (hash ^ c) * 16777619;
            
            return unchecked((int)hash);
        }
    }
}