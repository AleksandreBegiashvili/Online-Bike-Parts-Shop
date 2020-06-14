using MediatR;
using RabidBike.Data.Abstractions;
using RabidBike.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Commands.Items.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, bool>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            Item item = await _itemRepository.GetById(request.ItemId);
            if (item == null)
            {
                return false;
            }

            await _itemRepository.Delete(request.ItemId);
            return true;

        }
    }
}
