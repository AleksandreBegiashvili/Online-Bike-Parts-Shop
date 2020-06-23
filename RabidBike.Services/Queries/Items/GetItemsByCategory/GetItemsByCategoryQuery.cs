using MediatR;
using RabidBike.Common.Models;
using System.Collections.Generic;

namespace RabidBike.Services.Queries.Items.GetItemsByCategory
{
    public class GetItemsByCategoryQuery : IRequest<(int, IEnumerable<ItemsByCategoryResponse>)>
    {

        public GetItemsByCategoryQuery(int categoryId, ItemParameters itemParameters)
        {
            CategoryId = categoryId;
            ItemParameters = itemParameters;
        }

        public int CategoryId { get; set; }
        public ItemParameters ItemParameters { get; }

    }
}
