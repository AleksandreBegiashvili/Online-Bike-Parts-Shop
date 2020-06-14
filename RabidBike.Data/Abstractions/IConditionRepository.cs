using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RabidBike.Data.Abstractions
{
    public interface IConditionRepository
    {
        Task<IEnumerable<Condition>> GetConditions();
    }
}
