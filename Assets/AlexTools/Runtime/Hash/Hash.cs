namespace AlexTools.Hash
{
    public delegate int HashFunc(string key);
    
    public static class Hash
    {
        public static HashFunc DefaultFunc { get; set; } = FNV1aHash;
        
        public static int FNV1aHash(string str)
        {
            var hash = 2166136261;

            foreach (var c in str)
                hash = (hash ^ c) * 16777619;
            
            return unchecked((int)hash);
        }
    }
}