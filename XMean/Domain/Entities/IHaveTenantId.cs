namespace XMean.Domain.Entities
{
    public interface IHaveTenantId
    {
        string TenantId { get; set; }
    }
}