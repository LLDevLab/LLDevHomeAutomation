namespace WeatherForecastWorker.OpenWeatherMap.Dtos
{
    public class WeatherMainDataDto
    {
        public float Temp { get; init; }
        public float Feels_like { get; init; }
        public float Temp_min { get; init; }
        public float Temp_max { get; init; }
        public int Pressure { get; init; }
        public int Humidity { get; init; }
    }
}
