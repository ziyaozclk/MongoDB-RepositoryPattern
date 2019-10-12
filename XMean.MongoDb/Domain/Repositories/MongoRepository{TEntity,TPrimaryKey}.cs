using System;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;
using XMean.Domain.Entities;
using XMean.Domain.Repositories;
using XMean.MongoDb.DbContexts;

namespace XMean.MongoDb.Domain.Repositories
{
    public class MongoRepository<TDbContext, TEntity, TPrimaryKey> :
        GenericRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : MongoDbContext
    {
        private readonly TDbContext _dbContext;

        public MongoRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMongoCollection<TEntity> Collection => _dbContext.DbSet<TEntity>();

        public override IQueryable<TEntity> GetAll()
        {
            return Collection.AsQueryable();
        }

        public override TEntity Insert(TEntity entity)
        {
            Collection.InsertOne(entity);
            return Get(entity.Id);
        }

        public override TEntity Update(TEntity entity)
        {
            var updated = Collection.FindOneAndReplace(CreateFilterById(entity.Id), entity);
            return updated;
        }

        public override void Delete(TEntity entity)
        {
            Delete(entity.Id);
        }

        public override void Delete(TPrimaryKey id)
        {
            Collection.FindOneAndDelete(CreateFilterById(id));
        }

        public override Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            ObjectId objectId;
            if (!ObjectId.TryParse(id.ToString(), out objectId))
            {
                return null;
            }

            Expression<Func<TEntity, bool>> expression = a => a.Id.Equals(objectId);

            return expression;
        }

        protected FilterDefinition<TEntity> CreateFilterById(TPrimaryKey id)
        {
            return Builders<TEntity>.Filter.Eq("Id", id);
        }
    }
}