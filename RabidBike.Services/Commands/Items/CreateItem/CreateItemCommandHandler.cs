using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Commands.Items.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemCommandResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IItemRepository itemRepository,
                                        IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<CreateItemCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {

            Item item = _mapper.Map<Item>(request);

            item.ListDate = DateTime.Now;
            item.ExpireDate = item.ListDate.AddDays(30);

            await _itemRepository.Insert(item);

            return _mapper.Map<CreateItemCommandResponse>(item);
        }
    }
}
