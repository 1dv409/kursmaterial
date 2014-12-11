using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GeekTweet.Domain.DAL
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetById(object id);
        void Add(TEntity entityToAdd);
        void Update(TEntity entityToUpdate);
        void Remove(object id);
    }
}
