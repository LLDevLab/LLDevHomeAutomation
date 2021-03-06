﻿using DbCommunicationLib;
using IoTCommunicationGui.Dtos;
using IoTCommunicationGui.Dtos.Charts;
using IoTCommunicationGui.Dtos.Charts.LineChart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoTCommunicationGui.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController : ControllerBase
    {
#if !DEBUG
        const int daysFromNow = -2;
#endif
        readonly HomeAutomationContext _context;
        public ChartController(HomeAutomationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ChartDto> Get() => 
            from chart in _context.Charts
            orderby chart.Id
            select new ChartDto 
            {
                Id = chart.Id,
                Name = chart.Name
            };

        [HttpGet("{id:int}")]
        public ChartDto GetDetail(int id) => 
            (from chart in _context.Charts
            where chart.Id == id
            select new ChartDto 
            {
                Id = chart.Id,
                Name = chart.Name
            }).First();

        [HttpGet("{id:int}/sensorgroups")]
        public IEnumerable<SesnorGroupDto> GetChartSensorGroups(int id)
        {
            var result = from sensorGroups in _context.SensorGroups
                         join mappings in _context.ChartSensorGroupsMappings on sensorGroups.Id equals mappings.SensorGroupId
                         where mappings.ChartId == id
                         select new SesnorGroupDto
                         {
                             SensorGroupId = sensorGroups.Id,
                             SensorGroupName = sensorGroups.Name,
                             UnitId = sensorGroups.UnitId
                         };

            return result;
        }

        [HttpGet("sensor/{sensorId:int}")]
        public IEnumerable<LineChartDto<double>> GetChartDataBySensorId(int sensorId)
        {
#if DEBUG
            var dateFrom = new DateTime(2021, 04, 20);
#else
            var dateFrom = DateTime.Now.AddDays(daysFromNow);
#endif
            var sensorName = (from sensors in _context.Sensors
                              where sensors.Id == sensorId
                              select sensors.Name).First();

            var events = from sensorEvents in _context.SensorEvents
                         where sensorEvents.SensorId == sensorId &&
                         sensorEvents.EventDateTime >= dateFrom
                         // Ascending sort is needed because clustered index of a table is sorted in descendig order
                         orderby sensorEvents.EventDateTime ascending
                         select new
                         {
                             sensorEvents.EventDateTime,
                             sensorEvents.EventDoubleValue
                         };

            var result = new LineChartDto<double>
            {
                Name = sensorName,
                Series = events.Select(x => new LineChartPointDto<double>
                {
                    Name = x.EventDateTime.ToString("dd/MM/yyyy HH:mm"),
                    Value = Math.Round(x.EventDoubleValue.Value, 2)
                })
            };

            return new List<LineChartDto<double>> { result };
        }

        [HttpGet("{chartId:int}/sensorgroup/{sensorGroupId:int}")]
        public IEnumerable<LineChartDto<double>> GetChartDataByUnitId(int chartId, int sensorGroupId)
        {
#if DEBUG
            var dateFrom = new DateTime(2021, 04, 20);
#else
            var dateFrom = DateTime.Now.AddDays(daysFromNow);
#endif
            var queryResults = (from sensors in _context.Sensors
                                where sensors.SensorGroupId == sensorGroupId
                                join sensorEvents in _context.SensorEvents on sensors.Id equals sensorEvents.SensorId
                                where sensorEvents.EventDateTime >= dateFrom
                                // Ascending sort is needed because clustered index of a table is sorted in descendig order
                                orderby sensorEvents.EventDateTime ascending
                                select new
                                {
                                    sensors.Name,
                                    sensorEvents.EventDateTime,
                                    sensorEvents.EventDoubleValue
                                });

            var groupedResults = queryResults.AsEnumerable().GroupBy(x => x.Name);

            var results = new List<LineChartDto<double>>();

            foreach (var groupedResult in groupedResults)
            {
                var chartPoints = groupedResult.Select(x => new Tuple<DateTime, double>(RoundToMins(x.EventDateTime), Math.Round(x.EventDoubleValue.Value, 2)))
                    .OrderBy(x => x.Item1).ToList();

                var result = new LineChartDto<double>
                {
                    Name = groupedResult.Key,
                    Series = FillDateGaps(chartPoints)
                };
                results.Add(result);
            }

            return results;
        }

        #region private methods
        static DateTime RoundToMins(DateTime dateTime)
        {
            var mins = dateTime.Minute;
            int roundedMins;

            if (mins >= 53 || mins <= 7)
                roundedMins = 0;
            else if (mins >= 8 && mins <= 22)
                roundedMins = 15;
            else if (mins >= 23 && mins <= 37)
                roundedMins = 30;
            else
                roundedMins = 45;

            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, roundedMins, 0);
        }

        /// <summary>
        /// Filling the gaps, between data. If gaps not filled in ngx-charts will not show graphic with different sensors properly
        /// </summary>
        static List<LineChartPointDto<double>> FillDateGaps(List<Tuple<DateTime, double>> list)
        {
            Tuple<DateTime, double> prevPoint = null;
            List<LineChartPointDto<double>> result = new();
            const int minsToAdd = 15;
            
            foreach (var point in list)
            {
                if (prevPoint != null)
                {
                    var nextDt = prevPoint.Item1.AddMinutes(minsToAdd);

                    while (point.Item1 > nextDt)
                    {
                        AddToResult(new Tuple<DateTime, double>(nextDt, prevPoint.Item2));
                        nextDt = nextDt.AddMinutes(minsToAdd);
                    }
                }

                AddToResult(point);
                prevPoint = point;
            }

            return result;

            void AddToResult(Tuple<DateTime, double> pnt)
            {
                result.Add(new LineChartPointDto<double>
                {
                    Name = RoundToMins(pnt.Item1).ToString("dd/MM/yyyy HH:mm"),
                    Value = Math.Round(pnt.Item2, 2)
                });
            }
        }

#endregion private methods
    }
}
