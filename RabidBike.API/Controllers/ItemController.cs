#region Namespaces

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabidBike.API.ActionFilters;
using RabidBike.API.Extensions;
using RabidBike.API.Models.Request;
using RabidBike.API.Models.Response;
using RabidBike.Data.Identity;
using RabidBike.Data.Models;
using RabidBike.Services.Commands.Items.CreateItem;
using RabidBike.Services.Commands.Items.DeleteItem;
using RabidBike.Services.Commands.Items.UpdateItem;
using RabidBike.Services.Queries.Items.GetItems;
using RabidBike.Services.Queries.Items.GetItemsByCategory;
using RabidBike.Services.Queries.Items.UserOwnsItem;

#endregion

namespace RabidBike.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ItemController : ControllerBase
    {
        #region Private fields

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly RabidUserManager _userManager;

        #endregion


        #region Ctor

        public ItemController(IMediator mediator,
                                IMapper mapper,
                                RabidUserManager userManager)
        {
            _mediator = mediator;
            _mapper = mapper;
            _userManager = userManager;
        }

        #endregion


        #region GetAll

        // Returns all items, includes paging and search string
        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] ItemParameters itemParameters)
        {
            var query = new GetItemsQuery(itemParameters);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<ItemsListResponse>>(queryResult);

            return Ok(result);
        }

        #endregion


        #region GetAllByCategoryId

        [HttpGet("GetAllByCategoryId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByCategoryId([FromQuery] int categoryId, [FromQuery] ItemParameters itemParameters)
        {
            var query = new GetItemsByCategoryQuery(categoryId, itemParameters);
            var queryResult = await _mediator.Send(query);
            var result = _mapper.Map<IEnumerable<ItemsListByCategoryResponse>>(queryResult);

            return Ok(result);
        }

        #endregion


        #region Create Item

        [HttpPost("CreateItem")]
        [Authorize(Policy = "RequireUser")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateItem([FromBody] CreateItemRequestModel model)
        {

            var command = _mapper.Map<CreateItemCommand>(model);
            command.SellerId = HttpContext.GetUserId();
            var result = await _mediator.Send(command);

            return result != null ? (IActionResult)Ok(result) : BadRequest();
        }

        #endregion


        #region Update Item

        [HttpPut("UpdateItem")]
        [Authorize(Policy = "RequireUser")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemRequestModel model)
        {

            if (await CheckIfItemIsOwnedByUser(model.Id, HttpContext.GetUserId()) == false)
            {
                return BadRequest("User does not own this item and is not an admin either.");
            }

            // Update command
            UpdateItemCommand updateCommand = _mapper.Map<UpdateItemCommand>(model);
            var result = await _mediator.Send(updateCommand);

            if (result == null)
            {
                return NotFound();
            }

            return Ok($"{result.Message} Item id: {model.Id}");
        }

        #endregion


        #region Delete Item

        [HttpDelete("DeleteItem/{id}")]
        [Authorize(Policy = "RequireUser")]
        public async Task<IActionResult> DeleteItem(int id)
        {

            if (await CheckIfItemIsOwnedByUser(id, HttpContext.GetUserId()) == false)
            {
                return BadRequest("User does not own this item and is not an admin either.");
            }

            var command = new DeleteItemCommand(id);
            var result = await _mediator.Send(command);

            if (result == false)
            {
                return NotFound("The item you are trying to delete does not exist");
            }

            return NoContent();

        }

        #endregion



        #region Helper methods

        public async Task<bool> IsItemOwnedByUser(int itemId, string userId)
        {
            var query = new UserOwnsItemQuery(itemId, userId);
            return await _mediator.Send(query);
        }

        public async Task<bool> CheckIfItemIsOwnedByUser(int itemId, string userId)
        {
            bool isOwned = await IsItemOwnedByUser(itemId, userId);
            bool isAdmin = HttpContext.IsAdmin();

            if (!isOwned)
            {
                if (!isAdmin)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

    }
}