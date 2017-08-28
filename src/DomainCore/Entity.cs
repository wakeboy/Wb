namespace Wb.DomainCore
{
    public abstract class Entity
    {
        /// <summary>
        /// The unique identifier of the entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The version of the record which we are updating
        /// </summary>
        public virtual int Version { get; set; }

        /// <summary>
        /// Entity mapping configuration
        /// </summary>
        /// <param name="modelBuilder"></param>
        public abstract void Map(object modelBuilder);
    }
}
