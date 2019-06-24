using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.Final.WebApi.Repository
{
    public interface IRepository<T>
    {
        Task<int> Create(T entity);
        Task<IEnumerable<T>> Read();
        T GetById(int id);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
