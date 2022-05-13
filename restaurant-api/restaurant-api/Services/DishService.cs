using AutoMapper;
using restaurant_api.Contracts;
using restaurant_api.Domain.DTOs.Dish;
using restaurant_api.Domain.Entities;
using restaurant_api.Exceptions;
using restaurant_api.Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_api.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> CreateDish(int restaurantId, CreateDishDto createDishDto)
        {
            var restaurant = _dbContext.Restaurants.FirstOrDefault(x => x.Id == restaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant not found");
            }

            var dishEntity = _mapper.Map<Dish>(createDishDto);

            dishEntity.RestaurantId = restaurantId;

            _dbContext.Dishes.Add(dishEntity);
            await _dbContext.SaveChangesAsync();

            return dishEntity.Id;
        }
    }
}
