using System.Linq.Expressions;
using myfinance_web_netcore.Domain.Entities;

namespace myfinance_web_netcore.Domain.Services
{
    public interface IGenericRepository<TEntity> where TEntity : GenericEntity
    {
        Task<TEntity> GetById(int id);

        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAll();

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
}