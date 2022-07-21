using restaurant_api.Domain.DTOs.Restaurant;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace restaurant_api.Services
{
    public interface IRestaurantService
    {
        Task<int> Create(CreateRestaurantDto restaurantDto);
        Task<IEnumerable<RestaurantDto>> GetAll(string searchPhrase);
        Task<RestaurantDto> GetById(int id);
        Task Delete(int id);
        Task Update(UpdateRestaurantDto updateRestaurantDto, int id);
    }
}