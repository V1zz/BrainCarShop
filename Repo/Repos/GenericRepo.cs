using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Contracts;

namespace Repo.Repos
{
    public class GenericRepo<T> : IRepo<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepo(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public void AddRange(IEnumerable<T> models)
        {
            _dbSet.AddRange(models);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedProperties)
        {
            IQueryable<T> query = this._dbSet.Where(predicate);
            if (includedProperties == null)
            {
                return query.ToList();
            }

            foreach (var includedProperty in includedProperties)
            {
                query.Include(includedProperty);
            }

            return query.ToList();
        }

        public T Get(object id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(object id)
        {
            var entity = Get(id);
            if (_dbContext.Entry(entity).State == EntityState.Detached) _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public void Update(T model)
        {
            _dbSet.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
        }
    }
}
