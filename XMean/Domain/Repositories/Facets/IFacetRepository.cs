using MongoDB.Bson;
using XMean.Domain.Entities.Facets;

namespace XMean.Domain.Repositories.Facets
{
    public interface IFacetRepository : IRepository<Facet, ObjectId>
    {
    }
}