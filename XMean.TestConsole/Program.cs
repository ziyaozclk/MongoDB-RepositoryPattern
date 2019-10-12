using System;
using XMean.Domain.Entities.Products;
using XMean.MongoDb.Configs;
using XMean.MongoDb.DbContexts;
using XMean.MongoDb.Domain.Repositories.Facets;
using XMean.MongoDb.Domain.Repositories.Products;
using XMean.MongoDb.Persistences;

namespace XMean.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDbPersistence.Configure();
            
            ConnectionOptions options = new ConnectionOptions
            {
                Url = "mongodb://127.0.0.1:27017/?connectTimeoutMS=10000&socketTimeoutMS=10000",
                Database = "test-db"
            };

            MongoDbContext mongoDbContext = new MongoDbContext(options);

            var facetRepository = new FacetRepository(mongoDbContext);
            var productRepository = new ProductRepository(mongoDbContext);

            var insertedEntity = productRepository.Insert(new Product
            {
                Name = "Product-Test-1",
                TenantId = "Tenant-Test"
            });

            Console.WriteLine("Hello World!");
        }
    }
}