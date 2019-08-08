using System.Collections.Generic;

namespace Infrastructure
{
    public interface IFilterRepo <T, F>
    {
        List<T> Filter(F filter);
    }
}
