namespace ZooWorld
{
    public interface IFactory<out T>
    {
        T Create();
    }
}