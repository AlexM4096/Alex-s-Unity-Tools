namespace AlexTools.Hash
{
    public interface IHash
    {
        int Hash(string str);

        public static readonly IHash FNV1a = new FNV1aHash();
    }
}