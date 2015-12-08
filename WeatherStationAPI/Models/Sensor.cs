using System.Collections.Generic;

namespace WeatherStationAPI.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MeasurementType> MeasurementTypes { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}