using MongoDB.Bson;
using XMean.Domain.Entities.Products;
using XMean.Domain.Repositories.Products;
using XMean.MongoDb.DbContexts;

namespace XMean.MongoDb.Domain.Repositories.Products
{
    public class ProductRepository : MongoRepository<MongoDbContext, Product, ObjectId>, IProductRepository
    {
        public ProductRepository(MongoDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}