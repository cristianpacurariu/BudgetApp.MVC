namespace Infrastructure
{
    public interface IAddRepo<T>
    {
        int Add(T item);
    }
}
