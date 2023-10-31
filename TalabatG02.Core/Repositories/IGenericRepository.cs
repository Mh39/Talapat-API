using TalabatG02.Core.Entities;
using TalabatG02.Core.Specification;

namespace TalabatG02.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetBYIdlAsync(int id);

        Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispecifation<T> spec);
        Task<T> GetByIdWithSpecAsync(Ispecifation<T> spec);
        Task<int> GetCountWithSpecAsync(Ispecifation<T> spec);
    }
}
