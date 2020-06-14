using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.Models.Response;
using RabidBike.Data.Identity;
using RabidBike.Services.Queries.Locations.GetLocations;

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LocationController : ControllerBase
    {

        #region Private fields

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RabidUserManager _userManager;

        #endregion

        #region Ctor

        public LocationController(IMediator mediator,
                                IMapper mapper,
                                RabidUserManager userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        #endregion

        #region GetLocations

        [HttpGet("GetLocations")]
        [AllowAnonymous]
        public async Task<IActionResult> GetLocations()
        {
            var query = new GetLocationsQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<LocationResponseModel>>(queryResult);

            return Ok(result);
        }

        #endregion
    }
}
