using XMean.Domain.Entities;
using XMean.Domain.Repositories;
using XMean.MongoDb.DbContexts;

namespace XMean.MongoDb.Domain.Repositories
{
    public class MongoRepository<TDbContext, TEntity> : MongoRepository<TDbContext, TEntity, int>,
        IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : MongoDbContext
    {
        public MongoRepository(TDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}