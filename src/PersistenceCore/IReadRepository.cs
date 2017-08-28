using System;
using System.Collections.Generic;
using Wb.DomainCore;

namespace Wb.PersistenceCore
{
    public interface IReadRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Get an entity by its id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns></returns>
        TEntity Get(int id);

        /// <summary>
        /// Gets a list of all the entities in the database of type TEntity
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAll();

        /// <summary>
        /// Query the databse and find a list of entitites matching the criteria passed
        /// </summary>
        /// <returns></returns>
        List<TEntity> Query(Func<TEntity, bool> query);
    }
}
