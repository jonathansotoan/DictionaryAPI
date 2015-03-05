using Dictionary.DataAccess;
using Dictionary.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Tests.Api.Mock
{
    public class MockUnitOfWork : UnitOfWork<DictionaryContext>
    {
        public override IRepository<TEntity> GetRepository<TEntity>()
        {
            if (repositories.Keys.Contains(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as MockRepository<TEntity>;
            }

            var newRepository = new MockRepository<TEntity>();
            repositories.Add(typeof(TEntity), newRepository);
            return newRepository;
        }

        public void SetRepositoryData<TEntity>(List<TEntity> data) where TEntity : BasicEntity
        {
            ((MockRepository<TEntity>)this.GetRepository<TEntity>()).context = data;
        }
    }
}
