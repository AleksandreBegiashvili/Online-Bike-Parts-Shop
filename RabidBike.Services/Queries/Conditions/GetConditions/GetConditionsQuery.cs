using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Conditions.GetConditions
{
    public class GetConditionsQuery : IRequest<IEnumerable<ConditionsResponse>>
    {
    }
}
