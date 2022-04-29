using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace restaurant_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery]int paramsNumber, [FromQuery] int minTemp, [FromQuery] int maxTemp)
        {
            var result = _weatherForecastService.GenerateMockedData(paramsNumber, minTemp, maxTemp);
            return result;
        }
        
        [HttpPost]
        [Route("generate")]
        public ActionResult<IEnumerable<TemperatureRequest>> GenerateCutomData([FromQuery]int resultsNumber, [FromBody] TemperatureRequest request)
        {
            if(resultsNumber > 0 && request.MinTemperatureC< request.MaxTemperatureC)
            {
                var result = _weatherForecastService.GenerateMockedData(resultsNumber, request.MinTemperatureC, request.MaxTemperatureC);
                return Ok(result);
            }
            
            return BadRequest();
        }
    }
}
