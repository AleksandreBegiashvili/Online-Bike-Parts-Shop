using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.Models.Request;
using RabidBike.Services.Commands.Account.Login;
using RabidBike.Services.Commands.Account.Registration;

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IMapper mapper,
                                    IMediator mediator,
                                    RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _mediator = mediator;
            _roleManager = roleManager;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Registration data is not valid");
            }

            var command = _mapper.Map<RegistrationCommand>(model);

            var result = await _mediator.Send(command);


            return result != null ? (IActionResult)Ok(result) : BadRequest();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please specify valid email");
            }

            var command = _mapper.Map<LoginCommand>(model);
            var result = await _mediator.Send(command);

            if (result.Error == null)
            {
                return Ok(result);
            }

            return Unauthorized(result.Error);

        }



    }
}



















/*
[HttpPost("CreateRole")]
public async Task<IActionResult> CreateRole([FromBody] roleviewmodel model)
{
    var role = model.RoleName;
    bool roleExists = await _roleManager.RoleExistsAsync(role);

    if (!roleExists)
    {
        await _roleManager.CreateAsync(new IdentityRole(role));
        return Ok($"Role {role} was successfuly created.");
    }
    else
    {
        return BadRequest($"Role {role} already exists in the database.");
    }
}

public class roleviewmodel
{
    public string RoleName { get; set; }
}
*/
