namespace WeatherForecastWorker.OpenWeatherMap.Dtos
{
    public class WeatherWindDataDto
    {
        public float Speed { get; init; }
        
        /// <summary>
        /// Degree
        /// </summary>
        public int Deg { get; init; }
    }
}
