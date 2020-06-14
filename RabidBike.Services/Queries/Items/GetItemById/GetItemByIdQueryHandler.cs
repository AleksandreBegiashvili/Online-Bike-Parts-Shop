using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Items.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, GetItemByIdQueryResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(IItemRepository itemRepository,
                                        IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<GetItemByIdQueryResponse> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetById(request.ItemId);
            if(item == null)
            {
                return null;
            }

            return _mapper.Map<GetItemByIdQueryResponse>(item);
        }
    }
}
