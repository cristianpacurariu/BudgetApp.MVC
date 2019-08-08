using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IAddRepo<T>
    {
        Task<int> Add(T item);
    }
}
