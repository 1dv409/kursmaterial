using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GeekTweet.Domain.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity :class
    {
        private DbContext _context;
        private DbSet<TEntity> _set;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _set;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy == null ? query.ToList() : orderBy(query).ToList();
        }

        public TEntity GetById(object id)
        {
            return _set.Find(id);
        }

        public void Add(TEntity entityToAdd)
        {
            _set.Add(entityToAdd);
        }

        public void Update(TEntity entityToUpdate)
        {
            _set.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Remove(object id)
        {
            TEntity entityToDelete = _set.Find(id);
            _set.Remove(entityToDelete);
        }
    }
}