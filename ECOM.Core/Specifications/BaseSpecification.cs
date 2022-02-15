using System.Linq.Expressions;

namespace ECOM.Core.Specifications
{
    public class BaseSpecifcation<T, TType> : ISpecification<T, TType>
    {
        /// <summary>
        /// 
        /// </summary>
        public BaseSpecifcation() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criteria"></param>
        public BaseSpecifcation(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        /// <summary>
        /// 
        /// </summary>
        public Expression<Func<T, bool>> Criteria { get; }

        /// <summary>
        /// 
        /// </summary>
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        /// <summary>
        /// 
        /// </summary>
        public Expression<Func<T, object>> OrderBy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Take { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Skip { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsPagingEnabled { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeExpression"></param>
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderByExpression"></param>
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderByDescExpression"></param>
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
