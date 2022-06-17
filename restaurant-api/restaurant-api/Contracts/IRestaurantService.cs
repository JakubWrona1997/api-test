using restaurant_api.Domain.DTOs.Restaurant;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace restaurant_api.Services
{
    public interface IRestaurantService
    {
        Task<int> Create(CreateRestaurantDto restaurantDto, int userId);
        Task<IEnumerable<RestaurantDto>> GetAll();
        Task<RestaurantDto> GetById(int id);
        Task Delete(int id, ClaimsPrincipal user);
        Task Update(UpdateRestaurantDto updateRestaurantDto, int id, ClaimsPrincipal user);
    }
}