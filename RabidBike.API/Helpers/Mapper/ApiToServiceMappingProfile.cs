using AutoMapper;
using RabidBike.API.Models.Request;
using RabidBike.API.Models.Response;
using RabidBike.Domain.Entities;
using RabidBike.Services.Commands.Account.Login;
using RabidBike.Services.Commands.Account.Registration;
using RabidBike.Services.Commands.Items.CreateItem;
using RabidBike.Services.Commands.Items.UpdateItem;
using RabidBike.Services.Queries.Categories.GetCategories;
using RabidBike.Services.Queries.Conditions.GetConditions;
using RabidBike.Services.Queries.Items.GetItemById;
using RabidBike.Services.Queries.Items.GetItems;
using RabidBike.Services.Queries.Items.GetItemsByCategory;
using RabidBike.Services.Queries.Locations.GetLocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabidBike.API.Helpers.Mapper
{
    public class ApiToServiceMappingProfile : Profile
    {
        public ApiToServiceMappingProfile()
        {
            CreateMap<ItemsResponse, ItemsListResponse>().ReverseMap();
            CreateMap<ItemsByCategoryResponse, ItemsListByCategoryResponse>().ReverseMap();
            CreateMap<CreateItemRequestModel, CreateItemCommand>().ReverseMap();

            CreateMap<UpdateItemRequestModel, GetItemByIdQueryResponse>().ReverseMap();
            CreateMap<UpdateItemRequestModel, UpdateItemCommand>().ReverseMap();
            CreateMap<UpdateItemCommand, GetItemByIdQueryResponse>().ReverseMap();

            CreateMap<RegisterRequestModel, RegistrationCommand>().ReverseMap();
            CreateMap<LoginCommand, LoginRequestModel>().ReverseMap();

            CreateMap<ApplicationUser, CurrentUserDetailsResponse>().ReverseMap();

            CreateMap<CategoryResponseModel, CategoriesResponse>().ReverseMap();
            CreateMap<ConditionResponseModel, ConditionsResponse>().ReverseMap();
            CreateMap<LocationResponseModel, LocationsResponse>().ReverseMap();
        }
    }
}
