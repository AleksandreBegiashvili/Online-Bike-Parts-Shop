using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.Models.Response;
using RabidBike.Data.Identity;
using RabidBike.Services.Queries.Categories.GetCategories;

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoryController : ControllerBase
    {
        #region Private fields

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RabidUserManager _userManager;

        #endregion


        #region Ctor

        public CategoryController(IMediator mediator,
                                IMapper mapper,
                                RabidUserManager userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        #endregion


        [HttpGet("GetCategories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetCategoriesQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<CategoryResponseModel>>(queryResult);

            return Ok(result);
        }
    }
}
