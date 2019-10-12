using System;

namespace XMean.Domain.Entities
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType, object id)
            : this(entityType, id, null)
        {
        }

        public EntityNotFoundException(Type entityType, object id, Exception innerException)
            : base($"There is no such an entity. Entity type: {entityType.FullName}, id: {id}", innerException)
        {
            EntityType = entityType;
            Id = id;
        }

        public Type EntityType { get; set; }

        /// <summary>
        ///     Id of the Entity.
        /// </summary>
        public object Id { get; set; }
    }
}