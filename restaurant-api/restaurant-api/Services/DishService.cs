using AutoMapper;
using Microsoft.EntityFrameworkCore;
using restaurant_api.Contracts;
using restaurant_api.Domain.DTOs.Dish;
using restaurant_api.Domain.Entities;
using restaurant_api.Exceptions;
using restaurant_api.Infrastructure.Context;
using System.Collections.Generic;
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
        public async Task<int> Create(int restaurantId, CreateDishDto createDishDto)
        {
            var restaurant = await GetRestaurantById(restaurantId);

            var dishEntity = _mapper.Map<Dish>(createDishDto);

            dishEntity.RestaurantId = restaurantId;

            _dbContext.Dishes.Add(dishEntity);
            await _dbContext.SaveChangesAsync();

            return dishEntity.Id;
        }
        public async Task<IEnumerable<DishDto>> GetAll(int restaurantId)
        {
            var restaurant = await _dbContext.Restaurants
                .Include(x => x.Dishes)
                .FirstOrDefaultAsync(x => x.Id == restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant not found");
            }

            var dishesDto = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishesDto;
        }

        public async Task<DishDto> GetById(int restaurantId, int dishId)
        {
            var restaurant = await GetRestaurantById(restaurantId);

            var dish = await _dbContext.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);
            if (dish == null || dish.RestaurantId != restaurantId)
            {
                throw new NotFoundException("Dish not found");
            }

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }
        public async Task DeleteAll(int restaurantId)
        {
            var restaurant = await GetRestaurantById(restaurantId);
            _dbContext.RemoveRange(restaurant.Dishes);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteById(int restaurantId, int dishId)
        {
            var restaurant = await GetRestaurantById(restaurantId);

            var dish = _dbContext.Dishes.FirstOrDefault(x => x.Id == dishId);
            if (dish == null || dish.RestaurantId != restaurantId)
            {
                throw new NotFoundException("Dish not found");
            }

            _dbContext.Dishes.Remove(dish);
            await _dbContext.SaveChangesAsync();
        }

        private async Task<Restaurant> GetRestaurantById(int restaurantId)
        {
            var restaurant = await _dbContext.Restaurants
                .FirstOrDefaultAsync(x => x.Id == restaurantId);

            if (restaurant == null)
            {
                throw new NotFoundException("Restaurant not found");
            }

            return restaurant;
        }

       
    }
}
