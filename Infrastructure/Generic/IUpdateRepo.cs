using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IUpdateRepo<T>
    {
        Task Update(T t);
    }
}
