using System.Linq.Expressions;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Specification;

namespace TalabatG02.Core.Specifications
{
    public class BaseSpecification<T> : Ispecifation<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; } //Where
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>(); //Include
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesCending { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnable { get; set; }

        public BaseSpecification() //GetAll
        {


        }
        public BaseSpecification(Expression<Func<T, bool>> Criteria)//p=>p.Id=id //GetbyId
        {
            this.Criteria = Criteria;

        }
        public void AddOrderBy(Expression<Func<T, object>> OrderBy)
        { this.OrderBy = OrderBy; }
        public void AddOrderByDesCending(Expression<Func<T, object>> OrderByDesCending)
        { this.OrderByDesCending = OrderByDesCending; }
        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnable = true;
            Skip = skip;
            Take = take;
        }
    }
}