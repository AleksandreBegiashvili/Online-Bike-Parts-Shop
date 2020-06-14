using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Categories.GetCategories
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoriesResponse>>
    {

    }
}
