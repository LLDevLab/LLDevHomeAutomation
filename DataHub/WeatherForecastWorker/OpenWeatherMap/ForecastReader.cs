using System.Threading.Tasks;
using System.Net;
using WeatherForecastWorker.OpenWeatherMap.Dtos;
using Newtonsoft.Json;

namespace WeatherForecastWorker.OpenWeatherMap
{
    public class ForecastReader
    {
        readonly string _baseUrl;
        readonly WeatherOpenMapApiSettings _settings;

        public ForecastReader(WeatherOpenMapApiSettings settings)
        {
            _baseUrl = "https://api.openweathermap.org";
            _settings = settings;
        }

        public async Task<WeatherForecastDto> ReadForecastAsync(string apiVersion)
        {
            var json = await ReadData(apiVersion);
            WeatherForecastDto result = JsonConvert.DeserializeObject<WeatherForecastDto>(json);
            return result;
        }

        async Task<string> ReadData(string apiVersion) => await Task.Run(() =>
            {
                var url = $"{_baseUrl}/data/{apiVersion}/weather?lat={_settings.Latitude}&lon={_settings.Longitude}&appid={_settings.ApiKey}";
                var response = new WebClient().DownloadString(url);
                return response;
            });
    }
}
