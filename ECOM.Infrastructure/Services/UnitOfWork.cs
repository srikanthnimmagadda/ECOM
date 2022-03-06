using ECOM.Core.Entities;
using ECOM.Core.Interfaces;
using ECOM.Infrastructure.Data;
using System.Collections;

namespace ECOM.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EComDbContext _context;
        private Hashtable _repositories;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(EComDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public IGenericService<TEntity, TType> Repository<TEntity, TType>() where TEntity : BaseEntity<TType>
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericService<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(TType)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericService<TEntity, TType>)_repositories[type];
        }
    }
}