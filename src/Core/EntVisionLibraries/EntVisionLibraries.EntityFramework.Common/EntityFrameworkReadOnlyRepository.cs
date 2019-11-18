using EntVisionLibraries.Common;
using EntVisionLibraries.Common.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.EntityFramework.Common
{
    public abstract class EntityFrameworkReadOnlyRepository<TEntity, TContext> : IReadOnlyRepository<TEntity>
      where TEntity : class, IEntity
      where TContext : DbContext, new()
    {
        protected readonly TContext context;
        protected readonly DbSet<TEntity> dbSet;        

        public EntityFrameworkReadOnlyRepository()
        {
            context = new TContext();
            dbSet = context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)            
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            if (asNoTracking == true)
                query = query.AsNoTracking();

            return query;
        }

        public virtual IEnumerable<TEntity> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)        
            => GetQueryable(null, orderBy, includeProperties, skip, take, asNoTracking).ToList();
        

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)        
            => await GetQueryable(null, orderBy, includeProperties, skip, take, asNoTracking).ToListAsync();
        

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)        
            => GetQueryable(filter, orderBy, includeProperties, skip, take, asNoTracking).ToList();
        

        public virtual async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null,
            bool asNoTracking = false)
            => await GetQueryable(filter, orderBy, includeProperties, skip, take, asNoTracking).ToListAsync();
        

        public virtual TEntity GetOne(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
            => GetQueryable(filter, null, includeProperties).SingleOrDefault();
        

        public virtual async Task<TEntity> GetOneAsync(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null)
            => await GetQueryable(filter, null, includeProperties).SingleOrDefaultAsync();
        

        public virtual TEntity GetFirst(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
           => GetQueryable(filter, orderBy, includeProperties).FirstOrDefault();
        

        public virtual async Task<TEntity> GetFirstAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null)            
            => await GetQueryable(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        

        public virtual TEntity GetById(object id)
        => context.Set<TEntity>().Find(id);

        public virtual Task<TEntity> GetByIdAsync(object id)
        => context.Set<TEntity>().FindAsync(id);

        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
         => GetQueryable(filter).Count();

        public virtual Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)            
        => GetQueryable(filter).CountAsync();

        public virtual bool GetExists(Expression<Func<TEntity, bool>> filter = null)
        => GetQueryable(filter).Any();

        public virtual Task<bool> GetExistsAsync(Expression<Func<TEntity, bool>> filter = null)
        => GetQueryable(filter).AnyAsync();

        public void Dispose()
        => context.Dispose();
    }
}
