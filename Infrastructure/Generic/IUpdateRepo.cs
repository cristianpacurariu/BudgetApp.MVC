namespace Infrastructure
{
    public interface IUpdateRepo<T>
    {
        void Update(T t);
    }
}
