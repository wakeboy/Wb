using Wb.DomainCore;

namespace Wb.PersistenceCore
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>,
        IWriteRepository<TEntity> where TEntity : Entity
    {
    }
}
