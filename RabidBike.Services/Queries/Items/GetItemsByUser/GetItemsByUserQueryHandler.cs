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

namespace RabidBike.Services.Queries.Items.GetItemsByUser
{
    public class GetItemsByUserQueryHandler : IRequestHandler<GetItemsByUserQuery, (int, IEnumerable<ItemsByUserResponse>)>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsByUserQueryHandler(IItemRepository itemRepository,
            IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<(int, IEnumerable<ItemsByUserResponse>)> Handle(GetItemsByUserQuery request, CancellationToken cancellationToken)
        {
            PagedList<Item> items = await _itemRepository.GetItemsByUser(request.UserId, request.QueryParams);
            int totalItems = items.TotalCount;
            IEnumerable<ItemsByUserResponse> result = _mapper.Map<IEnumerable<ItemsByUserResponse>>(items);
            return (totalItems, result);
        }
    }
}
