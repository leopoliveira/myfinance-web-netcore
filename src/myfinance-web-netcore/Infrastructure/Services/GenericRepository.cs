using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.ApplicationDbContext;

namespace myfinance_web_netcore.Infrastructure.Services
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : GenericEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetById(int id)
        {
            return  await _context
                    .Set<TEntity>()
                    .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context
                        .Set<TEntity>()
                        .Where(predicate)
                        .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context
                    .Set<TEntity>()
                    .ToListAsync();
        }

        public async Task Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChangesAsync();
        }

    }
}