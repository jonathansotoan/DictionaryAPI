using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.DataAccess
{
    public class UnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        protected DbContext context;
        protected Dictionary<Type, object> repositories;
        private bool disposed;

        public UnitOfWork()
        {
            context = new TContext();
            repositories = new Dictionary<Type, object>();
            disposed = false;
        }

        public virtual IRepository<TEntity> GetRepository<TEntity>() where TEntity : BasicEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as Repository<TEntity>;
            }

            var newRepository = new Repository<TEntity>(context);
            repositories.Add(typeof(TEntity), newRepository);
            return newRepository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if(!this.disposed && disposing)
            {
                context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
