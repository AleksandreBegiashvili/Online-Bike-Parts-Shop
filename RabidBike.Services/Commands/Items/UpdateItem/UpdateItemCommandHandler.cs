using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Commands.Items.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, UpdateItemCommandResponse>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository itemRepository,
                                        IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<UpdateItemCommandResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            Item item = await _itemRepository.GetById(request.Id);

            if(item == null)
            {
                return null;
            }

            item.Name = request.Name;
            item.Price = request.Price;
            item.Description = request.Description;
            item.CategoryId = request.CategoryId;
            item.ConditionId = request.ConditionId;
            item.LocationId = request.LocationId;

            await _itemRepository.Update(item);

            return new UpdateItemCommandResponse
            {
                Message = "Item has been successfully updated"
            };
        }
    }
}
