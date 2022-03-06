using ECOM.Core.Entities;

namespace ECOM.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        IGenericService<TEntity, TType> Repository<TEntity, TType>() where TEntity : BaseEntity<TType>;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<int> Complete();
    }
}