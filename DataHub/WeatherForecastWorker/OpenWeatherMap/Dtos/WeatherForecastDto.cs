using System.Collections.Generic;

namespace WeatherForecastWorker.OpenWeatherMap.Dtos
{
    public class WeatherForecastDto
    {
        /// <summary>
        /// Geographical coordinates
        /// </summary>
        public CoordinatesDto Coord { get; init; }

        /// <summary>
        /// Weather descriptions
        /// </summary>
        public IEnumerable<WeatherDescDto> Weather { get; init; }

        public string Base { get; init; }
        public WeatherMainDataDto Main { get; init; }
        public int Visibility { get; init; }
        public WeatherWindDataDto Wind { get; init; }
        public WeatherCloudsDataDto Clouds { get; init; }
        public long Dt { get; init; }
        public WeatherSysDataDto Sys { get; init; }
        public int TimeZone { get; init; }
        public long Id { get; init; }
        public string Name { get; init; }
        public int Cod { get; init; }
    }
}
