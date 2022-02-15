using ECOM.Core.Entities;
using ECOM.Core.Interfaces;
using ECOM.Core.Specifications;
using ECOM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Infrastructure.Services
{
    public class GenericService<T, TType> : IGenericService<T, TType> where T : BaseEntity<TType>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly EComDbContext _dbContext;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericService(EComDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<T> GetEntityWithSpec(ISpecification<T, TType> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T,TType> spec)
        {
            var query = ApplySpecification(spec);
            return await query.ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(ISpecification<T, TType> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <returns></returns>
        private IQueryable<T> ApplySpecification(ISpecification<T, TType> spec)
        {
            return SpecificationEvaluator<T, TType>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}