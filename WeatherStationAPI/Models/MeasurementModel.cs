using System;

namespace WeatherStationAPI.Models
{
    public class MeasurementModel
    {
        public DateTime MeasurementDateTime { get; set; }
        public int MeasurementTypeId { get; set; }
        public int SensorId { get; set; }
    }
}