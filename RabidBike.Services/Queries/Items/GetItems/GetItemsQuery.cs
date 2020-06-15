using MediatR;
using RabidBike.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.GetItems
{
    public class GetItemsQuery : IRequest<(int, IEnumerable<ItemsResponse>)>
    {
        public GetItemsQuery(ItemParameters itemParameters)
        {
            ItemParameters = itemParameters;
        }

        public ItemParameters ItemParameters { get; }
    }
}
