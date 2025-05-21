namespace AlexTools.Hash
{
    public static class HashExtensions
    {
        public static HashFunc OrDefault(this HashFunc hashFunc) => hashFunc ?? Hash.DefaultFunc;
    }
}