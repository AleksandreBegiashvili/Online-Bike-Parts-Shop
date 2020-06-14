using RabidBike.Data.Abstractions;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Data.Implementations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IBaseRepository<Location, int> _locationRepositoryObject;

        public LocationRepository(IBaseRepository<Location, int> locationRepositoryObject)
        {
            _locationRepositoryObject = locationRepositoryObject;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _locationRepositoryObject.GetAllAsync();
        }
    }
}
