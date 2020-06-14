using RabidBike.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabidBike.Data.Abstractions
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
