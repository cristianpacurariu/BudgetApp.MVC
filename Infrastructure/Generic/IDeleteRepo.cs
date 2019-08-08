namespace Infrastructure
{
    public interface IDeleteRepo<T>
    {
        bool Delete(int id);
    }
}
