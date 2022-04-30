using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant_api.Domain.DTOs;
using restaurant_api.Domain.Entities;
using restaurant_api.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_api.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public RestaurantController(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurants = await _dbContext
                .Restaurants
                .Include(i => i.Address)
                .Include(i => i.Dishes)
                .ToListAsync();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return Ok(restaurantsDtos);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetById([FromRoute]int id)
        {
            var restaurant = await _dbContext
                .Restaurants
                .Include(i => i.Address)
                .Include(i => i.Dishes)
                .FirstOrDefaultAsync(x=>x.Id == id);

            if(restaurant == null)
            {
                return NotFound();
            }

            var restuarantDto = _mapper.Map<RestaurantDto>(restaurant);

            return Ok(restuarantDto);
        }
    }
}
