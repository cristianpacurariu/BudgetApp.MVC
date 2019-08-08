namespace Infrastructure
{
    public interface IOperationRepo<T, F> : IAddRepo<T>, IDeleteRepo<T>, IGetRepo<T>, IUpdateRepo<T>, IListRepo<T>, IFilterRepo<T,F>
    {
    }
}
