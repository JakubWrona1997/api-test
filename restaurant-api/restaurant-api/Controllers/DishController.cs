using Microsoft.AspNetCore.Mvc;
using restaurant_api.Contracts;
using restaurant_api.Domain.DTOs.Dish;
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
        [HttpPost]
        public async Task<ActionResult> Post([FromRoute]int restaurantId, [FromBody]CreateDishDto createDishDto)
        {
            var dishId = await _dishService.CreateDish(restaurantId, createDishDto);

            return Created($"api/restaurant/{restaurantId}/dish/{dishId}", null);
        }
    }
}
