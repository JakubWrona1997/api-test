using restaurant_api.Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace restaurant_api.Services
{
    public interface IRestaurantService
    {
        Task<int> Create(CreateRestaurantDto restaurantDto);
        Task<IEnumerable<RestaurantDto>> GetAll();
        Task<RestaurantDto> GetById(int id);
        Task<bool> Delete(int id);
    }
}