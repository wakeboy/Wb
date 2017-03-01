using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wb.Domain;

namespace Wb.Persistence
{
    public interface IRepository<TEntity> : IReadRepository<TEntity>,
        IWriteRepository<TEntity> where TEntity : Entity
    {
    }
}
