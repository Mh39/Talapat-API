using System.Linq.Expressions;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specification
{
    public interface Ispecifation<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; } //Signature For Prop
        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesCending { get; set; }

        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnable { get; set; }



    }
}
