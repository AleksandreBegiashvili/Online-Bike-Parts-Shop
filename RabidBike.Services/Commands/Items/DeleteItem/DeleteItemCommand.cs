using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Commands.Items.DeleteItem
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public int ItemId { get; }

        public DeleteItemCommand(int itemId)
        {
            ItemId = itemId;
        }

    }
}
