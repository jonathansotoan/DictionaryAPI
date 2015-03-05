using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dictionary.DataAccess
{
    public interface IRepository<T> where T : BasicEntity
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetById(int id);
        T Insert(T entityToInsert);
        void Delete(int id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
    }
}
