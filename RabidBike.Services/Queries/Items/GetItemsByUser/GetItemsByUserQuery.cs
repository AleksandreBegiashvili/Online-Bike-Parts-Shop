using MediatR;
using RabidBike.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Items.GetItemsByUser
{
    public class GetItemsByUserQuery : IRequest<(int, IEnumerable<ItemsByUserResponse>)>
    {
        public GetItemsByUserQuery(string userId, QueryStringParameters queryParams)
        {
            UserId = userId;
            QueryParams = queryParams;
        }

        public string UserId { get; }
        public QueryStringParameters QueryParams { get; }
    }
}
