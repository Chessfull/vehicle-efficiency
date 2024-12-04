using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleEfficiencyAcd.Data.Context;
using VehicleEfficiencyAcd.Data.Entities;

namespace VehicleEfficiencyAcd.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity // -> I created generic repository service for modular and avoiding recreating like for each entity repository etc.
    {
        private readonly VehicleEfficiencyAcdDbContext _context;
        private readonly DbSet<TEntity> _dbSet; // -> With this generic approach dbset will set as repository <t> entity

        public Repository(VehicleEfficiencyAcdDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            entity.IsDeleted = false;
            _dbSet.Add(entity);

        }

        public void Delete(TEntity entity, bool softDelete = true)
        {
            if (softDelete)
            {
                entity.IsDeleted = true;
                entity.ModifiedDate = DateTime.Now;
                _dbSet.Update(entity);
            }
            else // -> Harddelete for optional with second parameter
            {
                _dbSet.Remove(entity);
            }
        }

        public void DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            entity.ModifiedDate = DateTime.Now;
            Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> linqQuery)
        {
            return _dbSet.FirstOrDefault(linqQuery);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> linqQuery = null) // -> IQuaryable for Eager loading and able to use with queries like Select etc.
        {
            return linqQuery is null ? _dbSet : _dbSet.Where(linqQuery);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> linqQuery = null)
        {
            return await (linqQuery == null ? _dbSet.CountAsync() : _dbSet.CountAsync(linqQuery));
        }
    }
}
