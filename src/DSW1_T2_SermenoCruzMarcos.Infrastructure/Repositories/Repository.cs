using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;
using DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence;

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // 1. CORRECCIÓN: Ahora devuelve Task<T>
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity; 
        }

        // 2. CORRECCIÓN: Ahora acepta int id y busca la entidad
        public async Task<bool> DeleteAsync(int id) 
        {
            var entity = await _dbSet.FindAsync(id);
            
            if (entity == null)
            {
                return false; 
            }
            
            await Task.Run(() => _dbSet.Remove(entity)); 
            
            return true; 
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // 3. CORRECCIÓN: Ahora devuelve Task<T>
        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return entity;
        }

        // 4. CORRECCIÓN: Implementación de ExistAsync(int id)
        public async Task<bool> ExistAsync(int id)
        {
            return await _dbSet.FindAsync(id) != null;
        }
    }
}