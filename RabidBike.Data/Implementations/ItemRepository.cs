using Microsoft.EntityFrameworkCore;
using RabidBike.Data.Abstractions;
using RabidBike.Common.Models;
using RabidBike.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.Data.Implementations
{
    public class ItemRepository : IItemRepository
    {

        #region Private Readonly fields

        private readonly IBaseRepository<Item, int> _itemRepositoryObject;

        #endregion


        #region Ctor

        public ItemRepository(IBaseRepository<Item, int> itemRepositoryObject)
        {
            _itemRepositoryObject = itemRepositoryObject;
        }

        #endregion


        #region GetById Async

        public async Task<Item> GetById(int id)
        {
            return await _itemRepositoryObject.GetByIdAsync(id);
        }

        #endregion

        #region GetByIdForOwnershipCheck Async

        public async Task<Item> GetByIdForOwnershipCheck(int id)
        {
            return await _itemRepositoryObject.TableNoTracking
                                                .SingleOrDefaultAsync(i => i.Id == id);
        }

        #endregion

        #region GetItems Async, Paged, Filtered

        public async Task<PagedList<Item>> GetItems(ItemParameters itemParameters)
        {
            IQueryable<Item> items = _itemRepositoryObject.Table
                .Include(i => i.Category)
                .Include(i => i.Condition)
                .Include(i => i.Location)
                .Include(i => i.Seller);
            SearchByName(ref items, itemParameters.Name);

            return await PagedList<Item>.ToPagedList(items, itemParameters.PageNumber, itemParameters.PageSize);
        }

        #endregion

        #region GetItemsByCategoryId Async, Paged, Filtered

        public async Task<PagedList<Item>> GetItemsByCategoryId(int categoryId, ItemParameters itemParameters)
        {
            IQueryable<Item> items = _itemRepositoryObject.Table.Where(i => i.CategoryId == categoryId)
                .Include(i => i.Category)
                .Include(i => i.Condition)
                .Include(i => i.Location)
                .Include(i => i.Seller);
            SearchByName(ref items, itemParameters.Name);

            return await PagedList<Item>.ToPagedList(items, itemParameters.PageNumber, itemParameters.PageSize);

        }

        #endregion

        #region GetItemsByUser Async, Paged

        public async Task<PagedList<Item>> GetItemsByUser(string userId, QueryStringParameters pagingParams)
        {
            IQueryable<Item> items = _itemRepositoryObject.Table.Where(i => i.SellerId.Equals(userId))
                .Include(i => i.Category)
                .Include(i => i.Condition)
                .Include(i => i.Location)
                .Include(i => i.Seller);
            return await PagedList<Item>.ToPagedList(items, pagingParams.PageNumber, pagingParams.PageSize);
        }

        #endregion

        #region Insert Async

        public async Task Insert(Item item)
        {
            await _itemRepositoryObject.InsertAsync(item);
        }

        #endregion

        #region Update Async

        public async Task Update(Item item)
        {
            await _itemRepositoryObject.UpdateAsync(item);
        }

        #endregion

        #region Delete Async

        public async Task Delete(int id)
        {
            await _itemRepositoryObject.DeleteAsync(id);
        }

        #endregion


        #region Private Methods

        private void SearchByName(ref IQueryable<Item> items, string itemName)
        {
            if (!items.Any() || string.IsNullOrWhiteSpace(itemName))
            {
                return;
            }

            items = items.Where(i => i.Name.ToLower().Contains(itemName.Trim().ToLower()));
        }

        #endregion

    }
}
