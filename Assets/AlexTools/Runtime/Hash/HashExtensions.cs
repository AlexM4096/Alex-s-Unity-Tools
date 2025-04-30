namespace AlexTools.Hash
{
    public static class HashExtensions
    {
        public static IHash OrDefault(this IHash hash) => hash ?? IHash.Default;

        public static int Hash(this IHash hash, object value) => hash.Hash(value.ToString());
        public static StringKey ToStringKey(this IHash hash, string value) => new(value, hash);
    }
}