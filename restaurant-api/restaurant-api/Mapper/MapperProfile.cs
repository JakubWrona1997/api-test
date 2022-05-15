using AutoMapper;
using restaurant_api.Domain.DTOs.Dish;
using restaurant_api.Domain.DTOs.Restaurant;
using restaurant_api.Domain.Entities;

namespace restaurant_api.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(m => m.Address, c => c.MapFrom(dto => new Address()
                { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));

            CreateMap<Dish, DishDto>();
            
            CreateMap<CreateDishDto, Dish>();

        }
    }
}
