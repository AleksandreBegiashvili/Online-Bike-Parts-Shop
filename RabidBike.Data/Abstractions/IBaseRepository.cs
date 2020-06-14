using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Data.Abstractions
{

    public interface IBaseRepository<T, K> where T : BaseEntity<K> where K : struct
    {
        #region Properties

        /// <summary>
        /// Gets entities that are tracked by ORM context
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets entities that are not tracked by ORM context
        /// TODO: very entity framework specific. Clearly should not be exposed at this level. Needs to be changed by better alternative
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
        #endregion

        #region Methods

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>entity</returns>
        T GetById(K id);
        /// <summary>
        /// Gets entity by id asynchronously    
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(K id);

        /// <summary>
        /// Gets all entities
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets all entities asynchronously
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Inserts entity in storage
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when entity is passed null</exception>
        /// <param name="entity">entity</param>
        void Insert(T entity);

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task InsertAsync(T entity);

        /// <summary>
        /// Inserts enumerable of entities in storage in an atomic operation.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when entities are passed null</exception>
        /// <param name="entities">entities</param>
        void BulkInsert(IEnumerable<T> entities);

        /// <summary>
        /// Updates entity in storage
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when entity is passed null</exception>
        /// <param name="entity">entity</param>
        void Update(T entity);

        /// <summary>
        /// Deletes entity from storage
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when entity is passed null</exception>
        /// <param name="entity">entity</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes enumerable of entities from storage in an atomic operation
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Thrown when entities are passed null</exception>
        /// <param name="entities">entities</param>
        void BulkDelete(IEnumerable<T> entities);

        /// <summary>
        /// Deletes enumerable of entities from storage in an atomic operation 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task BulkDeleteASync(IEnumerable<T> entities);


        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Deletes the asynchronous by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(K id);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        void BulkUpdate(IEnumerable<T> entities);

        Task BulkUpdateAsync(IEnumerable<T> entities);

        #endregion
    }


}
