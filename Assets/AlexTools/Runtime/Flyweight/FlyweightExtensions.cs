namespace AlexTools.Flyweight
{
    public static class FlyweightExtensions
    {
        public static T Get<T>(this IFlyweightFactory factory, FlyweightSettings settings)
            where T : MonoFlyweight => (T)factory.Get(settings);
        
        public static T CreateCopy<T>(this MonoFlyweight flyweight) 
            where T : MonoFlyweight => (T)flyweight.CreateCopy();
    }
}