namespace WeatherForecastWorker.OpenWeatherMap.Dtos
{
    public class WeatherSysDataDto
    {
        public int Id { get; init; }
        public int Type { get; init; }
        public string Country { get; init; }
        public long Sunrise { get; init; }
        public long Sunset { get; init; }
    }
}
