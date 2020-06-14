﻿using RabidBike.Data.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using RabidBike.API.Models.Response;

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DashboardController : ControllerBase
    {
        private readonly RabidUserManager _userManager;
        private readonly IMapper _mapper;

        public DashboardController(RabidUserManager userManager,
                                    IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        // Get items by specific user id
        [HttpGet("GetItemsBySeller")]
        public async Task<IActionResult> GetItemsBySeller()
        {
            var user = await _userManager.FindByIdAsync(HttpContext.GetUserId());
            var items = user.Items;

            if(items == null)
            {
                return NoContent();
            }

            return Ok(items);
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