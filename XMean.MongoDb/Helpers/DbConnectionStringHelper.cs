using XMean.MongoDb.Configs;

namespace Mordor.MongoDb.Helpers
{
    public static class DbConnectionStringHelper
    {
        public static ConnectionOptions GetConnectionOptions(string connectionString)
        {
            return new ConnectionOptions();
        }
    }
}