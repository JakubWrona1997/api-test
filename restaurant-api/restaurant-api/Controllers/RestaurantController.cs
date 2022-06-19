using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restaurant_api.Domain.DTOs.Restaurant;
using restaurant_api.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace restaurant_api.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        [Authorize(Policy = "CreateAtLeast2Restaurants")]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurantsDto = await _restaurantService.GetAll();

            return Ok(restaurantsDto);
        }
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<RestaurantDto>> GetById([FromRoute]int id)
        {
            var restaurantDto = await _restaurantService.GetById(id);

            return Ok(restaurantDto);
        }
        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult> CreateRestaurant([FromBody]CreateRestaurantDto restaurantDto)
        {           
            var id = await _restaurantService.Create(restaurantDto);

            return Created($"/api/restaurant/{id}", null);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateRestaurant([FromBody]UpdateRestaurantDto restaurantDto, [FromRoute]int id)
        {
            await _restaurantService.Update(restaurantDto, id);
            
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            await _restaurantService.Delete(id);

            return NoContent();
        }
    }
}
