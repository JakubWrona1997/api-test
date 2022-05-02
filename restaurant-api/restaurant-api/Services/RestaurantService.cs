using AutoMapper;
using Microsoft.EntityFrameworkCore;
using restaurant_api.Domain.DTOs;
using restaurant_api.Domain.Entities;
using restaurant_api.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace restaurant_api.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            var request = _mapper.Map<Restaurant>(restaurantDto);
            _dbContext.Restaurants.Add(request);
            await _dbContext.SaveChangesAsync();

            return request.Id;
        }
    }
}
