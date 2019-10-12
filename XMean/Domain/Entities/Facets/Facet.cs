using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;

namespace XMean.Domain.Entities.Facets
{
    [Table("Facet")]
    public class Facet : Entity<ObjectId>, IHaveTenantId
    {
        public Facet()
        {
            Id = ObjectId.GenerateNewId();
        }

        public string Name { get; set; }
        public string TenantId { get; set; }
        public string DisplayName { get; set; }
        public bool IsOperational { get; set; }
        public int Order { get; set; }
    }
}