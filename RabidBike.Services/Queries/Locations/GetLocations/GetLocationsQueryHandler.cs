using AutoMapper;
using MediatR;
using RabidBike.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabidBike.Services.Queries.Locations.GetLocations
{
    class GetLocationsQueryHandler : IRequestHandler<GetLocationsQuery, IEnumerable<LocationsResponse>>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetLocationsQueryHandler(ILocationRepository locationRepository,
                                            IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationsResponse>> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<LocationsResponse>>(await _locationRepository.GetLocations());
        }
    }
}
