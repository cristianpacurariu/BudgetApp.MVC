namespace Infrastructure
{
    public interface IOperationTypeRepo<T> : IAddRepo<T>, IDeleteRepo<T>, IGetRepo<T>, IUpdateRepo<T>, IListRepo<T>
    {
    }
}
