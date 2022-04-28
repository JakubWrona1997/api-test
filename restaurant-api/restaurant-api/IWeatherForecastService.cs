using System.Collections.Generic;

namespace restaurant_api
{
    public interface IWeatherForecastService
    {
        IEnumerable<WeatherForecast> GenerateMockedData();
        IEnumerable<WeatherForecast> GenerateMockedData(int paramsNubmer,int minTemp,int maxTemp);
    }
}