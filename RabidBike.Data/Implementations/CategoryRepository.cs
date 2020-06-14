using RabidBike.Data.Abstractions;
using RabidBike.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RabidBike.Data.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IBaseRepository<Category, int> _categoryRepositoryObject;

        public CategoryRepository(IBaseRepository<Category, int> categoryRepositoryObject)
        {
            _categoryRepositoryObject = categoryRepositoryObject;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepositoryObject.GetAllAsync();
        }
    }
}
