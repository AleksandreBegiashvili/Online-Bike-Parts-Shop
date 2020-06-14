using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.Models.Response;
using RabidBike.Data.Identity;
using RabidBike.Services.Queries.Conditions.GetConditions;

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ConditionController : ControllerBase
    {
        #region Private fields

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RabidUserManager _userManager;

        #endregion


        #region Ctor

        public ConditionController(IMediator mediator,
                                IMapper mapper,
                                RabidUserManager userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        #endregion



        #region GetConditions

        [HttpGet("GetConditions")]
        [AllowAnonymous]
        public async Task<IActionResult> GetConditions()
        {
            var query = new GetConditionsQuery();
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<ConditionResponseModel>>(queryResult);

            return Ok(result);
        }

        #endregion
    }
}
