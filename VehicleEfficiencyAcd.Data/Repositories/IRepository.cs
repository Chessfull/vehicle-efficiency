using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VehicleEfficiencyAcd.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class // -> My repository service interface, made generic
    {
        void Add(TEntity entity);
        void Delete(TEntity entity, bool softDelete = true);
        void DeleteById(int id);
        void Update(TEntity entity);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> linqQuery);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> linqQuery = null);
        Task<int> Count(Expression<Func<TEntity, bool>> linqQuery = null);
    }
}
