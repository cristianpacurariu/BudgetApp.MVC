namespace Infrastructure
{
    public interface ICurrencyRepo<T> : IGetRepo<T>, IListRepo<T>
    {
    }
}
