using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using RabidBike.Common.Models;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Items.GetItems
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, (int, IEnumerable<ItemsResponse>)>
    {

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IItemRepository itemRepository,
                                    IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<(int, IEnumerable<ItemsResponse>)> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            PagedList<Item> items = await _itemRepository.GetItems(request.ItemParameters);
            int totalItems = items.TotalCount;
            IEnumerable<ItemsResponse> result = _mapper.Map<IEnumerable<ItemsResponse>>(items);
            return (totalItems, result);
        }
    }
}
