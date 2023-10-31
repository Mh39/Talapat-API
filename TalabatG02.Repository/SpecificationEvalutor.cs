using Microsoft.EntityFrameworkCore;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Specification;

namespace TalabatG02.Repository
{
    public static class SpecificationEvalutor<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, Ispecifation<TEntity> Spec)
        {
            //context.products
            var quary = InputQuery;
            if (Spec.Criteria is not null)


                quary = quary.Where(Spec.Criteria);
            //context.Products.Where(p=>p.Id==id);
            if (Spec.OrderBy is not null)
                quary = quary.OrderBy(Spec.OrderBy);
            if (Spec.OrderByDesCending is not null)
            {
                quary = quary.OrderByDescending(Spec.OrderByDesCending);

            }
            if (Spec.IsPaginationEnable)
                quary = quary.Skip(Spec.Skip).Take(Spec.Take);

            quary = Spec.Includes.Aggregate(quary, (CurrentQuery, IncludeExpression) => CurrentQuery.Include(IncludeExpression));
            //context.Products.Where(p=>p.Id==id).Include(p=>p.ProductPrand).Include(p=>p.ProductType);

            return quary;

        }
    }
}
