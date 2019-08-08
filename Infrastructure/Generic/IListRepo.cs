using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IListRepo<T>
    {
         Task<List<T>> All();
    }
}
