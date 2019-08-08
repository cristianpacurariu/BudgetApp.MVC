using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IGetRepo<T>
    {
        Task<T> Get(int i);
    }
}
