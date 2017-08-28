using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wb.DomainCore;

namespace Wb.PersistenceCore
{
    public interface IWriteRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Insert a new entity to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// Insert a collection of new entities to the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Insert(IEnumerable<TEntity> entity);

        /// <summary>
        /// Update an entity in the database
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete an entity from the database
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete a list of entites from the database
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<TEntity> entities);
        
        /// <summary>
        /// Save all changes to the database
        /// </summary>
        void Save();

        /// <summary>
        /// Save all changes to the database
        /// </summary>
        Task SaveAsync();
    }
}
