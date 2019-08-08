using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IDeleteRepo<T>
    {
        Task<bool> Delete(int id);
    }
}
