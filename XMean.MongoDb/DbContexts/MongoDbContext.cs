using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using MongoDB.Driver;
using Mordor.MongoDb.Helpers;
using XMean.MongoDb.Configs;

namespace XMean.MongoDb.DbContexts
{
    public class MongoDbContext
    {
        private IMongoClient _mongoClient;
        private IMongoDatabase _mongoDb;

        public MongoDbContext(string connectionString)
            : this(DbConnectionStringHelper.GetConnectionOptions(connectionString))
        {
        }

        public MongoDbContext(ConnectionOptions options)
        {
            _mongoClient = new MongoClient(options.Url);
            _mongoDb = _mongoClient.GetDatabase(options.Database);
        }

        public IMongoCollection<T> DbSet<T>()
        {
            var tableName = typeof(T).GetCustomAttribute<TableAttribute>(false).Name;

            return _mongoDb.GetCollection<T>(tableName);
        }
    }
}