namespace AlexTools.Hash
{
    public interface IHash
    {
        public static IHash Default { get; set; } = FNV1aHash.Instance;
        
        int Hash(string str);
    }
}