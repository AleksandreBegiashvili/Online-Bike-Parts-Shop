using AutoMapper;
using RabidBike.Domain.Entities;
using RabidBike.Services.Commands.Items.CreateItem;
using RabidBike.Services.Commands.Items.UpdateItem;
using RabidBike.Services.Queries.Categories.GetCategories;
using RabidBike.Services.Queries.Conditions.GetConditions;
using RabidBike.Services.Queries.Items.GetItemById;
using RabidBike.Services.Queries.Items.GetItems;
using RabidBike.Services.Queries.Items.GetItemsByCategory;
using RabidBike.Services.Queries.Items.GetItemsByUser;
using RabidBike.Services.Queries.Locations.GetLocations;

namespace RabidBike.Services.Helpers.Mapper
{
    public class ServiceToRepositoryMappingProfile : Profile
    {
        public ServiceToRepositoryMappingProfile()
        {
            CreateMap<Item, ItemsResponse>()
                 .ForMember(dest => dest.Condition, opts => opts.MapFrom(src => src.Condition.Name))
                 .ForMember(dest => dest.Location, opts => opts.MapFrom(src => src.Location.City))
                 .ForMember(dest => dest.Seller, opts => opts.MapFrom(src => src.Seller.UserName))
                 .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category.CategoryName));

            CreateMap<Item, ItemsByCategoryResponse>()
                 .ForMember(dest => dest.Condition, opts => opts.MapFrom(src => src.Condition.Name))
                 .ForMember(dest => dest.Location, opts => opts.MapFrom(src => src.Location.City))
                 .ForMember(dest => dest.Seller, opts => opts.MapFrom(src => src.Seller.UserName))
                 .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category.CategoryName));

            CreateMap<Item, ItemsByUserResponse>()
                 .ForMember(dest => dest.Condition, opts => opts.MapFrom(src => src.Condition.Name))
                 .ForMember(dest => dest.Location, opts => opts.MapFrom(src => src.Location.City))
                 .ForMember(dest => dest.Seller, opts => opts.MapFrom(src => src.Seller.UserName))
                 .ForMember(dest => dest.Category, opts => opts.MapFrom(src => src.Category.CategoryName));

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
