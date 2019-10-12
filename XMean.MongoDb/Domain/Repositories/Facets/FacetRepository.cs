using MongoDB.Bson;
using XMean.Domain.Entities.Facets;
using XMean.Domain.Repositories.Facets;
using XMean.MongoDb.DbContexts;

namespace XMean.MongoDb.Domain.Repositories.Facets
{
    public class FacetRepository : MongoRepository<MongoDbContext, Facet, ObjectId>, IFacetRepository
    {
        public FacetRepository(MongoDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}