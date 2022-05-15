using Microsoft.AspNetCore.Mvc;
using restaurant_api.Contracts;
using restaurant_api.Domain.DTOs.Dish;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace restaurant_api.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }
        [HttpGet]
        [Route("{dishId}")]
        public async Task<ActionResult<DishDto>> Get([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            var dish = await _dishService.GetById(restaurantId, dishId);

            return Ok(dish);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> Get([FromRoute] int restaurantId)
        {
            var result = await _dishService.GetAll(restaurantId);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromRoute]int restaurantId, [FromBody]CreateDishDto createDishDto)
        {
            var dishId = await _dishService.Create(restaurantId, createDishDto);

            return Created($"api/restaurant/{restaurantId}/dish/{dishId}", null);
        }
    }
}
