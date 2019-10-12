using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace XMean.MongoDb.Persistences
{
    public static class MongoDbPersistence
    {
        public static void Configure()
        {
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            var pack = new ConventionPack
            {
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfDefaultConvention(true),
                new StringObjectIdIdGeneratorConvention()
            };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}