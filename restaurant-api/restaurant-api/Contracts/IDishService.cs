using restaurant_api.Domain.DTOs.Dish;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace restaurant_api.Contracts
{
    public interface IDishService
    {
        Task<int> Create(int restaurantId, CreateDishDto createDishDto);
        Task<DishDto> GetById(int restaurantId, int dishId);
        Task<IEnumerable<DishDto>> GetAll (int restaurantId);
    }
}
