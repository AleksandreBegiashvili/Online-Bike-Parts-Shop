using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Conditions.GetConditions
{
    public class GetConditionsQueryHandler : IRequestHandler<GetConditionsQuery, IEnumerable<ConditionsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IConditionRepository _conditionRepository;

        public GetConditionsQueryHandler(IMapper mapper, IConditionRepository conditionRepository)
        {
            _mapper = mapper;
            _conditionRepository = conditionRepository;
        }

        public async Task<IEnumerable<ConditionsResponse>> Handle(GetConditionsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ConditionsResponse>>(await _conditionRepository.GetConditions());
        }
    }
}
