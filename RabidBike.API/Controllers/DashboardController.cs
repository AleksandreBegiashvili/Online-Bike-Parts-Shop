using RabidBike.Data.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using RabidBike.API.Models.Response;
using System.Collections.Generic;
using RabidBike.Domain.Entities;
using RabidBike.Common.Models;
using RabidBike.Services.Queries.Items.GetItemsByUser;
using MediatR;

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DashboardController : ControllerBase
    {
        private readonly RabidUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DashboardController(RabidUserManager userManager,
                                    IMapper mapper,
                                    IMediator mediator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mediator = mediator;
        }

        // Get items by specific user id
        [HttpGet("GetItemsBySeller")]
        public async Task<IActionResult> GetItemsBySeller([FromQuery] QueryStringParameters queryParams)
        {
            GetItemsByUserQuery query = new GetItemsByUserQuery(HttpContext.GetUserId(), queryParams);
            (int, IEnumerable<ItemsByUserResponse>) queryResult = await _mediator.Send(query);
            int totalCount = queryResult.Item1;
            IEnumerable<ItemsListResponse> items = _mapper.Map<IEnumerable<ItemsListResponse>>(queryResult.Item2);
            return Ok(new { totalCount, items });
        }

        // Get specific user details
        [HttpGet("GetCurrentUserDetails")]
        public async Task<IActionResult> GetCurrentUserDetails()
        {
            var user = await _userManager.FindByIdWithRelatedDataAsync(HttpContext.GetUserId());

            return Ok(_mapper.Map<CurrentUserDetailsResponse>(user));
        }
    }
}