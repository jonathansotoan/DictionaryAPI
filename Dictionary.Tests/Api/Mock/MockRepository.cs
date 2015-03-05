using Dictionary.DataAccess;
using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Dictionary.Tests.Api.Mock
{
    class MockRepository<TEntity> : IRepository<TEntity> where TEntity : BasicEntity
    {
        internal List<TEntity> context;

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = context.AsQueryable();

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
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public TEntity GetById(int id)
        {
            return context.Find(entity => entity.ID == id);
        }

        public TEntity Insert(TEntity entity)
        {
            context.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            TEntity entityToDelete = this.GetById(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            context.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            var oldEntity = this.GetById(entityToUpdate.ID);
            oldEntity = entityToUpdate;
        }
    }
}
