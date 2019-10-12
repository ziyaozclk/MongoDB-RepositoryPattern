using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;

namespace XMean.Domain.Entities.Products
{
    [Table("Product")]
    public class Product : Entity<ObjectId>, IHaveTenantId
    {
        public Product()
        {
            Id = ObjectId.GenerateNewId();
        }

        public string Name { get; set; }
        public string TenantId { get; set; }
    }
}