using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using RabidBike.Data.Models;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Items.GetItems
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, IEnumerable<ItemsResponse>>
    {

        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsQueryHandler(IItemRepository itemRepository,
                                    IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemsResponse>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ItemsResponse>>(await _itemRepository.GetItems(request.ItemParameters)); 
        }
    }
}
