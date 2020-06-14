using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabidBike.Services.Queries.Locations.GetLocations
{
    public class GetLocationsQuery : IRequest<IEnumerable<LocationsResponse>>
    {
    }
}
