using RabidBike.Data.Abstractions;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Data.Implementations
{
    public class ConditionRepository : IConditionRepository
    {
        private readonly IBaseRepository<Condition, int> _conditionRepositoryObject;

        public ConditionRepository(IBaseRepository<Condition, int> conditionRepositoryObject)
        {
            _conditionRepositoryObject = conditionRepositoryObject;
        }

        public async Task<IEnumerable<Condition>> GetConditions()
        {
            return await _conditionRepositoryObject.GetAllAsync();
        }
    }
}
