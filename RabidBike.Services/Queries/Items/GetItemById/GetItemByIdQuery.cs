using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.GetItemById
{
    public class GetItemByIdQuery : IRequest<GetItemByIdQueryResponse>
    {
        public int ItemId { get; }

        public GetItemByIdQuery(int itemId)
        {
            ItemId = itemId;
        }

    }
}
