using System.Collections.Generic;

namespace WeatherStationAPI.Models
{
    public class SensorModel
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<MeasurementTypeModel> MeasurementTypes { get; set; }
    }
}