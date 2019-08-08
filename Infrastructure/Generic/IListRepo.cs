using System.Collections.Generic;

namespace Infrastructure
{
    public interface IListRepo<T>
    {
         List<T> All();
    }
}
