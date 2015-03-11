using Dictionary.Model;
using System;

namespace Dictionary.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BasicEntity;
        void Save();
    }
}
