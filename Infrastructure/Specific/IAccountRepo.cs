namespace Infrastructure
{
    public interface IAccountRepo<T, F> : IGetRepo<T>, IUpdateRepo<T>, IDeleteRepo<T>, IAddRepo<T>, IListRepo<T>, IFilterRepo<T,F>
    {
    }
}
