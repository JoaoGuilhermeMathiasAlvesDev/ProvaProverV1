using Dominio.IRepository;

namespace Insfrastructure.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly Context.Context _context;

        public RepositoryBase(Context.Context context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public  Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public  Task RemoveAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}