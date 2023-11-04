using Microsoft.EntityFrameworkCore;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Repositories;
using TalabatG02.Core.Specification;
using TalabatG02.Repository.Data;

namespace TalabatG02.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        #region Static Quires

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbcontext.Set<T>().ToListAsync();
        }

        public async Task<T> GetBYIdlAsync(int id)
        {



            return await dbcontext.Set<T>().FindAsync(id);
        }

        #endregion
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispecifation<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();

        }

        public async Task<T> GetByIdWithSpecAsync(Ispecifation<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public Task<int> GetCountWithSpecAsync(Ispecifation<T> spec)
        {
            return ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(Ispecifation<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(dbcontext.Set<T>(), spec);
        }

        public async Task Add(T entity)
        => await dbcontext.Set<T>().AddAsync(entity);

        public void Update(T entity)
        => dbcontext.Set<T>().Update(entity);


        public void Delete(T entity)
        => dbcontext.Set<T>().Remove(entity);


    }
}
