using System;
using System.Collections.Generic;

namespace GeekTweet.Domain.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
     where TEntity : class
    {
        IEnumerable<TEntity> Get(
            System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null,
            Func<System.Linq.IQueryable<TEntity>,
            System.Linq.IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);

        void Delete(object id);
        void Delete(TEntity entityToDelete);
    }
}
