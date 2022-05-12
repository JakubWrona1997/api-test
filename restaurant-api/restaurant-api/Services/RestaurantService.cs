using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using restaurant_api.Domain.DTOs;
using restaurant_api.Domain.Entities;
using restaurant_api.Exceptions;
using restaurant_api.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace restaurant_api.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<RestaurantDto> GetById(int id)
        {
            var restaurant = await _dbContext
                .Restaurants
                .Include(i => i.Address)
                .Include(i => i.Dishes)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (restaurant == null)
            {
                return null;
            }

            var result = _mapper.Map<RestaurantDto>(restaurant);
            return result;
        }
        public async Task<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurants = await _dbContext
                .Restaurants
                .Include(i => i.Address)
                .Include(i => i.Dishes)
                .ToListAsync();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);
            return restaurantsDtos;
        }
        public async Task<int> Create(CreateRestaurantDto restaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(restaurantDto);
            _dbContext.Restaurants.Add(restaurant);
            await _dbContext.SaveChangesAsync();

            return restaurant.Id;
        }
        public async Task Delete(int id)
        {
            _logger.LogError($"Restaurant with id: {id} DELETE action invoked");

            var restaurant = await _dbContext
                .Restaurants
                .FirstOrDefaultAsync(x => x.Id == id);
            if(restaurant == null)
            {
                throw new NotFoundException("Restaurant not found");
            }

            _dbContext.Restaurants.Remove(restaurant);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(UpdateRestaurantDto updateRestaurantDto,int id)
        {
            var restaurant = await _dbContext
                .Restaurants
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if(restaurant == null)
            {
                throw new NotFoundException("Restaurant not found");
            }
            restaurant.Name = updateRestaurantDto.Name;
            restaurant.Description = updateRestaurantDto.Description;
            restaurant.HasDelivery = updateRestaurantDto.HasDelivery;

            await _dbContext.SaveChangesAsync();
        }
    }
}
