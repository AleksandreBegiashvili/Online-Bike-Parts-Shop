using MediatR;
using RabidBike.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Items.UserOwnsItem
{
    public class UserOwnsItemQueryHandler : IRequestHandler<UserOwnsItemQuery, bool>
    {
        private readonly IItemRepository _itemRepository;

        public UserOwnsItemQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> Handle(UserOwnsItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetByIdForOwnershipCheck(request.ItemId);

            if(item == null)
            {
                return false;
            }

            if(!item.SellerId.Equals(request.UserId))
            {
                return false;
            }


            return true;
        }
    }
}
