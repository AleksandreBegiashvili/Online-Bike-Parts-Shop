using RabidBike.Data.Models;
using RabidBike.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabidBike.Data.Abstractions
{
    public interface IItemRepository
    {
        Task<Item> GetById(int id);
        Task<Item> GetByIdForOwnershipCheck(int id);

        Task<PagedList<Item>> GetItems(ItemParameters itemParameters);
        Task<PagedList<Item>> GetItemsByCategoryId(int categoryId, ItemParameters itemParameters);

        Task Insert(Item item);

        Task Update(Item item);

        Task Delete(int id);


    }
}
