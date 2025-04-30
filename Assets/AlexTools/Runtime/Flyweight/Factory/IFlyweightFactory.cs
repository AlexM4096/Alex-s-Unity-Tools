namespace AlexTools.Flyweight
{
    public interface IFlyweightFactory
    {
        void AddSettings(IFlyweightSettings settings);
        MonoFlyweight Get(IFlyweightSettings settings);
        void Release(MonoFlyweight flyweight);
    }
}