using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RabidBike.Data.Abstractions;
using RabidBike.Data.Context;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Data.Implementations
{
    public class BaseRepository<T, K> : IBaseRepository<T, K> where T : BaseEntity<K> where K : struct
    {
        #region Fields

        private readonly RabidBikeContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        public BaseRepository(RabidBikeContext context)
        {
            _context = context;
        }

        #endregion

        #region Properties

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<T>();
                }

                return _entities;
            }
        }

        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return Entities.AsNoTracking(); }
        }

        #endregion

        #region Methods

        public T GetById(K id)
        {
            return Entities.Find(id);
        }

        public async Task<T> GetByIdAsync(K id)
        {
            return await Entities.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Entities.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }

        public void Insert(T entity)
        {
            //entity.ThrowIfArgumentNull(nameof(entity));

            Entities.Add(entity);
            _context.SaveChanges();
        }

        public void BulkInsert(IEnumerable<T> entities)
        {
            //entities.ThrowIfArgumentNull(nameof(entities));

            _context.AddRange(entities);
        }

        public void Update(T entity)
        {
            UpdateInternal(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            //entity.ThrowIfArgumentNull(nameof(entity));

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        public void BulkDelete(IEnumerable<T> entities)
        {
            //entities.ThrowIfArgumentNull(nameof(entities));

            _context.RemoveRange(entities);

            _context.SaveChanges();
        }

        public async Task BulkDeleteASync(IEnumerable<T> entities)
        {
            //entities.ThrowIfArgumentNull(nameof(entities));

            _context.RemoveRange(entities);

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);

            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(K id)
        {
            var entity = Entities.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity.Result);

            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            UpdateInternal(entity);

            return _context.SaveChangesAsync();
        }

        public Task InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);

            return _context.SaveChangesAsync();
        }

        public void BulkUpdate(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                UpdateInternal(item);
            }
            _context.SaveChanges();
        }

        public async Task BulkUpdateAsync(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                UpdateInternal(item);
            }
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Privates

        private void UpdateInternal(T entity)
        {
            //entity.ThrowIfArgumentNull(nameof(entity));

            EntityEntry entry = _context.Entry(entity);
            var currentState = entry.State;

            if (currentState == EntityState.Detached)
            {
                var existing = GetById(entity.Id);

                if (existing != null)
                {
                    entry = _context.Entry(existing);
                    entry.CurrentValues.SetValues(entity);
                }
            }

            entry.State = EntityState.Modified;
        }

        #endregion
    }

}
