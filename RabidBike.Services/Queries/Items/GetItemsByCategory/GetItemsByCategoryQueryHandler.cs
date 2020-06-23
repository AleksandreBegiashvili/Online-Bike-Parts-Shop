using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using RabidBike.Common.Models;
using RabidBike.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Items.GetItemsByCategory
{
    public class GetItemsByCategoryQueryHandler : IRequestHandler<GetItemsByCategoryQuery, (int, IEnumerable<ItemsByCategoryResponse>)>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsByCategoryQueryHandler(IItemRepository itemRepository,
                                                IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<(int, IEnumerable<ItemsByCategoryResponse>)> Handle(GetItemsByCategoryQuery request, CancellationToken cancellationToken)
        {
            //return _mapper.Map<IEnumerable<ItemsByCategoryResponse>>(await _itemRepository.GetItemsByCategoryId(request.CategoryId,
                                                                                                                //request.ItemParameters));
            PagedList<Item> items = await _itemRepository.GetItemsByCategoryId(request.CategoryId, request.ItemParameters);
            int totalItems = items.TotalCount;
            IEnumerable<ItemsByCategoryResponse> result = _mapper.Map<IEnumerable<ItemsByCategoryResponse>>(items);
            return (totalItems, result);
        }
    }
}
