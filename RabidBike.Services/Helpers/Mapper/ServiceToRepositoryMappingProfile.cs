using AutoMapper;
using RabidBike.Domain.Entities;
using RabidBike.Services.Commands.Items.CreateItem;
using RabidBike.Services.Commands.Items.UpdateItem;
using RabidBike.Services.Queries.Categories.GetCategories;
using RabidBike.Services.Queries.Conditions.GetConditions;
using RabidBike.Services.Queries.Items.GetItemById;
using RabidBike.Services.Queries.Items.GetItems;
using RabidBike.Services.Queries.Items.GetItemsByCategory;
using RabidBike.Services.Queries.Locations.GetLocations;

namespace RabidBike.Services.Helpers.Mapper
{
    public class ServiceToRepositoryMappingProfile : Profile
    {
        public ServiceToRepositoryMappingProfile()
        {
            CreateMap<Item, ItemsResponse>().ReverseMap();
            CreateMap<Item, ItemsByCategoryResponse>().ReverseMap();
            CreateMap<Item, CreateItemCommand>().ReverseMap();
            CreateMap<Item, CreateItemCommandResponse>().ReverseMap();
            CreateMap<Item, GetItemByIdQueryResponse>().ReverseMap();
            CreateMap<Item, UpdateItemCommand>().ReverseMap();

            CreateMap<Category, CategoriesResponse>().ReverseMap();

            CreateMap<Location, LocationsResponse>().ReverseMap();

            CreateMap<Condition, ConditionsResponse>().ReverseMap();

        }
    }
}
