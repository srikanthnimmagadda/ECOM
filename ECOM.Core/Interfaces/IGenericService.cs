using ECOM.Core.Entities;
using ECOM.Core.Specifications;

namespace ECOM.Core.Interfaces
{
    public interface IGenericService<T, TType> where T : BaseEntity<TType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<T> GetEntityWithSpec(ISpecification<T, TType> spec);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T, TType> spec);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        Task<int> CountAsync(ISpecification<T, TType> spec);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
    }
}