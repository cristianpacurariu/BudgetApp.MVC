namespace Infrastructure
{
    public interface IGetRepo<T>
    {
        T Get(int i);
    }
}
