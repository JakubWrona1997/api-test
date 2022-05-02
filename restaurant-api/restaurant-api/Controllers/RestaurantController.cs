﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant_api.Domain.DTOs;
using restaurant_api.Domain.Entities;
using restaurant_api.Infrastructure.Context;
using restaurant_api.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_api.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
        {
            var restaurantsDto = await _restaurantService.GetAll();

            return Ok(restaurantsDto);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RestaurantDto>> GetById([FromRoute]int id)
        {
            var restaurantDto = await _restaurantService.GetById(id);

            if(restaurantDto == null)
            {
                return NotFound();
            }

            return Ok(restaurantDto);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateRestaurant([FromBody]CreateRestaurantDto restaurantDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = await _restaurantService.Create(restaurantDto);

            return Created($"/api/restaurant/{id}", null);
        }
    }
}
