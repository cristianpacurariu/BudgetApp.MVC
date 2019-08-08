using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IFilterRepo <T, F>
    {
        Task<List<T>> Filter(F filter);
    }
}
