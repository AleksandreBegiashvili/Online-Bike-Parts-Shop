using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.UserOwnsItem
{
    public class UserOwnsItemQuery : IRequest<bool>
    {
        public int ItemId { get; }
        public string UserId { get; }

        public UserOwnsItemQuery(int itemId, string userId)
        {
            ItemId = itemId;
            UserId = userId;
        }

    }
}
