using System.Linq.Expressions;

namespace ECOM.Core.Specifications
{
    public interface ISpecification<T, TType>
    {
        /// <summary>
        /// 
        /// </summary>
        Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// 
        /// </summary>
        List<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// 
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// 
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }

        /// <summary>
        /// 
        /// </summary>
        int Take { get; }

        /// <summary>
        /// 
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// 
        /// </summary>
        bool IsPagingEnabled { get; }
    }
}
