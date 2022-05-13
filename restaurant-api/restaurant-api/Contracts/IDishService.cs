using restaurant_api.Domain.DTOs.Dish;
using System.Threading.Tasks;

namespace restaurant_api.Contracts
{
    public interface IDishService
    {
        Task<int> CreateDish(int restaurantId, CreateDishDto createDishDto);
    }
}
